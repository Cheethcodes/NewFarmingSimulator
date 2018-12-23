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
    float decayWater = 0.04f;
    float decayFertilizer_Nitrogen = 0.01f;
    float decayFertilizer_Potassium = 0.01f;
    float decayFertilizer_Phosphorus = 0.01f;

    void Update()
    {
        if (amountWater > 0)
        {
            amountWater -= Time.deltaTime * decayWater;
        }
    }

}
