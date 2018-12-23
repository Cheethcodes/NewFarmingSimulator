/*
 * 
 * Author: Gabriel Hansley Suarez
 * Date Created: December 21, 2018
 * Source: 
 * 
 * Modified by: Gabriel Hansley Suarez
 * Date Modified: December 21, 2018
 * Last Date Modified: December 21, 2018
 * 
 * Contributors:
 * 
 * Credits: -----------
 * 
 * License: 
 * 
 * Note: Timer per log in session of the user
 *       Also contains the game time
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timekeeper : MonoBehaviour {

    #region Geme time components

    // Container for time display
    private Text timecontainer, ampmcontainer;

    // Time variables
    int year = 2019;
    int month = 1;
    int day = 1;
    int hour = 0;
    public static int hour_hidden = 0;
    float msecs;
    string timeofday;

    // Computation of real time > game time
    public static float clockSpeed;

    #endregion

    #region Session time components

    // Variables for recording start and end of session
    private string sessionTime_Start, sessionTime_End;
    private string[] sessionTime;

    // System date and time
    DateTime tStart, tEnd;
    TimeSpan sessionTime_difference;

    // Variables that will be used to keep track of session time and updated in the database
    public static float currentsessionTime = 0.000f;
    public static float totaltime = 0.000f;
    private static float dataTime;

    #endregion

    void Start()
    {
        #region Game time initialization

        clockSpeed = 1.0f;

        // Set initial time values
        msecs = 0.0f;
        timeofday = "AM";

        // Initialize where to display time
        timecontainer = GameObject.Find("container_Time").GetComponent<Text>();
        ampmcontainer = GameObject.Find("container_AmPm").GetComponent<Text>();

        #endregion

        #region Session time initialization

        // Get old time value of the player
        dataTime = authenticate.IGtime;

        // Record time the player started to play
        tStart = DateTime.Now;
        sessionTime_Start = tStart.ToString();

        #endregion
    }

    void Update()
    {
        #region Game time

        // New milliseconds is defined to be updated and how fast it will count
        msecs += Time.deltaTime * clockSpeed;

        // Below are time values that has already been converted from real time to game time
        // Millisecond to second
        if (msecs >= 1.0f)
        {
            // For every full 60 milliseconds, 1 is added to hour value
            msecs -= 1.0f;
            hour++;
            hour_hidden++;

            // Hour to day (morning)
            if (hour_hidden == 12 && msecs > 0)
            {
                timeofday = "PM";
            }

            else if (hour_hidden == 13)
            {
                timeofday = "PM";
                hour = 1;
            }

            // Hour to day (evening)
            else if (hour_hidden == 24)
            {
                // For every full 24 hours, 1 is added to day value and reset hour value to 0
                hour = 0;
                day++;
                timeofday = "AM";

                #region DAY-MONTH-Year + Leap year checker

                // Leap year
                if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                {
                    // January, March, May, July, Augsust, October, December have 31 days each
                    if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                    {
                        // Day to month
                        if (day == 31)
                        {
                            // For every 31 full days, 1 is added to month value and reset day value to 1
                            day = 1;
                            month++;

                            // Month to year
                            if (month == 12)
                            {
                                // For every 12 months, 1 is added to year value and reset month value to 1
                                month = 1;
                                year++;
                            }
                        }
                    }

                    // April, June, September, November have 30 days each
                    else if (month == 4 || month == 6 || month == 9 || month == 11)
                    {
                        // Day to month
                        if (day == 30)
                        {
                            // For every 30 full days, 1 is added to month value and reset day value to 1
                            day = 1;
                            month++;

                            // Month to year
                            if (month == 12)
                            {
                                // For every 12 months, 1 is added to year value and reset month value to 1
                                month = 1;
                                year++;
                            }
                        }
                    }

                    // February has only 29 days in a leap year
                    else if (month == 2)
                    {
                        // Day to month
                        if (day == 29)
                        {
                            // For every 29 full days, 1 is added to month value and reset day value to 1
                            day = 1;
                            month++;

                            // Month to year
                            if (month == 12)
                            {
                                // For every 12 months, 1 is added to year value and reset month value to 1
                                month = 1;
                                year++;
                            }
                        }
                    }

                    else { }
                }

                // Non leap year
                else
                {
                    // January, March, May, July, Augsust, October, December have 31 days each
                    if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                    {
                        // Day to month
                        if (day == 31)
                        {
                            // For every 31 full days, 1 is added to month value and reset day value to 1
                            day = 1;
                            month++;

                            // Month to year
                            if (month == 12)
                            {
                                // For every 12 months, 1 is added to year value and reset month value to 1
                                month = 1;
                                year++;
                            }
                        }
                    }

                    // April, June, September, November have 30 days each
                    else if (month == 2 || month == 4 || month == 6 || month == 9 || month == 11)
                    {
                        // Day to month
                        if (day == 30)
                        {
                            // For every 30 full days, 1 is added to month value and reset day value to 1
                            day = 1;
                            month++;

                            // Month to year
                            if (month == 12)
                            {
                                // For every 12 months, 1 is added to year value and reset month value to 1
                                month = 1;
                                year++;
                            }
                        }
                    }

                    else { }
                }

                #endregion

            }
            else { }
        }
        
        timecontainer.text = month.ToString() + " / " + day.ToString() + " / " + year.ToString() + " | " + hour.ToString("00");

        ampmcontainer.text = timeofday;

        #endregion

        #region Session time

        // Constantly records the present time
        tEnd = DateTime.Now;
        sessionTime_End = tEnd.ToString();

        // Calculates time in hours the time that have passed since the player started his session
        sessionTime_difference = tEnd.Subtract(tStart);

        calcTimePLayed();

        #endregion
    }

    #region Time played calculation

    // Calculator for time played per session to be added to the total time the user has been playing
    void calcTimePLayed()
    {
        // Current session time
        sessionTime = (sessionTime_difference.ToString()).Split(':');

        // Conversion of play time to hours
        currentsessionTime = (float.Parse(sessionTime[0]) + ((float.Parse(sessionTime[1])) / 60)) + ((float.Parse(sessionTime[2])) / 3600);

        // Total time the player has been playing including the current session
        totaltime = (dataTime + currentsessionTime);
    }

    #endregion

}
