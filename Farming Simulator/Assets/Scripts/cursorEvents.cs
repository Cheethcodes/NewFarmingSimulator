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

    // Show button labels
    public void showLabel()
    {
        // Get the name of the object
        string[] name = (this.gameObject.name).Split('-');
        Debug.Log(name[0]);

        #region Gemplay buttons
        // Standard of namin button objects "play-(Type of button)_(Name of button)"

        if (name[0] == "play")
        {
            string[] newName = name[1].Split('_');

            switch (newName[0])
            {
                case "Tool":
                    switch (newName[2])
                    {
                        case "Default":
                            obj_Tools.SetActive(true);
                            txt_ToolsChild.text = "Default tool";
                            break;

                        case "Fertilizer":
                            break;

                        case "Water":
                            break;

                        case "Cultivate":
                            break;

                        case "Harvest":
                            break;

                        case "Recycle":
                            break;

                    }
                    break;

                case "Bldg":

                    break;

                case "Plant":

                    break;
            }
        }

        #endregion
    }

    //private Button btnMenu;

    //private Transform tooltipMenu;
    //private bool tooltipMenu_Active = false;
    //private string tooltipMenu_Title;
    //private string tooltipMenu_Description;

    //void Start()
    //{

    //}

    //void OnMouseEnter()
    //{
    //    if (tooltip_Active == false)
    //    {
    //        tooltip.GetComponent<TextMesh>().text = "A tooltip";
    //        tooltip_Active = true;
    //        Instantiate(tooltip, new Vector3(transform.position.x, transform.position.y - 10, 0), tooltip.rotation);
    //    }
    //}

    //void OnMouseExit()
    //{
    //    if (tooltip_Active == true)
    //    {
    //        tooltip_Active = false;
    //    }
    //}

}
