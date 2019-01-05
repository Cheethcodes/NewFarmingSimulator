/*
 * 
 * Author: Gabriel Hansley Suarez
 * Date Created: December 27, 2018
 * Source: 
 * 
 * Modified by: Gabriel Hansley Suarez
 * Date Modified: December 27, 2018
 * Last Date Modified: December 27, 2018
 * 
 * Contributors:
 * 
 * Credits: -----------
 * 
 * License: 
 * 
 * Note: Class containing events for cursor / pointer
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class cursorEvents : MonoBehaviour {

    #region Game menus
    public GameObject[] menuType;

    // , INDEX: 0

    // Options menu, INDEX: 1
    private GameObject obj_Options;
    private Transform obj_OptionsChild;
    private Text txt_OptionsChild;

    // Tool menu, INDEX: 2
    private GameObject obj_Tools;
    private Transform obj_ToolsChild;

    private Text txt_ToolsChild;

    // Plant and building menu, INDEX: 3
    private GameObject obj_Play;

    private Transform obj_PlayChild_Title;
    private Transform obj_PlayChild_Description_Plant;
    private Transform obj_PlayChild_Description_Bldg;

    private Text txt_PlayChild_Title;
    private Text txt_PlayChild_Description_Plant;
    private Text txt_PlayChild_Description_Bldg;

    // , INDEX: 4

    // , INDEX: 5

    #endregion

    void Start()
    {
        // Corresponding tooltips / mini menu
        obj_Options = menuType[1];
        obj_Tools = menuType[2];
        obj_Play = menuType[3];

        #region Options menu tooltip

        obj_OptionsChild = obj_Options.transform.GetChild(0);
        txt_OptionsChild = obj_OptionsChild.GetComponent<Text>();

        #endregion

        #region Play menu tooltips

        #region Tools

        obj_ToolsChild = obj_Tools.transform.GetChild(0);
        txt_ToolsChild = obj_ToolsChild.GetComponent<Text>();

        #endregion

        #region Plants and Buildings

        obj_PlayChild_Title = obj_Play.transform.GetChild(0);
        obj_PlayChild_Description_Plant = obj_Play.transform.GetChild(1);
        obj_PlayChild_Description_Bldg = obj_Play.transform.GetChild(2);

        txt_PlayChild_Title = obj_PlayChild_Title.transform.GetComponent<Text>();
        txt_PlayChild_Description_Plant = obj_PlayChild_Description_Plant.GetComponent<Text>();
        txt_PlayChild_Description_Bldg = obj_PlayChild_Description_Bldg.GetComponent<Text>();

        #endregion

        #endregion
    }

    public void ShowToolTip(BaseEventData baseEvent = null)
    {
        if (baseEvent != null)
        {
            Debug.Log(baseEvent.selectedObject.name);
        }
    }

    // Show button labels
    public void showLabel(string objName)
    {
        // Get the name of the object
        string[] name = (objName).Split('-');

        Vector2 targetButton = GameObject.Find(objName).transform.position;

        #region Gemplay buttons
        // Standard of namin button objects "play-(Type of button)_(Name of button)"

        if (name[0] == "play")
        {
            string[] newName = name[1].Split('_');

            switch (newName[0])
            {

                #region Tools

                case "Tool":

                    obj_Tools.SetActive(true);

                    targetButton.x -= Screen.width / 7.707f;

                    switch (newName[1])
                    {
                        case "Default":
                            obj_Tools.transform.position = targetButton;
                            txt_ToolsChild.text = "Default tool";
                            break;

                        case "Fertilizer":
                            obj_Tools.transform.position = targetButton;
                            txt_ToolsChild.text = "Fertilizer tool";
                            break;

                        case "Water":
                            obj_Tools.transform.position = targetButton;
                            txt_ToolsChild.text = "Water tool";
                            break;

                        case "Cultivate":
                            obj_Tools.transform.position = targetButton;
                            txt_ToolsChild.text = "Cultivate tool";
                            break;

                        case "Harvest":
                            obj_Tools.transform.position = targetButton;
                            txt_ToolsChild.text = "Harvest tool";
                            break;

                        case "Recycle":
                            obj_Tools.transform.position = targetButton;
                            txt_ToolsChild.text = "Recycle tool";
                            break;

                    }
                    break;

                #endregion

                #region  Buildings

                case "Bldg":

                    obj_Play.SetActive(true);

                    targetButton.x -= Screen.width / 4.459f;

                    switch (newName[1])
                    {
                        case "Greenhouse":
                            obj_Play.transform.position = targetButton;
                            txt_PlayChild_Title.text = "Greenhouse";
                            txt_PlayChild_Description_Bldg.text = "A greenhouse that can be built to control the environmental condition for the plants that will be stored.\n\n" +
                                "Cost: 1000 coins | 3 days\n" +
                                "Income: 10 coins/day";
                            break;
                    }

                    break;

                #endregion

                #region Plant

                case "Plant":

                    obj_Play.SetActive(true);

                    targetButton.x -= Screen.width / 4.484f;

                    switch (newName[1])
                    {
                        // Carrot
                        case "Carrot":
                            obj_Play.transform.position = targetButton;
                            txt_PlayChild_Title.text = "Carrot";
                            txt_PlayChild_Description_Plant.text = "A carrot seed.\n\n" +
                                "Cost:   15 coins | Average Growth Time: 60 days\n" +
                                "Income: 40 coins | Score: 20";
                            break;

                        // Onion
                        case "Onion":
                            obj_Play.transform.position = targetButton;
                            txt_PlayChild_Title.text = "Onion";
                            txt_PlayChild_Description_Plant.text = "An onion seed.\n\n" +
                                "Cost:    5 coins | Average Growth Time: 60 days\n" +
                                "Income: 70 coins | Score: 30";
                            break;

                        // Pumpkin
                        case "Pumpkin":
                            obj_Play.transform.position = targetButton;
                            txt_PlayChild_Title.text = "Pumpkin";
                            txt_PlayChild_Description_Plant.text = "A pumpkin seed.\n\n" +
                                "Cost:    50 coins | Average Growth Time: 60 days\n" +
                                "Income: 120 coins | Score: 60";
                            break;

                        // Radish
                        case "Radish":
                            obj_Play.transform.position = targetButton;
                            txt_PlayChild_Title.text = "Radish";
                            txt_PlayChild_Description_Plant.text = "A radish seed.\n\n" +
                                "Cost:   15 coins | Average Growth Time: 60 days\n" +
                                "Income: 40 coins | Score: 20";
                            break;

                        // Tomato
                        case "Tomato":
                            obj_Play.transform.position = targetButton;
                            txt_PlayChild_Title.text = "Tomato";
                            txt_PlayChild_Description_Plant.text = "A tomato seed.\n\n" +
                                "Cost:   10 coins | Average Growth Time: 60 days\n" +
                                "Income: 30 coins | Score: 10";
                            break;

                        // Watermelon
                        case "Watermelon":
                            obj_Play.transform.position = targetButton;
                            txt_PlayChild_Title.text = "Tomato";
                            txt_PlayChild_Description_Plant.text = "A tomato seed.\n\n" +
                                "Cost:    40 coins | Average Growth Time: 60 days\n" +
                                "Income: 150 coins | Score: 70";
                            break;
                    }
                    break;

                    #endregion

            }
        }

        else if (name[0] == "icon")
        {
            string newName = name[1];
            
            obj_Options.SetActive(true);

            targetButton.x -= Screen.width / 19.266f;
            targetButton.y -= Screen.height / 12.233f;

            switch (name[1])
            {
                case "options":
                    obj_Options.transform.position = targetButton;
                    txt_OptionsChild.text = "Options";
                    break;

                case "help":
                    obj_Options.transform.position = targetButton;
                    txt_OptionsChild.text = "Help";
                    break;

                case "logout":
                    obj_Options.transform.position = targetButton;
                    txt_OptionsChild.text = "Save & LogOut";
                    break;
            }
        }

        else { }

        #endregion
    }

    public void hideLabel()
    {
        // Set active tool tip menu to false
        obj_Options.SetActive(false);
        obj_Tools.SetActive(false);
        obj_Play.SetActive(false);

        // Resets the value for all text gui inside the objects that has been set to inactive
        txt_OptionsChild.text = "";
        txt_ToolsChild.text = "";
        txt_PlayChild_Title.text = "";
        txt_PlayChild_Description_Bldg.text = "";
        txt_PlayChild_Description_Plant.text = "";
    }

}
