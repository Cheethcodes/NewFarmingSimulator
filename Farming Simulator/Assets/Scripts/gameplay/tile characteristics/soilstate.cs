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
 * Note: Some useless script that characterizes the soil game objects
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.RainMaker;

public class soilstate : MonoBehaviour {

    // Identify rain
    private RainScript2D rainOccurrence;
    private float rainWater;

    // Component variables of the soil tile
    public float amountWater;
    public float amountFertilizer_Nitorgen;
    public float amountFertilizer_Potassium;
    public float amountFertilizer_Phosphorus;

    // Decay speed of each soil component variable
    float decayWater;
    float decayFertilizer_Nitrogen;
    float decayFertilizer_Potassium;
    float decayFertilizer_Phosphorus;

    string soilID;

    void Start()
    {
        rainOccurrence = GameObject.Find("RainPrefab2D").GetComponent<RainScript2D>();

        soilID = this.gameObject.transform.parent.name;
    }

    void Update()
    {
        #region Declaration

        decayWater = Random.Range(0.01f, 0.2f);
        decayFertilizer_Nitrogen = Random.Range(0.0001f, 0.0005f);
        decayFertilizer_Potassium = Random.Range(0.0001f, 0.0005f);
        decayFertilizer_Phosphorus = Random.Range(0.0001f, 0.0005f);

        rainWater = rainOccurrence.RainIntensity;

        #endregion

        // Decrease amount of water due to evaporation
        if (amountWater > 0)
        {
            amountWater -= Time.deltaTime * decayWater;
        }

        // Decrease amount of fertilizer components overtime - Nitrogen
        if (amountFertilizer_Nitorgen > 0)
        {
            amountFertilizer_Nitorgen -= Time.deltaTime * decayFertilizer_Nitrogen;
        }

        // Decrease amount of fertilizer components overtime - Phosphorus
        if (amountFertilizer_Phosphorus > 0)
        {
            amountFertilizer_Phosphorus -= Time.deltaTime * decayFertilizer_Phosphorus;
        }

        // Decrease amount of fertilizer components overtime - Potassium
        if (amountFertilizer_Potassium > 0)
        {
            amountFertilizer_Potassium -= Time.deltaTime * decayFertilizer_Potassium;
        }

        // Increase amoung of water base on the rainfall that will occur
        if (rainWater > 0)
        {
            amountWater += rainWater;
        }

        amountWater = Mathf.Clamp(amountWater, 0, 100);

        PlayerPrefs.SetFloat(soilID + "_hasChildWater", amountWater);
        PlayerPrefs.SetFloat(soilID + "_hasChildNitrogen", amountFertilizer_Nitorgen);
        PlayerPrefs.SetFloat(soilID + "_hasChildPhosphorus", amountFertilizer_Phosphorus);
        PlayerPrefs.SetFloat(soilID + "_hasChildPotassium", amountFertilizer_Potassium);

    }

}
