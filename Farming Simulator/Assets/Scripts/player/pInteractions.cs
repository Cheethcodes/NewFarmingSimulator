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

public class pInteractions : MonoBehaviour {

    #region Score and Money

    public static int temp_scoreValue;

    #endregion

    #region Tile definitions

    // Ground tile objects
    public GameObject[] groundTiles;
    public GameObject[] groundPlants;

    // TileDefinition object
    public TileDefinition TileDef;

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
        Type = TileDef.type;
        isFarmable = TileDef.isFarmable;
        isBuildable = TileDef.isBuildable;
    }

    void OnMouseDown()
    {
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

            default:
                break;
        }
    }

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
        isFarmable = true;
    }

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

        // Pumpkin
        else if (ncurrentTool[2] == "Pumpkin")
        {
            // Corresponding sprite
            GameObject plant = Instantiate(groundPlants[1]);
            plant.transform.SetParent(this.gameObject.transform, false);

            SpriteRenderer render = plant.GetComponent<SpriteRenderer>();
            render.sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;

            // Cost
            dataCont.moneyValue -= 50;
        }

        // Radishes
        else if (ncurrentTool[2] == "Radishes")
        {
            // Corresponding sprite
            GameObject plant = Instantiate(groundPlants[2]);
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
            GameObject plant = Instantiate(groundPlants[3]);
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
            GameObject plant = Instantiate(groundPlants[4]);
            plant.transform.SetParent(this.gameObject.transform, false);

            SpriteRenderer render = plant.GetComponent<SpriteRenderer>();
            render.sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 2;

            // Cost
            dataCont.moneyValue -= 30;
        }

        else
        {

        }
    }

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

    // Player harvests a tile
    void execHarvest()
    {
        // Change state of the tile 
        Type = "grass";
        isBuildable = false;
        isFarmable = false;

        // Clears anything that the tile contains
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

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

}
