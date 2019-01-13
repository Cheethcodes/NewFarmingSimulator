/*
 * 
 * Author: Gabriel Hansley Suarez
 * Date Created: January 13, 2019
 * Source: 
 * 
 * Modified by: Gabriel Hansley Suarez
 * Date Modified: January 13, 2019
 * Last Date Modified: January 13, 2019
 * 
 * Contributors:
 * 
 * Credits: -----------
 * 
 * License: 
 * 
 * Note: Update volume slider based on playerprefs
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeSliders : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        if (PlayerPrefs.HasKey("sliderBG") || PlayerPrefs.HasKey("sliderFX"))
        {
            if (this.gameObject.name == "volumeBG_controller")
            {
                this.gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("sliderBG");
            }

            if (this.gameObject.name == "volumeFX_controller")
            {
                this.gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("sliderFX");
            }
        }
        else { }
	}
}
