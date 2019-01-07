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

public class GameMgr : MonoBehaviour {

    #region Game initialization module

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

    #endregion

    void Start()
    {
        // Fill in details and instructions for help menu context
        //helptextContainer = GameObject.Find("helpmenucontext").GetComponent<Text>();
        helptextContainer.text = "HOW TO PLAY THE GAME";

        if (PlayerPrefs.HasKey("grass(Clone)_000_001_posX"))
        {
            Debug.Log("Loading existing save file data");

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

        //PlayerPrefs.DeleteAll();
    }
}
