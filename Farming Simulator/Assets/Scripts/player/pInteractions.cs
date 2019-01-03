/*
 * 
 * Author: Gabriel Hansley Suarez
 * Date Created: December 20, 2018
 * Source: 
 * 
 * Modified by: Gabriel Hansley Suarez
 * Date Modified: December 20, 2018
 * Last Date Modified: December 20, 2018
 * 
 * Contributors:
 * 
 * Credits: -----------
 * 
 * License: 
 * 
 * Note: Actions that player can execute inside the game
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class pInteractions : MonoBehaviour {

    #region Score and Money

    public static int temp_scoreValue = 0;

    #endregion

    #region Tile definitions

    // Ground tile objects
    public GameObject[] groundTiles;
    public GameObject[] groundPlants;

    // Current action of the player
    public static string currentTool;

    // Current grass tile state
    private string Type;
    private bool isBuildable, isFarmable;

    #endregion

    private string[] ncurrentTool;

    void Start()
    {
        // Initialize player action
        currentTool = "action-None";

        // Initialize tile status
        Type = this.gameObject.GetComponent<TileDefinition>().type;
        isFarmable = this.gameObject.GetComponent<TileDefinition>().isFarmable;
        isBuildable = this.gameObject.GetComponent<TileDefinition>().isBuildable;
    }

    void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) { 
            ncurrentTool = currentTool.Split('-');

            // Read what option the player chooses to be his / her action
            switch (ncurrentTool[1])
            {
                // When player picks up rake
                case "Cultivate":
                    if (dataCont.moneyValue >= 5)
                    {
                        if (Type == "grass")
                        {
                            execCultivate();
                        }
                        else
                        {
                            Debug.Log("Already cultivated!");
                        }
                    }
                    else
                    {
                        Debug.Log("Not enough money");
                    }
                    break;
            
                // When player picks up any seeds to be planted
                case "Plant":
                    if (Type == "soil")
                    {
                        execPlant();
                    }
                    else if (Type == "plant")
                    {
                        Debug.Log("Plot already planted!");
                    }
                    else
                    {
                        Debug.Log("Plot needs to be cultivated first!");
                    }
                    break;
            
                // When player picks up the scythe
                case "Harvest":
                    if (Type == "plant")
                    {
                        execHarvest();
                    }
                    else
                    {
                        Debug.Log("There is no available plants in this area!");
                    }
                    break;

                // When player picks up the pail
                case "Water":
                    if (Type == "plant" || Type == "soil")
                    {
                        execWater();
                    }
                    else
                    {
                        Debug.Log("No are for water to be applied!");
                    }
                    break;

                case "Fertilize":
                    if (Type == "plant" || Type == "soil")
                    {
                        execFertilize();
                    }
                    else
                    {
                        Debug.Log("No area for fertilizer to be applied.");
                    }
                    break;

                // When player picks up recycle tool
                case "Sell":
                    execRecycle();
                    break;

                case "Build":
                    execBuild();
                    break;

                default:
                    break;
            }
        }
    }

    #region Cultivate method

    // Player cultivates the tile
    void execCultivate()
    {
        // Generates new farmable tile and makes it the child of the current tile clicked
        GameObject plot = Instantiate(groundTiles[1]);
        plot.transform.SetParent(this.gameObject.transform, false);
        SpriteRenderer render = plot.GetComponent<SpriteRenderer>();
        render.sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
        dataCont.moneyValue -= 5;

        // Change state of the tile
        Type = "soil";

        isBuildable = false;
        //this.gameObject.GetComponent<TileDefinition>().isBuildable = false;

        isFarmable = true;
        //this.gameObject.GetComponent<TileDefinition>().isFarmable = true;
    }

    #endregion

    #region Plant method

    // Player plants an object on a tile
    void execPlant()
    {
        // Change state of the tile
        Type = "plant";
        isBuildable = false;
        isFarmable = false;

        // Carrot
        if (ncurrentTool[2] == "Carrot")
        {
            // Corresponding sprite
            GameObject plant = Instantiate(groundPlants[0]);
            plant.transform.SetParent(this.gameObject.transform, false);

            SpriteRenderer render = plant.GetComponent<SpriteRenderer>();
            render.sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;

            // Cost
            dataCont.moneyValue -= 15;
        }

        // Onion
        else if (ncurrentTool[2] == "Onion")
        {
            GameObject plant = Instantiate(groundPlants[1]);
            plant.transform.SetParent(this.gameObject.transform, false);

            SpriteRenderer render = plant.GetComponent<SpriteRenderer>();
            render.sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;

            // Cost
            dataCont.moneyValue -= 5;
        }

        // Pumpkin
        else if (ncurrentTool[2] == "Pumpkin")
        {
            // Corresponding sprite
            GameObject plant = Instantiate(groundPlants[2]);
            plant.transform.SetParent(this.gameObject.transform, false);

            SpriteRenderer render = plant.GetComponent<SpriteRenderer>();
            render.sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;

            // Cost
            dataCont.moneyValue -= 50;
        }

        // Radish
        else if (ncurrentTool[2] == "Radishes")
        {
            // Corresponding sprite
            GameObject plant = Instantiate(groundPlants[3]);
            plant.transform.SetParent(this.gameObject.transform, false);

            SpriteRenderer render = plant.GetComponent<SpriteRenderer>();
            render.sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;

            // Cost
            dataCont.moneyValue -= 15;
        }

        // Tomato
        else if (ncurrentTool[2] == "Tomato")
        {
            // Corresponding sprite
            GameObject plant = Instantiate(groundPlants[4]);
            plant.transform.SetParent(this.gameObject.transform, false);

            SpriteRenderer render = plant.GetComponent<SpriteRenderer>();
            render.sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;

            // Cost
            dataCont.moneyValue -= 10;
        }

        // Watermelon
        else if (ncurrentTool[2] == "Watermelon")
        {
            // Corresponding sprite
            GameObject plant = Instantiate(groundPlants[5]);
            plant.transform.SetParent(this.gameObject.transform, false);

            SpriteRenderer render = plant.GetComponent<SpriteRenderer>();
            render.sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;

            // Cost
            dataCont.moneyValue -= 40;
        }

        else
        {

        }
    }

    #endregion

    #region Water emthod

    // Player waters the tile
    void execWater()
    {
        if (generalMethods.FindGameObjectInChildWithTag(this.gameObject, "soil") != null)
        {
            this.gameObject.GetComponentInChildren<soilstate>().amountWater = 100;
        }
        else
        {
            Debug.Log("No area for water to be applied.");
        }
    }

    #endregion

    #region Fertilize methods

    // Player fertilized the tile
    void execFertilize()
    {
        if (generalMethods.FindGameObjectInChildWithTag(this.gameObject, "soil") != null)
        {
            this.gameObject.GetComponentInChildren<soilstate>().amountFertilizer_Nitorgen = 1.0000f;
            this.gameObject.GetComponentInChildren<soilstate>().amountFertilizer_Phosphorus = 5.000f;
            this.gameObject.GetComponentInChildren<soilstate>().amountFertilizer_Potassium = 10.000f;

            dataCont.moneyValue -= 10;
        }
        else
        {
            Debug.Log("No area for fertilizer to be applied.");
        }

    }

    #endregion

    #region Harvest methods

    // Player harvests a tile
    void execHarvest()
    {
        // Get parent
        Transform parentContainer = this.gameObject.transform;

        int harvestState = execHarvestStage(execHarvestState(execHarvestCount(parentContainer)), parentContainer);

        if (harvestState == 3)
        {
            foreach (Transform child in parentContainer)
            {
                if (child.tag == "plant")
                {
                    // Get plant name
                    string plantName = child.GetComponent<plantstate>().plantName;

                    // Carrot
                    if (plantName == "carrot")
                    {
                        dataCont.moneyValue += 40;
                        dataCont.scoreValue += 20;
                        temp_scoreValue += 20;
                    }

                    // Onion
                    else if (plantName == "onion")
                    {
                        dataCont.moneyValue += 70;
                        dataCont.scoreValue += 30;
                        temp_scoreValue += 30;
                    }

                    // Pumpkin
                    else if (plantName == "pumpkin")
                    {
                        dataCont.moneyValue += 120;
                        dataCont.scoreValue += 60;
                        temp_scoreValue += 60;
                    }

                    // Radish
                    else if (plantName == "radish")
                    {
                        dataCont.moneyValue += 40;
                        dataCont.scoreValue += 20;
                        temp_scoreValue += 20;
                    }

                    // Tomato
                    else if (plantName == "tomato")
                    {
                        dataCont.moneyValue += 30;
                        dataCont.scoreValue += 10;
                        temp_scoreValue += 10;
                    }

                    // Watermelon
                    else if (plantName == "watermelon")
                    {
                        dataCont.moneyValue += 150;
                        dataCont.scoreValue += 70;
                        temp_scoreValue += 70;
                    }

                }

                // Destroy all objects contained within the parent object
                GameObject.Destroy(child.gameObject);
            }

            // Change state of the tile 
            Type = "grass";
            isBuildable = false;
            isFarmable = false;

        }
        else
        {
            Debug.Log("no plant or plant is not ready for harvest");
        }
    }

    // Count how many game objects with "plat" tag exist in the current parent object
    private int execHarvestCount(Transform parentContainer)
    {
        int counter = 0;

        // Check if there is an object with tag "plant"
        foreach (Transform child in parentContainer)
        {
            if (child.tag == "plant")
                // Add 1 to counter if an object with tag "plant" is found within the parent
                counter += 1;
            else
                counter += 0;
        }

        return counter;
    }

    // CHeck if the plant is ready for harvest
    private bool execHarvestState(int x)
    {
        if (x == 1)
            return true;
        else
            return false;
    }

    private int execHarvestStage(bool x, Transform parentContainer)
    {
        int growthStage = 0;

        if (x == true)
        {

            foreach (Transform child in parentContainer)
            {
                if (child.tag == "plant")
                {
                    growthStage += child.gameObject.GetComponent<plantstate>().growthStage;
                }
                else
                {
                    growthStage = 0;
                }
            }

            return growthStage;
        }

        else
        {
            return growthStage = 0;
        }
    }

    #endregion

    #region Build method

    // When player builds a structure on a tile
    void execBuild()
    {

    }

    #endregion

    #region Recycle method

    // Player recycles
    void execRecycle()
    {
        // Count how many child object the parent has
        int ct = this.gameObject.transform.childCount;
        
        // If parent object has more than 1 child
        if (ct >= 1)
        {
            // Loops through all child found in the parent
            foreach (Transform child in transform)
            {
                // Detects child with tag - "soil"
                if (child.CompareTag("soil"))
                {
                    // Gets tile definition
                    characteristics ds = child.GetComponent<characteristics>();

                    // If definition script has destroyable variable set to true
                    if (ds.isDestroyable == true)
                    {
                        // Destroys child object
                        GameObject.Destroy(child.gameObject);

                        // Resets ground properties
                        Type = "grass";
                        isFarmable = false;
                    }

                    // If definition script has destroyable variable set to false
                    // This may be because there exists a child in the current child in which the variable destroyable is set to false
                    else {
                        Debug.Log("Object cannot be destroyed! Something is planted / built here.");
                    }
                }

                // Detects child with tag - "building"
                else if (child.CompareTag("building"))
                {

                }

                // If none of the above mentioned tags are present
                else {
                    Debug.Log("Objects not recyclable!");
                }
            }
        }

        // if parent object has no child
        else
        {
            Debug.Log("No destroyable or sellable object!");
        }
    }

    #endregion

}
