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
 * Note: Login GUI
 * 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class authenticate : MonoBehaviour {

    #region Login variables

    private static string LogInURL = "http://ghcsuarez.com/thesis/loginAccount.php";
    //private static string LogInURL = "http://127.0.0.1/DB_testConnection/loginAccount.php";
    private static string email = "";
    private static string password = "";

    #endregion

    #region CreateAccount variables

    private static string CreateAccountURL = "http://ghcsuarez.com/thesis/createAccount.php";
    //private static string CreateAccountURL = "http://127.0.0.1/DB_testConnection/createAccount.php";
    private static string ConEmail = "";
    private static string ConPass = "";
    private static string CEmail = "";
    private static string CPass = "";

    #endregion

    #region Initialize user

    public static string IGuser = "";
    public static int IGpts = 0;
    public static string IGinteract = "";
    public static float IGtime = 0;
    public static int IGmoney = 0;
    public static int IGmoneyEarned = 0;
    public static int IGmoneySpent = 0;

    #endregion

    private static string errMessage1 = "";
    private static string errMessage2 = "";

    public string CurrentMenu = "Login";

    GUISkin headerStyle, labelStyle, labelStyleM, txtBoxDes, errorMSGStyle;

    void Start()
    {
        // Initialize GUI styles
        headerStyle = Resources.Load<GUISkin>("GUI/GUISkins/Header");
        labelStyle = Resources.Load<GUISkin>("GUI/GUISkins/LabelSkin");
        labelStyleM = Resources.Load<GUISkin>("GUI/GUISkins/LabelSkin2");
        txtBoxDes = Resources.Load<GUISkin>("GUI/GUISkins/TxtBoxSkin");
        errorMSGStyle = Resources.Load<GUISkin>("GUI/GUISkins/ErrorMessage");
    }

    void OnGUI()
    {
        if (CurrentMenu == "Login")
        {
            GUI.Label(new Rect((Screen.width - (Screen.width / 1.5f)) / 2, (Screen.height - (Screen.height / 1.1f)) / 2, Screen.width / 1.5f, Screen.height / 1.5f), errMessage1, errorMSGStyle.GetStyle("errMsg"));
            LogIn();
        }
        else if (CurrentMenu == "Create Account")
        {
            GUI.Label(new Rect((Screen.width - (Screen.width / 1.5f)) / 2, (Screen.height - (Screen.height / 1.1f)) / 2, Screen.width / 1.5f, Screen.height / 1.5f), errMessage2, errorMSGStyle.GetStyle("errMsg"));
            CreateAccount();
        }
    }

    #region Login

    void LogIn()
    {
        #region Styles
        float btnWidth = (Screen.width * 0.9f) - (Screen.width * 0.68f);
        float btnHeight = 40;
        float btnPosY = (Screen.height + (Screen.height * 0.28f)) / 2;

        float txtWidth = (Screen.width / 2) - (Screen.width * 0.1f);
        float txtHeight = (Screen.height / 4) - (Screen.height * 0.155f);
        float txtPosX = ((Screen.width - (Screen.width / 2)) + (Screen.width * 0.273f)) / 2;

        float lblPosX = ((Screen.width - (Screen.width / 1.6f)) + (Screen.width * 0.023f)) / 2;

        GUI.backgroundColor = new Color(1, 0, 1, 1);
        #endregion

        GUI.Box(new Rect((Screen.width - (Screen.width / 1.5f)) / 2, (Screen.height - (Screen.height / 1.5f)) / 2, Screen.width / 1.5f, Screen.height / 1.5f), "Log In", headerStyle.GetStyle("headerLabel"));

        if (GUI.Button(new Rect((Screen.width + (Screen.width / 9.2f)) / 2, btnPosY, btnWidth, btnHeight), "Create Account"))
        {
            CurrentMenu = "Create Account";
            errMessage1 = "";
            errMessage2 = "";
        }

        if (GUI.Button(new Rect((Screen.width - (Screen.width / 1.8f)) / 2, btnPosY, btnWidth, btnHeight), "Log In"))
        {
            errMessage1 = "";
            errMessage2 = "";

            if (email != "" && password != "")
            {
                StartCoroutine("corLoginAccount");
            }
            else { }
        }

        GUI.Label(new Rect(lblPosX, (Screen.height - (Screen.height * 0.3f)) / 2, txtWidth - (Screen.width / 2), txtHeight), "Email:", labelStyle.GetStyle("txtLabels"));
        email = GUI.TextField(new Rect(txtPosX, (Screen.height - (Screen.height * 0.3f)) / 2, txtWidth, txtHeight), email);

        GUI.Label(new Rect(lblPosX, (Screen.height - (Screen.height * 0.05f)) / 2, txtWidth - (Screen.width / 2), txtHeight), "Password:", labelStyle.GetStyle("txtLabels"));
        password = GUI.PasswordField(new Rect(txtPosX, (Screen.height - (Screen.height * 0.05f)) / 2, txtWidth, txtHeight), password, '*', 20);
    }

    #endregion

    #region CreateAccount

    void CreateAccount()
    {
        #region Styles
        float btnWidth = (Screen.width * 0.9f) - (Screen.width * 0.68f);
        float btnHeight = 40;
        float btnPosY = (Screen.height + (Screen.height * 0.58f)) / 2;

        float txtWidth = (Screen.width / 2) - (Screen.width * 0.1f);
        float txtHeight = (Screen.height / 4) - (Screen.height * 0.155f);
        float txtPosX = ((Screen.width - (Screen.width / 2)) + (Screen.width * 0.273f)) / 2;

        float lblPosX = ((Screen.width - (Screen.width / 1.6f)) + (Screen.width * 0.023f)) / 2;

        GUI.backgroundColor = new Color(1, 0, 1, 1);
        #endregion

        GUI.Box(new Rect((Screen.width - (Screen.width / 1.5f)) / 2, (Screen.height - (Screen.height / 1.1f)) / 2, Screen.width / 1.5f, Screen.height / 1.1f), "Create Account", headerStyle.GetStyle("headerLabel"));

        GUI.Label(new Rect(lblPosX, (Screen.height - (Screen.height * 0.56f)) / 2, txtWidth - (Screen.width / 2), txtHeight), "Email:", labelStyle.GetStyle("txtLabels"));
        ConEmail = GUI.TextField(new Rect(txtPosX, (Screen.height - (Screen.height * 0.56f)) / 2, txtWidth, txtHeight), ConEmail);

        GUI.Label(new Rect(lblPosX, (Screen.height - (Screen.height * 0.3f)) / 2, txtWidth - (Screen.width / 2), txtHeight), "Confirm Email:", labelStyleM.GetStyle("txtLabelsMedium"));
        CEmail = GUI.TextField(new Rect(txtPosX, (Screen.height - (Screen.height * 0.3f)) / 2, txtWidth, txtHeight), CEmail);

        GUI.Label(new Rect(lblPosX, (Screen.height - (Screen.height * 0.05f)) / 2, txtWidth - (Screen.width / 2), txtHeight), "Password:", labelStyle.GetStyle("txtLabels"));
        ConPass = GUI.PasswordField(new Rect(txtPosX, (Screen.height - (Screen.height * 0.05f)) / 2, txtWidth, txtHeight), ConPass, '*', 20);

        GUI.Label(new Rect(lblPosX, (Screen.height + (Screen.height * 0.211f)) / 2, txtWidth - (Screen.width / 2), txtHeight), "Confirm Password:", labelStyleM.GetStyle("txtLabelsMedium"));
        CPass = GUI.PasswordField(new Rect(txtPosX, (Screen.height + (Screen.height * 0.211f)) / 2, txtWidth, txtHeight), CPass, '*', 20);

        if (GUI.Button(new Rect((Screen.width + (Screen.width / 9.2f)) / 2, btnPosY, btnWidth, btnHeight), "Back"))
        {
            CurrentMenu = "Login";
            errMessage1 = "";
            errMessage2 = "";
        }

        if (GUI.Button(new Rect((Screen.width - (Screen.width / 1.8f)) / 2, btnPosY, btnWidth, btnHeight), "Create Account"))
        {
            errMessage1 = "";
            errMessage2 = "";

            if (ConEmail == CEmail && ConPass == CPass)
            {
                StartCoroutine("corCreateAccount");
            }
            else { }
        }
    }

    #endregion

    #region Coroutines

    IEnumerator corCreateAccount()
    {
        // Add fields
        WWWForm frm = new WWWForm();
        frm.AddField("Email", CEmail);
        frm.AddField("Password", CPass);

        // Redirect to web
        // This also contains all the info the the php file will return
        WWW createAccountwww = new WWW(CreateAccountURL, frm);

        yield return createAccountwww;

        if (createAccountwww.error != null)
            errMessage2 = "Cannot connect to account creation";
        else
        {
            string CreateAccountreturn = createAccountwww.text;

            if (CreateAccountreturn == "Success")
            {
                errMessage2 = "Success! Account Created.";
                CurrentMenu = "Login";
            }
            else if (CreateAccountreturn == "Empty")
            {
                errMessage2 = "Accomplish alll required fields!";
            }
            else if (CreateAccountreturn == "AlreadyUsed")
            {
                errMessage2 = "User already exists";
            }
            else
            {
                errMessage2 = CreateAccountreturn;
            }
        }
    }

    IEnumerator corLoginAccount()
    {
        // Add fields
        WWWForm frm = new WWWForm();
        frm.AddField("Email", email);
        frm.AddField("Password", password);

        // Redirect to web
        // This also contains all the info the the php file will return
        WWW loginAccountwww = new WWW(LogInURL, frm);

        yield return loginAccountwww;

        if (loginAccountwww.error != null)
        {
            errMessage1 = "Log in form error.";
        }
        else
        {
            string loginAccountreturn = loginAccountwww.text;

            string[] textArr = loginAccountreturn.Split(',');

            if (textArr[7] == "Success")
            {
                // Gets variables that identify the current user
                // Gets variables that are updated during the game play
                IGtime = float.Parse(textArr[0]);
                IGinteract = textArr[2];
                IGpts = int.Parse(textArr[5]);
                IGuser = textArr[6];
                IGmoney = int.Parse(textArr[4]);
                IGmoneyEarned = int.Parse(textArr[3]);
                IGmoneySpent = int.Parse(textArr[4]);

                // Load gameplay scene
                SceneManager.LoadScene(1);
            }
            else
            {
                errMessage1 = textArr[7];
            }
        }
    }

    #endregion
}
