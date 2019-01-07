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
 * Note: Timer per plant that counts the time it is alive in the scene
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plantTimer : MonoBehaviour {

    // Time the plant is living
    // Container for time display
    private Text timecontainer;

    // Time variables
    public int day = 0;
    public int hour = 0;
    public float msecs;

    // Computation of real time > game time
    private float clockSpeed;

    void Start ()
    {
        clockSpeed = timekeeper.clockSpeed;
        Debug.Log(this.gameObject.transform.parent.name);
	}
	
	void Update ()
    {
        // New milliseconds is defined to be updated and how fast it will count
        msecs += Time.deltaTime * clockSpeed;

        // Below are time values that has already been converted from real time to game time
        // Millisecond to second
        if (msecs >= 1.0f)
        {
            // For every full 60 milliseconds, 1 is added to hour value
            msecs -= 1.0f;
            hour++;

            // Hour to day (morning)
            if (hour == 24)
            {
                hour = 0;
                day++;
            }
        }

        PlayerPrefs.SetFloat(this.gameObject.transform.parent.name + "_hasPlantMsec", msecs);
        PlayerPrefs.SetInt(this.gameObject.transform.parent.name + "_hasPlantHour", hour);
        PlayerPrefs.SetInt(this.gameObject.transform.parent.name + "_hasPlantDay", day);

    }
}
