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

public class soilstate : MonoBehaviour {

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

    void Update()
    {
        #region Declaration

        decayWater = Random.Range(0.01f, 0.2f);
        decayFertilizer_Nitrogen = Random.Range(0.0001f, 0.0005f);
        decayFertilizer_Potassium = Random.Range(0.0001f, 0.0005f);
        decayFertilizer_Phosphorus = Random.Range(0.0001f, 0.0005f);

        #endregion

        if (amountWater > 0)
        {
            amountWater -= Time.deltaTime * decayWater;
        }

        if (amountFertilizer_Nitorgen > 0)
        {
            amountFertilizer_Nitorgen -= Time.deltaTime * decayFertilizer_Nitrogen;
        }

        if (amountFertilizer_Phosphorus > 0)
        {
            amountFertilizer_Phosphorus -= Time.deltaTime * decayFertilizer_Phosphorus;
        }

        if (amountFertilizer_Potassium > 0)
        {
            amountFertilizer_Potassium -= Time.deltaTime * decayFertilizer_Potassium;
        }
    }

}
