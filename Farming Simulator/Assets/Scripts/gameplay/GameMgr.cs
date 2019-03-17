/*
 * 
 * Author: Gabriel Hansley Suarez
 * Date Created: December 20, 2018
 * Source: 
 * 
 * Modified by: Antonio Lorenzo G. Hecali
 * Date Modified: December 24, 2018
 * Last Date Modified: December 24, 2018
 * 
 * Contributors:
 * 
 * Credits: -----------
 * 
 * License: 
 * 
 * Note: Game Manager 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{

    #region Game initialization module

    // Audio and audio clips
    public AudioClip[] audioClips;

    // Help menu box
    public Text helptextContainer;

    // Object to be used to populate the world space
    public Transform objGrass;

    // Initial transform position of the first object (-200, 200)
    private float initialX = -200.0f;
    private float initialY = 200.0f;

    // Offset of the specified object to be instantiated in the sequence (x -= 0.9, y -= 0.5)
    private float offsetX = 1f;
    private float offsetY = 0.5f;
    private Transform grass;
    private SpriteRenderer render;

    // New position of the instantiated tile
    private float newX;
    private float newY;

    #endregion

    #region Game objects initialization

    // Ground tile objects
    public GameObject[] groundTiles;
    public GameObject[] groundPlants;

    // Current action of the player
    public static string currentTool;

    // Current grass tile state
    private string Type;
    private bool isBuildable, isFarmable;

    #endregion

    #region Game object local variables

    string plantname;
    GameObject[] pests;
    public GameObject[] speechbubbles;

    #endregion

    void Start()
    {
        if (authenticate.tutorial == false)
        {
            GameObject.Find("playTool").GetComponent<Button>().interactable = true;
            GameObject.Find("play-Tool_Default").GetComponent<Button>().interactable = true;
            GameObject.Find("play-Tool_Fertilizer").GetComponent<Button>().interactable = true;
            GameObject.Find("play-Tool_Water").GetComponent<Button>().interactable = true;
            GameObject.Find("play-Tool_Cultivate").GetComponent<Button>().interactable = true;
            GameObject.Find("play-Tool_Harvest").GetComponent<Button>().interactable = true;
            GameObject.Find("play-Tool_Recycle").GetComponent<Button>().interactable = true;
            GameObject.Find("playPlant").GetComponent<Button>().interactable = true;
            GameObject.Find("play-Plant_Carrot").GetComponent<Button>().interactable = true;
            GameObject.Find("play-Plant_Onion").GetComponent<Button>().interactable = true;
            GameObject.Find("play-Plant_Pumpkin").GetComponent<Button>().interactable = true;
            GameObject.Find("play-Plant_Radish").GetComponent<Button>().interactable = true;
            GameObject.Find("play-Plant_Tomato").GetComponent<Button>().interactable = true;
            GameObject.Find("play-Plant_Watermelon").GetComponent<Button>().interactable = true;
            GameObject.Find("icon-options").GetComponent<Button>().interactable = true;
            GameObject.Find("icon-help").GetComponent<Button>().interactable = true;
            GameObject.Find("icon-logout").GetComponent<Button>().interactable = true;
        }
        else
        {
            createTutorial();
        }

        pests = GameObject.FindGameObjectsWithTag("Pest");

        if (pests.Length > 0)
        {
            foreach (GameObject i in pests)
            {
                Destroy(i);
            }
        }

        // Fill in details and instructions for help menu context
        helptextContainer.text = "HOW TO PLAY THE GAME";

        if (PlayerPrefs.HasKey("grass(Clone)_000_001_posX"))
        {
            // Populate world space with tile sprites in an X x Y axis 
            for (int x = 0; x < 40; x++)
            {
                initialX += (offsetX + 1);

                for (int y = 1; y < 41; y++)
                {
                    newY = initialY - (offsetY + (y - 1));

                    // If current tile is even
                    if (y % 2 == 0)
                    {
                        newX = initialX + 1f;

                        grass = Instantiate(objGrass, new Vector2(newX, newY), objGrass.rotation);
                        render = grass.GetComponent<SpriteRenderer>();

                        grass.name = grass.name + "_" + x.ToString("000") + "_" + y.ToString("000");

                        if (PlayerPrefs.GetInt(grass.name + "_hasChild") == 0)
                        {

                        }

                        else if (PlayerPrefs.GetInt(grass.name + "_hasChild") == 1)
                        {
                            // Generates new farmable tile and makes it the child of the current tile clicked
                            GameObject plot = Instantiate(groundTiles[1]);
                            plot.transform.SetParent(grass.transform, false);
                            SpriteRenderer renderSoil = plot.GetComponent<SpriteRenderer>();
                            renderSoil.sortingOrder = grass.GetComponent<SpriteRenderer>().sortingOrder + 1;

                            plot.GetComponent<characteristics>().isDestroyable = true;
                            plot.GetComponent<soilstate>().amountWater = PlayerPrefs.GetFloat(grass.name + "_hasChildWater");
                            plot.GetComponent<soilstate>().amountFertilizer_Nitorgen = PlayerPrefs.GetFloat(grass.name + "_hasChildNitrogen");
                            plot.GetComponent<soilstate>().amountFertilizer_Phosphorus = PlayerPrefs.GetFloat(grass.name + "_hasChildPhosphorus");
                            plot.GetComponent<soilstate>().amountFertilizer_Potassium = PlayerPrefs.GetFloat(grass.name + "_hasChildPotassium");

                            // Change state of the tile
                            grass.GetComponent<TileDefinition>().type = "soil";
                            grass.GetComponent<TileDefinition>().isBuildable = false;
                            grass.GetComponent<TileDefinition>().isFarmable = true;
                        }

                        else if (PlayerPrefs.GetInt(grass.name + "_hasChild") == 2)
                        {
                            #region Soil

                            // Generates new farmable tile and makes it the child of the current tile clicked
                            GameObject plot = Instantiate(groundTiles[1]);
                            plot.transform.SetParent(grass.transform, false);
                            SpriteRenderer renderSoil = plot.GetComponent<SpriteRenderer>();
                            renderSoil.sortingOrder = grass.GetComponent<SpriteRenderer>().sortingOrder + 1;

                            plot.GetComponent<characteristics>().isDestroyable = false;
                            plot.GetComponent<soilstate>().amountWater = PlayerPrefs.GetFloat(grass.name + "_hasChildWater");
                            plot.GetComponent<soilstate>().amountFertilizer_Nitorgen = PlayerPrefs.GetFloat(grass.name + "_hasChildNitrogen");
                            plot.GetComponent<soilstate>().amountFertilizer_Phosphorus = PlayerPrefs.GetFloat(grass.name + "_hasChildPhosphorus");
                            plot.GetComponent<soilstate>().amountFertilizer_Potassium = PlayerPrefs.GetFloat(grass.name + "_hasChildPotassium");

                            // Change state of the tile
                            grass.GetComponent<TileDefinition>().type = "plant";
                            grass.GetComponent<TileDefinition>().isBuildable = false;
                            grass.GetComponent<TileDefinition>().isFarmable = false;

                            #endregion

                            #region Plants

                            // Generate plants
                            plantname = PlayerPrefs.GetString(grass.name + "_hasPlant");

                            // Carrot
                            if (plantname == "Carrot")
                            {
                                // Corresponding sprite
                                GameObject plant = Instantiate(groundPlants[0]);
                                plant.transform.SetParent(grass.gameObject.transform, false);
                                plant.GetComponent<plantstate>().amountHealth = PlayerPrefs.GetFloat(grass.name + "_hasPlantHealth");
                                plant.GetComponent<plantTimer>().msecs = PlayerPrefs.GetFloat(grass.name + "_hasPlantMsec");
                                plant.GetComponent<plantTimer>().hour = PlayerPrefs.GetInt(grass.name + "_hasPlantHour");
                                plant.GetComponent<plantTimer>().day = PlayerPrefs.GetInt(grass.name + "_hasPlantDay");

                                SpriteRenderer renderPlant = plant.GetComponent<SpriteRenderer>();
                                renderPlant.sortingOrder = grass.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;

                            }

                            // Onion
                            else if (plantname == "Onion")
                            {
                                GameObject plant = Instantiate(groundPlants[1]);
                                plant.transform.SetParent(grass.gameObject.transform, false);
                                plant.GetComponent<plantstate>().amountHealth = PlayerPrefs.GetFloat(grass.name + "_hasPlantHealth");
                                plant.GetComponent<plantTimer>().msecs = PlayerPrefs.GetFloat(grass.name + "_hasPlantMsec");
                                plant.GetComponent<plantTimer>().hour = PlayerPrefs.GetInt(grass.name + "_hasPlantHour");
                                plant.GetComponent<plantTimer>().day = PlayerPrefs.GetInt(grass.name + "_hasPlantDay");

                                SpriteRenderer renderPlant = plant.GetComponent<SpriteRenderer>();
                                renderPlant.sortingOrder = grass.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;
                            }

                            // Pumpkin
                            else if (plantname == "Pumpkin")
                            {
                                // Corresponding sprite
                                GameObject plant = Instantiate(groundPlants[2]);
                                plant.transform.SetParent(grass.gameObject.transform, false);
                                plant.GetComponent<plantstate>().amountHealth = PlayerPrefs.GetFloat(grass.name + "_hasPlantHealth");
                                plant.GetComponent<plantTimer>().msecs = PlayerPrefs.GetFloat(grass.name + "_hasPlantMsec");
                                plant.GetComponent<plantTimer>().hour = PlayerPrefs.GetInt(grass.name + "_hasPlantHour");
                                plant.GetComponent<plantTimer>().day = PlayerPrefs.GetInt(grass.name + "_hasPlantDay");

                                SpriteRenderer renderPlant = plant.GetComponent<SpriteRenderer>();
                                renderPlant.sortingOrder = grass.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;
                            }

                            // Radish
                            else if (plantname == "Radishes")
                            {
                                // Corresponding sprite
                                GameObject plant = Instantiate(groundPlants[3]);
                                plant.transform.SetParent(grass.gameObject.transform, false);
                                plant.GetComponent<plantstate>().amountHealth = PlayerPrefs.GetFloat(grass.name + "_hasPlantHealth");
                                plant.GetComponent<plantTimer>().msecs = PlayerPrefs.GetFloat(grass.name + "_hasPlantMsec");
                                plant.GetComponent<plantTimer>().hour = PlayerPrefs.GetInt(grass.name + "_hasPlantHour");
                                plant.GetComponent<plantTimer>().day = PlayerPrefs.GetInt(grass.name + "_hasPlantDay");

                                SpriteRenderer renderPlant = plant.GetComponent<SpriteRenderer>();
                                renderPlant.sortingOrder = grass.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;
                            }

                            // Tomato
                            else if (plantname == "Tomato")
                            {
                                // Corresponding sprite
                                GameObject plant = Instantiate(groundPlants[4]);
                                plant.transform.SetParent(grass.gameObject.transform, false);
                                plant.GetComponent<plantstate>().amountHealth = PlayerPrefs.GetFloat(grass.name + "_hasPlantHealth");
                                plant.GetComponent<plantTimer>().msecs = PlayerPrefs.GetFloat(grass.name + "_hasPlantMsec");
                                plant.GetComponent<plantTimer>().hour = PlayerPrefs.GetInt(grass.name + "_hasPlantHour");
                                plant.GetComponent<plantTimer>().day = PlayerPrefs.GetInt(grass.name + "_hasPlantDay");

                                SpriteRenderer renderPlant = plant.GetComponent<SpriteRenderer>();
                                renderPlant.sortingOrder = grass.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;
                            }

                            // Watermelon
                            else if (plantname == "Watermelon")
                            {
                                // Corresponding sprite
                                GameObject plant = Instantiate(groundPlants[5]);
                                plant.transform.SetParent(grass.gameObject.transform, false);
                                plant.GetComponent<plantstate>().amountHealth = PlayerPrefs.GetFloat(grass.name + "_hasPlantHealth");
                                plant.GetComponent<plantTimer>().msecs = PlayerPrefs.GetFloat(grass.name + "_hasPlantMsec");
                                plant.GetComponent<plantTimer>().hour = PlayerPrefs.GetInt(grass.name + "_hasPlantHour");
                                plant.GetComponent<plantTimer>().day = PlayerPrefs.GetInt(grass.name + "_hasPlantDay");

                                SpriteRenderer renderPlant = plant.GetComponent<SpriteRenderer>();
                                renderPlant.sortingOrder = grass.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;
                            }

                            else
                            {

                            }


                            #endregion

                        }

                        else
                        {

                        }

                    }

                    // If current tile is odd
                    else
                    {
                        grass = Instantiate(objGrass, new Vector2(initialX, newY), objGrass.rotation);
                        render = grass.GetComponent<SpriteRenderer>();

                        grass.name = grass.name + "_" + x.ToString("000") + "_" + y.ToString("000");

                        if (PlayerPrefs.GetInt(grass.name + "_hasChild") == 0)
                        {

                        }

                        else if (PlayerPrefs.GetInt(grass.name + "_hasChild") == 1)
                        {
                            // Generates new farmable tile and makes it the child of the current tile clicked
                            GameObject plot = Instantiate(groundTiles[1]);
                            plot.transform.SetParent(grass.transform, false);
                            SpriteRenderer renderSoil = plot.GetComponent<SpriteRenderer>();
                            renderSoil.sortingOrder = grass.GetComponent<SpriteRenderer>().sortingOrder + 1;

                            plot.GetComponent<characteristics>().isDestroyable = true;
                            plot.GetComponent<soilstate>().amountWater = PlayerPrefs.GetFloat(grass.name + "_hasChildWater");
                            plot.GetComponent<soilstate>().amountFertilizer_Nitorgen = PlayerPrefs.GetFloat(grass.name + "_hasChildNitrogen");
                            plot.GetComponent<soilstate>().amountFertilizer_Phosphorus = PlayerPrefs.GetFloat(grass.name + "_hasChildPhosphorus");
                            plot.GetComponent<soilstate>().amountFertilizer_Potassium = PlayerPrefs.GetFloat(grass.name + "_hasChildPotassium");

                            // Change state of the tile
                            grass.GetComponent<TileDefinition>().type = "soil";
                            grass.GetComponent<TileDefinition>().isBuildable = false;
                            grass.GetComponent<TileDefinition>().isFarmable = true;
                        }

                        else if (PlayerPrefs.GetInt(grass.name + "_hasChild") == 2)
                        {
                            #region Soil

                            // Generates new farmable tile and makes it the child of the current tile clicked
                            GameObject plot = Instantiate(groundTiles[1]);
                            plot.transform.SetParent(grass.transform, false);
                            SpriteRenderer renderSoil = plot.GetComponent<SpriteRenderer>();
                            renderSoil.sortingOrder = grass.GetComponent<SpriteRenderer>().sortingOrder + 1;

                            plot.GetComponent<characteristics>().isDestroyable = false;
                            plot.GetComponent<soilstate>().amountWater = PlayerPrefs.GetFloat(grass.name + "_hasChildWater");
                            plot.GetComponent<soilstate>().amountFertilizer_Nitorgen = PlayerPrefs.GetFloat(grass.name + "_hasChildNitrogen");
                            plot.GetComponent<soilstate>().amountFertilizer_Phosphorus = PlayerPrefs.GetFloat(grass.name + "_hasChildPhosphorus");
                            plot.GetComponent<soilstate>().amountFertilizer_Potassium = PlayerPrefs.GetFloat(grass.name + "_hasChildPotassium");

                            // Change state of the tile
                            grass.GetComponent<TileDefinition>().type = "plant";
                            grass.GetComponent<TileDefinition>().isBuildable = false;
                            grass.GetComponent<TileDefinition>().isFarmable = false;

                            #endregion

                            #region Plants

                            // Generate plants
                            plantname = PlayerPrefs.GetString(grass.name + "_hasPlant");

                            // Carrot
                            if (plantname == "Carrot")
                            {
                                // Corresponding sprite
                                GameObject plant = Instantiate(groundPlants[0]);
                                plant.transform.SetParent(grass.gameObject.transform, false);
                                plant.GetComponent<plantstate>().amountHealth = PlayerPrefs.GetFloat(grass.name + "_hasPlantHealth");
                                plant.GetComponent<plantTimer>().msecs = PlayerPrefs.GetFloat(grass.name + "_hasPlantMsec");
                                plant.GetComponent<plantTimer>().hour = PlayerPrefs.GetInt(grass.name + "_hasPlantHour");
                                plant.GetComponent<plantTimer>().day = PlayerPrefs.GetInt(grass.name + "_hasPlantDay");

                                SpriteRenderer renderPlant = plant.GetComponent<SpriteRenderer>();
                                renderPlant.sortingOrder = grass.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;
                            }

                            // Onion
                            else if (plantname == "Onion")
                            {
                                GameObject plant = Instantiate(groundPlants[1]);
                                plant.transform.SetParent(grass.gameObject.transform, false);
                                plant.GetComponent<plantstate>().amountHealth = PlayerPrefs.GetFloat(grass.name + "_hasPlantHealth");
                                plant.GetComponent<plantTimer>().msecs = PlayerPrefs.GetFloat(grass.name + "_hasPlantMsec");
                                plant.GetComponent<plantTimer>().hour = PlayerPrefs.GetInt(grass.name + "_hasPlantHour");
                                plant.GetComponent<plantTimer>().day = PlayerPrefs.GetInt(grass.name + "_hasPlantDay");

                                SpriteRenderer renderPlant = plant.GetComponent<SpriteRenderer>();
                                renderPlant.sortingOrder = grass.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;
                            }

                            // Pumpkin
                            else if (plantname == "Pumpkin")
                            {
                                // Corresponding sprite
                                GameObject plant = Instantiate(groundPlants[2]);
                                plant.transform.SetParent(grass.gameObject.transform, false);
                                plant.GetComponent<plantstate>().amountHealth = PlayerPrefs.GetFloat(grass.name + "_hasPlantHealth");
                                plant.GetComponent<plantTimer>().msecs = PlayerPrefs.GetFloat(grass.name + "_hasPlantMsec");
                                plant.GetComponent<plantTimer>().hour = PlayerPrefs.GetInt(grass.name + "_hasPlantHour");
                                plant.GetComponent<plantTimer>().day = PlayerPrefs.GetInt(grass.name + "_hasPlantDay");

                                SpriteRenderer renderPlant = plant.GetComponent<SpriteRenderer>();
                                renderPlant.sortingOrder = grass.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;
                            }

                            // Radish
                            else if (plantname == "Radishes")
                            {
                                // Corresponding sprite
                                GameObject plant = Instantiate(groundPlants[3]);
                                plant.transform.SetParent(grass.gameObject.transform, false);
                                plant.GetComponent<plantstate>().amountHealth = PlayerPrefs.GetFloat(grass.name + "_hasPlantHealth");
                                plant.GetComponent<plantTimer>().msecs = PlayerPrefs.GetFloat(grass.name + "_hasPlantMsec");
                                plant.GetComponent<plantTimer>().hour = PlayerPrefs.GetInt(grass.name + "_hasPlantHour");
                                plant.GetComponent<plantTimer>().day = PlayerPrefs.GetInt(grass.name + "_hasPlantDay");

                                SpriteRenderer renderPlant = plant.GetComponent<SpriteRenderer>();
                                renderPlant.sortingOrder = grass.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;
                            }

                            // Tomato
                            else if (plantname == "Tomato")
                            {
                                // Corresponding sprite
                                GameObject plant = Instantiate(groundPlants[4]);
                                plant.transform.SetParent(grass.gameObject.transform, false);
                                plant.GetComponent<plantstate>().amountHealth = PlayerPrefs.GetFloat(grass.name + "_hasPlantHealth");
                                plant.GetComponent<plantTimer>().msecs = PlayerPrefs.GetFloat(grass.name + "_hasPlantMsec");
                                plant.GetComponent<plantTimer>().hour = PlayerPrefs.GetInt(grass.name + "_hasPlantHour");
                                plant.GetComponent<plantTimer>().day = PlayerPrefs.GetInt(grass.name + "_hasPlantDay");

                                SpriteRenderer renderPlant = plant.GetComponent<SpriteRenderer>();
                                renderPlant.sortingOrder = grass.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;
                            }

                            // Watermelon
                            else if (plantname == "Watermelon")
                            {
                                // Corresponding sprite
                                GameObject plant = Instantiate(groundPlants[5]);
                                plant.transform.SetParent(grass.gameObject.transform, false);
                                plant.GetComponent<plantstate>().amountHealth = PlayerPrefs.GetFloat(grass.name + "_hasPlantHealth");
                                plant.GetComponent<plantTimer>().msecs = PlayerPrefs.GetFloat(grass.name + "_hasPlantMsec");
                                plant.GetComponent<plantTimer>().hour = PlayerPrefs.GetInt(grass.name + "_hasPlantHour");
                                plant.GetComponent<plantTimer>().day = PlayerPrefs.GetInt(grass.name + "_hasPlantDay");

                                SpriteRenderer renderPlant = plant.GetComponent<SpriteRenderer>();
                                renderPlant.sortingOrder = grass.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;
                            }

                            else
                            {

                            }


                            #endregion

                        }

                        else
                        {

                        }
                    }
                }
            }
        }

        else
        {
            // Populate world space with tile sprites in an X x Y axis 
            for (int x = 0; x < 40; x++)
            {
                initialX += (offsetX + 1);

                for (int y = 1; y < 41; y++)
                {
                    newY = initialY - (offsetY + (y - 1));

                    // If current tile is even
                    if (y % 2 == 0)
                    {
                        newX = initialX + 1f;

                        grass = Instantiate(objGrass, new Vector2(newX, newY), objGrass.rotation);
                        render = grass.GetComponent<SpriteRenderer>();

                        grass.name = grass.name + "_" + x.ToString("000") + "_" + y.ToString("000");

                        // Record position of the tile
                        PlayerPrefs.SetFloat(grass.name + "_posX", this.gameObject.transform.position.x);
                        PlayerPrefs.SetFloat(grass.name + "_posY", this.gameObject.transform.position.y);

                        // Record things instantiated on the tiles
                        // Soil
                        PlayerPrefs.SetInt(grass.name + "_hasChild", 0);
                        PlayerPrefs.SetFloat(grass.name + "_hasChildWater", 0);
                        PlayerPrefs.SetFloat(grass.name + "_hasChildNitrogen", 0);
                        PlayerPrefs.SetFloat(grass.name + "_hasChildPhosphorus", 0);
                        PlayerPrefs.SetFloat(grass.name + "_hasChildPotassium", 0);

                        // Plant
                        PlayerPrefs.SetString(grass.name + "_hasPlant", "");

                    }

                    // If current tile is odd
                    else
                    {
                        grass = Instantiate(objGrass, new Vector2(initialX, newY), objGrass.rotation);
                        render = grass.GetComponent<SpriteRenderer>();

                        grass.name = grass.name + "_" + x.ToString("000") + "_" + y.ToString("000");

                        // Record position of the tile
                        PlayerPrefs.SetFloat(grass.name + "_posX", this.gameObject.transform.position.x);
                        PlayerPrefs.SetFloat(grass.name + "_posY", this.gameObject.transform.position.y);

                        // Record things instantiated on the tiles
                        // Soil
                        PlayerPrefs.SetInt(grass.name + "_hasChild", 0);
                        PlayerPrefs.SetFloat(grass.name + "_hasChildWater", 0);
                        PlayerPrefs.SetFloat(grass.name + "_hasChildNitrogen", 0);
                        PlayerPrefs.SetFloat(grass.name + "_hasChildPhosphorus", 0);
                        PlayerPrefs.SetFloat(grass.name + "_hasChildPotassium", 0);

                        // Plant
                        PlayerPrefs.SetString(grass.name + "_hasPlant", "");

                    }
                }
            }
        }
    }

    void createTutorial()
    {
        if (authenticate.tutorial == true) {
            switch (buttonFunctions.tutorialCT)
            {
                case 201:
                    speechbubbles[0].SetActive(false);
                    GameObject.Find("playTool").GetComponent<Button>().interactable = true;
                    GameObject.Find("play-Tool_Default").GetComponent<Button>().interactable = true;
                    GameObject.Find("play-Tool_Fertilizer").GetComponent<Button>().interactable = true;
                    GameObject.Find("play-Tool_Water").GetComponent<Button>().interactable = true;
                    GameObject.Find("play-Tool_Cultivate").GetComponent<Button>().interactable = true;
                    GameObject.Find("play-Tool_Harvest").GetComponent<Button>().interactable = true;
                    GameObject.Find("play-Tool_Recycle").GetComponent<Button>().interactable = true;
                    GameObject.Find("playPlant").GetComponent<Button>().interactable = true;
                    GameObject.Find("play-Plant_Carrot").GetComponent<Button>().interactable = true;
                    GameObject.Find("play-Plant_Onion").GetComponent<Button>().interactable = true;
                    GameObject.Find("play-Plant_Pumpkin").GetComponent<Button>().interactable = true;
                    GameObject.Find("play-Plant_Radish").GetComponent<Button>().interactable = true;
                    GameObject.Find("play-Plant_Tomato").GetComponent<Button>().interactable = true;
                    GameObject.Find("play-Plant_Watermelon").GetComponent<Button>().interactable = true;
                    GameObject.Find("icon-options").GetComponent<Button>().interactable = true;
                    GameObject.Find("icon-help").GetComponent<Button>().interactable = true;
                    GameObject.Find("icon-logout").GetComponent<Button>().interactable = true;
                    break;
                case 200:
                    speechbubbles[0].SetActive(true);
                    break;
                case 199:
                    speechbubbles[1].SetActive(true);
                    speechbubbles[0].SetActive(false);
                    break;
                case 198:
                    speechbubbles[2].SetActive(true);
                    speechbubbles[1].SetActive(false);
                    break;
                case 197:
                    speechbubbles[3].SetActive(true);
                    speechbubbles[2].SetActive(false);
                    break;
                case 196:
                    speechbubbles[4].SetActive(true);
                    speechbubbles[3].SetActive(false);
                    break;
                case 195:
                    GameObject.Find("playTool").GetComponent<Button>().interactable = true;
                    speechbubbles[5].SetActive(true);
                    speechbubbles[4].SetActive(false);
                    break;
                case 194:
                    GameObject.Find("play-Tool_Default").GetComponent<Button>().interactable = true;
                    speechbubbles[6].SetActive(true);
                    speechbubbles[5].SetActive(false);
                    break;
                case 193:
                    GameObject.Find("play-Tool_Fertilizer").GetComponent<Button>().interactable = true;
                    speechbubbles[7].SetActive(true);
                    speechbubbles[6].SetActive(false);
                    break;
                case 192:
                    GameObject.Find("play-Tool_Water").GetComponent<Button>().interactable = true;
                    speechbubbles[8].SetActive(true);
                    speechbubbles[7].SetActive(false);
                    break;
                case 191:
                    GameObject.Find("play-Tool_Cultivate").GetComponent<Button>().interactable = true;
                    speechbubbles[9].SetActive(true);
                    speechbubbles[8].SetActive(false);
                    break;
                case 190:
                    GameObject.Find("play-Tool_Harvest").GetComponent<Button>().interactable = true;
                    speechbubbles[10].SetActive(true);
                    speechbubbles[9].SetActive(false);
                    break;
                case 189:
                    GameObject.Find("play-Tool_Recycle").GetComponent<Button>().interactable = true;
                    speechbubbles[11].SetActive(true);
                    speechbubbles[10].SetActive(false);
                    break;
                case 188:
                    GameObject.Find("playPlant").GetComponent<Button>().interactable = true;
                    speechbubbles[12].SetActive(true);
                    speechbubbles[11].SetActive(false);
                    break;
                case 187:
                    GameObject.Find("play-Plant_Carrot").GetComponent<Button>().interactable = true;
                    speechbubbles[13].SetActive(true);
                    speechbubbles[12].SetActive(false);
                    break;
                case 186:
                    GameObject.Find("play-Plant_Onion").GetComponent<Button>().interactable = true;
                    speechbubbles[14].SetActive(true);
                    speechbubbles[13].SetActive(false);
                    break;
                case 185:
                    GameObject.Find("play-Plant_Pumpkin").GetComponent<Button>().interactable = true;
                    speechbubbles[15].SetActive(true);
                    speechbubbles[14].SetActive(false);
                    break;
                case 184:
                    GameObject.Find("play-Plant_Radish").GetComponent<Button>().interactable = true;
                    speechbubbles[16].SetActive(true);
                    speechbubbles[15].SetActive(false);
                    break;
                case 183:
                    GameObject.Find("play-Plant_Tomato").GetComponent<Button>().interactable = true;
                    speechbubbles[17].SetActive(true);
                    speechbubbles[16].SetActive(false);
                    break;
                case 182:
                    GameObject.Find("play-Plant_Watermelon").GetComponent<Button>().interactable = true;
                    speechbubbles[18].SetActive(true);
                    speechbubbles[17].SetActive(false);
                    break;
                case 181:
                    speechbubbles[19].SetActive(true);
                    speechbubbles[18].SetActive(false);
                    break;
                case 180:
                    speechbubbles[20].SetActive(true);
                    speechbubbles[19].SetActive(false);
                    break;
                case 179:
                    speechbubbles[21].SetActive(true);
                    speechbubbles[20].SetActive(false);
                    break;
                case 178:
                    speechbubbles[22].SetActive(true);
                    speechbubbles[21].SetActive(false);
                    break;
                case 177:
                    speechbubbles[23].SetActive(true);
                    speechbubbles[22].SetActive(false);
                    break;
                case 176:
                    speechbubbles[24].SetActive(true);
                    speechbubbles[23].SetActive(false);
                    break;
                case 175:
                    speechbubbles[25].SetActive(true);
                    speechbubbles[24].SetActive(false);
                    break;
                case 174:
                    GameObject.Find("icon-options").GetComponent<Button>().interactable = true;
                    speechbubbles[198].SetActive(true);
                    speechbubbles[25].SetActive(false);
                    break;
                /*
                case 173:
                    GameObject.Find("icon-help").GetComponent<Button>().interactable = true;
                    speechbubbles[198].SetActive(false);
                    break;
                */
                case 173:
                    GameObject.Find("icon-logout").GetComponent<Button>().interactable = true;
                    speechbubbles[199].SetActive(true);
                    speechbubbles[198].SetActive(false);
                    break;
                case 172:
                    speechbubbles[199].SetActive(false);
                    authenticate.tutorial = false;
                    break;
                default:
                    break;
            }
        }
        else { }

        Debug.Log(buttonFunctions.tutorialCT);
    }

    void Update()
    {
        createTutorial();
    }
}
