/*
 * 
 * Author: Gabriel Hansley Suarez
 * Date Created: December 22, 2018
 * Source: 
 * 
 * Modified by: Gabriel Hansley Suarez
 * Date Modified: December 22, 2018
 * Last Date Modified: December 22, 2018
 * 
 * Contributors:
 * 
 * Credits: -----------
 * 
 * License: 
 * 
 * Note: Some useless script that characterizes the plant game objects
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class plantstate : MonoBehaviour {

    GameObject plantInfoParent, plantInfoPanel;

    #region Growth variables of the plant
    /* STAGES and corresponding SPRITES
    *   1 - seed
    *   2 - immature
    *   3 - plant
    *   4 - mature
    *   5 - decay
    *  Harvestable state is at stage 3 and 4 */
    public int growthStage;
    public Sprite[] nextStageImage;

    // TIME
    public int growthTime;

    // TIME LIVED
    private int timeLived;
    private float growthTimeMature_1;
    private float growthTimeMature_2;
    private float growthTimeMature_3;
    private float growthTimeMature_4;
    private float growthTimeMature_5;
    private int timeLeft;

    // Other dependency variables
    private float amountHealth;
    private float amountWater;
    private float fNitrogen, fPhosphorus, fPotassium;

    #endregion

    // Defines what kind of plant
    public string plantName;

    private bool hasPest;

    void Start()
    {
        plantInfoParent = GameObject.Find("menuPlantInfoContainer");
        plantInfoPanel = plantInfoParent.transform.Find("menuPlantInfoPanel").gameObject;

        // Set all plant to birth + immature stage
        growthStage = 0;
        amountHealth = 100;
        amountWater = 0;
        fNitrogen = 0;
        fPhosphorus = 0;
        fPotassium = 0;
        timeLeft = growthTime;
        hasPest = false;

        // Time at which the plant changes state
        growthTimeMature_1 = Mathf.Floor(growthTime / 4) * 1;
        growthTimeMature_2 = Mathf.Floor(growthTime / 4) * 2;
        growthTimeMature_3 = Mathf.Floor(growthTime / 4) * 3;
        growthTimeMature_4 = growthTime;
        growthTimeMature_5 = growthTime * 2;

    }

    // Update is called once per frame
    void Update () {

        #region Declaration

        // Define plant timer
        timeLived = this.gameObject.GetComponent<plantTimer>().day;

        #endregion

        if (timeLived == growthTimeMature_1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = nextStageImage[0];
            growthStage = 1;
        }
        else if (timeLived == growthTimeMature_2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = nextStageImage[1];
            growthStage = 2;
        }
        else if (timeLived == growthTimeMature_3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = nextStageImage[2];
            growthStage = 3;
        }
        else if (timeLived == growthTimeMature_5)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = nextStageImage[3];
            growthStage = 4;
        }

        amountWater = this.gameObject.transform.parent.GetComponentInChildren<soilstate>().amountWater;
        fNitrogen = this.gameObject.transform.parent.GetComponentInChildren<soilstate>().amountFertilizer_Nitorgen;
        fPhosphorus = this.gameObject.transform.parent.GetComponentInChildren<soilstate>().amountFertilizer_Phosphorus;
        fPotassium = this.gameObject.transform.parent.GetComponentInChildren<soilstate>().amountFertilizer_Potassium;

        // Check if there is pest on the plant object
        if (hasPest && amountHealth > 0)
        {
            amountHealth -= 0.05f * Time.deltaTime;
        }
    }

    void OnMouseDown()
    {
        if (pInteractions.currentTool == "action-None")
        {
            plantInfoPanel.SetActive(true);

            // Update soil properties
            plantInfo.waterbarValue = amountWater;

            plantInfo.fNitrogen = fNitrogen;
            plantInfo.fPhosphorus = fPhosphorus;
            plantInfo.fPotassium = fPotassium;

            // Update plant properties
            plantInfo.plantNameText = plantName;
            plantInfo.healthbarValue = amountHealth;
            plantInfo.harvestTimeLeft = timeLeft;

            if (timeLived < growthTimeMature_4)
            {
                timeLeft = growthTime - timeLived;
            }
            else
            {
                timeLeft = 0;
            }
        }
            
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pest"))
        {
            hasPest = true;
            Debug.Log("ALERT! Pest invasion.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pest"))
        {
            hasPest = false;
            Debug.Log("Pest is gone.");
        }
    }

}