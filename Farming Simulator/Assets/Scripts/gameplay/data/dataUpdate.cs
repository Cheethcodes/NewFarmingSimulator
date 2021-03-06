﻿/*
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
 * Note: Updates data that may result from any actions made by the user or from any automated system
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dataUpdate : MonoBehaviour
{

    //private static string logOutURL = "http://ghcsuarez.com/thesis/logoutAccount.php";
    private static string logOutURL = "http://127.0.0.1/DBThesis/logoutAccount.php";

    #region Save Option

    // Unchanged variables
    private string pUser;

    // Variables to be updated
    private static float newTime;
    private static string newInteract;
    private static int newPoints;
    private static int newMoney;
    private static int newMoneyEarned;
    private static int newMoneySpent;

    private static float sessionTime;
    private static int sessionPts;

    private static string errMessage = "";

    int logoutCounter;

    void Start()
    {
        pUser = authenticate.IGuser;
        logoutCounter = 0;
    }

    public void logout()
    {
        #region To be updated data

        // Session data
        sessionTime = timekeeper.currentsessionTime;
        sessionPts = pInteractions.temp_scoreValue;

        // New data (total)
        newTime = timekeeper.totaltime;
        newPoints = dataCont.scoreValue;
        newInteract = " ";                        //====================================================== TO BE UPDATED
        newMoney = dataCont.moneyValue;
        newMoneyEarned = dataCont.moneyEarned;
        newMoneySpent = dataCont.moneySpent;

        Debug.Log(newMoneyEarned + "," + newMoneySpent);
        Debug.Log(pUser);
        Debug.Log(newTime.ToString());
        Debug.Log(newPoints);
        Debug.Log(sessionTime + "," + sessionPts);

        #endregion

        StartCoroutine("updateData");

        logoutCounter += 1;
    }

    //void OnApplicationQuit()
    //{
    //    if (logoutCounter == 0)
    //    {
    //        #region To be updated data

    //        // Session data
    //        sessionTime = timekeeper.currentsessionTime;
    //        sessionPts = pInteractions.temp_scoreValue;

    //        // New data (total)
    //        newTime = timekeeper.totaltime;
    //        newPoints = dataCont.scoreValue;
    //        newInteract = "tssss";                        //====================================================== TO BE UPDATED
    //        newMoney = dataCont.moneyValue;

    //        #endregion

    //        StartCoroutine("updateData");
    //    }
    //    else
    //    {

    //    }
    //}

    IEnumerator updateData()
    {
        WWWForm frm = new WWWForm();
        frm.AddField("upUser", pUser);
        frm.AddField("upTime", newTime.ToString());
        frm.AddField("upInteract", newInteract);
        frm.AddField("upPts", newPoints);
        frm.AddField("cTime", sessionTime.ToString());
        frm.AddField("cuPts", sessionPts);
        frm.AddField("curMoneySpent", newMoneySpent);
        frm.AddField("curMoneyEarned", newMoneyEarned);

        WWW logoutAcct = new WWW(logOutURL, frm);

        yield return logoutAcct;

        string logoutAccountreturn = logoutAcct.text;

        if (logoutAccountreturn == "Everything OK")
        {
            SceneManager.LoadScene(0);
            errMessage = "";
        }
        else
        {
            SceneManager.LoadScene(0);
            errMessage = logoutAccountreturn;
        }
    }

    #endregion
}
