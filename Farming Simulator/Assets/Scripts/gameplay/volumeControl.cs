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
 * Note: Volume controller that can be accessed via "Options" menu / icon
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeControl : MonoBehaviour {

    #region Audio sources

    // Audio source for background music
    private static AudioSource outputBG;

    // Audio source for sound effects
    private static AudioSource outputFX;

    #endregion

    // Volume value
    private static float volumeBG = 1f, volumeFX = 1f;

	void Start () {
        outputBG = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        outputFX = GameObject.Find("GameManager").GetComponent<AudioSource>();
	}
	
	void Update () {
        outputBG.volume = volumeBG;
        outputFX.volume = volumeFX;
	}

    #region Functions

    // The following changes the value of the volume of each audio source by how much the slider of each's corresponding slider is adjusted

    public void setvolumeBG(Slider x)
    {
        volumeBG = x.value;
    }

    public void setvoluemFX(Slider x)
    {
        volumeFX = x.value;
    }

    #endregion
}
