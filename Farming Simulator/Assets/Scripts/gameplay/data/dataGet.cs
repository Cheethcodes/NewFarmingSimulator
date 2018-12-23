/*
 * 
 * Author: Gabriel Hansley Suarez
 * Date Created: December 20, 2018
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
 * Note: Gets data from database of the current user who logged in the game.
 * 
 */
 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dataGet : MonoBehaviour {

    // Get current logged in user's statistics stored in the database
    private static object[] currentUserData = {authenticate.IGuser, authenticate.IGpts, authenticate.IGtime, authenticate.IGinteract, authenticate.IGmoney};

    // Initialize containers
    private Text containerMoney,containerPoints;
    private string getUser, getInteract;
    private float getTime;

	void Start () {

        #region Initialize GameObjects

        // Fill in all user's statistics to gameplay
        // Objects that contain the user data stored in the database that is publicly dsiplayed
        containerMoney = GameObject.Find("container_Money").GetComponent<Text>();
        containerPoints = GameObject.Find("container_Score").GetComponent<Text>();
        containerMoney.text = currentUserData[4].ToString();
        containerPoints.text = currentUserData[1].ToString();

        // Objects that contain the user data stored in the database that is not available for viewing
        getUser = currentUserData[0].ToString();
        getTime = Convert.ToSingle(currentUserData[2]);
        getInteract = currentUserData[3].ToString();

        #endregion

    }
}
