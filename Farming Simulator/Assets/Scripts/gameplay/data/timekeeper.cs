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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class timekeeper : MonoBehaviour {

    #region Geme time components

    // Container for time display
    private Text timecontainer, ampmcontainer;

    // Time variables
    int year;
    int month;
    int day;
    public static int hour;
    public static int hour_military;
    public static int hour_hidden;
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

    #region Local save variables

    string[] dtSave;
    double dtDifference;

    DateTime dtPrev;

    string[] prevGameTime;

    #endregion

    void Start()
    {
        #region Game time initialization

        clockSpeed = 1.0f;

        // Set initial time values
        msecs = 0.0f;

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

        #region Session time record

        // Get DateTime now
        DateTime dtCurrent = DateTime.Now;

        // Default path
        string path = Application.persistentDataPath + "/sessionRecord.rt";

        // Search for file
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            dtSave = (formatter.Deserialize(stream) as string).Split(',');

            dtDifference = dtCurrent.Subtract(Convert.ToDateTime(dtSave[0])).TotalSeconds;

            prevGameTime = dtSave[1].Split('|');
            year = Convert.ToInt32(prevGameTime[0]);
            month = Convert.ToInt32(prevGameTime[1]);
            day = Convert.ToInt32(prevGameTime[2]);
            hour = Convert.ToInt32(prevGameTime[3]);
            timeofday = prevGameTime[4];
            hour_military = Convert.ToInt32(prevGameTime[5]);
            hour_hidden = Convert.ToInt32(prevGameTime[6]);
        }
        else
        {
            year = DateTime.Now.Year;
            month = 1;
            day = 1;
            hour = 0;
            hour_military = 0;
            hour_hidden = 0;

            timeofday = "AM";
        }

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
            hour_military++;
            hour_hidden++;

            // Hour to day (morning)
            if (hour_military == 12 && msecs > 0)
            {
                timeofday = "PM";
            }

            else if (hour_military == 13)
            {
                timeofday = "PM";
                hour = 1;
            }

            // Hour to day (evening)
            else if (hour_military == 24)
            {
                // For every full 24 hours, 1 is added to day value and reset hour value to 0
                hour = 0;
                hour_military = 0;
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

    // Record time when game is closed
    void OnApplicationQuit()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        // Defined where to save the file
        string path = Application.persistentDataPath + "/sessionRecord.rt";
        FileStream stream = new FileStream(path, FileMode.Create);

        string timeData = DateTime.Now.ToString();
        string gameTime = year.ToString() + "|" + month.ToString() + "|" + day.ToString() + "|" + hour.ToString() + "|" + timeofday + "|" + hour_military + "|" + hour_hidden;

        formatter.Serialize(stream, timeData + "," + gameTime);
        stream.Close();
    }
}
