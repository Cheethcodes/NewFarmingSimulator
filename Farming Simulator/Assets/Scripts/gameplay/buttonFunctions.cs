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
 * Note: Defines all GameObject interaction if any action is executed on a button
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonFunctions : MonoBehaviour {

    #region GameObjects menu

    // General menu
    public GameObject menuOptions, menuHelp;

    // Play menu
    public GameObject menuTools, menuBuild, menuPlant;
    public Button menuToolsBTN, menuBuildBTN, menuPlantBTN;

    // Animators of play menu
    private Animator animTools, animBuild, animPlant;
    private int counterTools, counterBuild, counterPlant;

    #endregion

    void Start()
    {
        // Initialize animations for play menu
        animTools = menuTools.GetComponent<Animator>();
        animBuild = menuBuild.GetComponent<Animator>();
        animPlant = menuPlant.GetComponent<Animator>();

        // Initialize animation values
        animBuild.SetBool("slide", false);
        animPlant.SetBool("slide", false);
        animTools.SetBool("slide", false);

        // Initialize button toggle counters for animation
        counterBuild = 2;
        counterPlant = 2;
        counterTools = 2;
    }

    void Update()
    {
        
    }

    #region Help menu

    public void showmenu_Help()
    {
        menuHelp.SetActive(true);
    }

    public void closemenu_Help()
    {
        menuHelp.SetActive(false);
    }

    #endregion

    #region Play menu

    #region Main Play menu

    // Tool selector
    public void toggleToolSelector()
    {
        counterTools += 1;

        if (counterTools % 2 == 1)
        {
            // Set current menu to active / show on screen
            animTools.SetBool("slide", true);

            // Set all other menu to inactive / hide from screen
            animBuild.SetBool("slide", false);
            animPlant.SetBool("slide", false);
        }
        else
        {
            // Set current menu to inactive / hide from screen
            animTools.SetBool("slide", false);
        }
    }

    // Building selector
    public void toggleBldgSelector()
    {
        counterBuild += 1;

        if (counterBuild % 2 == 1)
        {
            // Set current menu to active / show on screen
            animBuild.SetBool("slide", true);

            // Set all other menu to inactive / hide from screen
            animTools.SetBool("slide", false);
            animPlant.SetBool("slide", false);
        }
        else
        {
            // Set current menu to inactive / hide from screen
            animBuild.SetBool("slide", false);
        }
    }

    // Plant selector
    public void togglePlantSelector()
    {
        counterPlant += 1;

        if (counterPlant % 2 == 1)
        {
            // Set current menu to active / show on screen
            animPlant.SetBool("slide", true);

            // Set all other menu to inactive / hide from screen
            animBuild.SetBool("slide", false);
            animTools.SetBool("slide", false);
        }
        else
        {
            // Set current menu to inactive / hide from screen
            animPlant.SetBool("slide", false);
        }
    }

    #endregion

    #region Sub Play menu

    #region Tools

    // Array of images for buttons
    public Sprite[] playTools_btnImages;

    // Default tool
    public void selectDefaultTool()
    {
        pInteractions.currentTool = "action-None";
        menuToolsBTN.GetComponent<Image>().sprite = playTools_btnImages[0];
        animTools.SetBool("slide", false);
    }

    // Move tool used for moving objects in the game
    public void selectMoveTool()
    {
        pInteractions.currentTool = "action-Move";
        //menuToolsBTN.GetComponent<Image>().sprite = playTools_btnImages[1];
        animTools.SetBool("slide", false);
    }

    // Cultivate grass tool
    public void selectCultivateTool()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            pInteractions.currentTool = "action-Cultivate";
            menuToolsBTN.GetComponent<Image>().sprite = playTools_btnImages[2];
            animTools.SetBool("slide", false);
        }
        else
            return;
    }

    // Watering tool
    public void selectWaterTool()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            pInteractions.currentTool = "action-Water";
            menuToolsBTN.GetComponent<Image>().sprite = playTools_btnImages[3];
            animTools.SetBool("slide", false);
        }
        else
            return;
    }

    // Harvest tool
    public void selectHarvestTool()
    {
        pInteractions.currentTool = "action-Harvest";
        menuToolsBTN.GetComponent<Image>().sprite = playTools_btnImages[4];
        animTools.SetBool("slide", false);
    }

    public void selectRecycleTool()
    {
        pInteractions.currentTool = "action-Sell";
        menuToolsBTN.GetComponent<Image>().sprite = playTools_btnImages[5];
        animTools.SetBool("slide", false);
    }

    public void selectFertilizerTool()
    {
        pInteractions.currentTool = "action-Fertilize";
        menuToolsBTN.GetComponent<Image>().sprite = playTools_btnImages[1];
        animTools.SetBool("slide", false);
    }

    #endregion

    #region Buildings

    #endregion

    #region Plants

    public void plantCarrot()
    {
        pInteractions.currentTool = "action-Plant-Carrot";
        animPlant.SetBool("slide", false);
    }

    public void plantOnion()
    {
        pInteractions.currentTool = "action-Plant-Onion";
        animPlant.SetBool("slide", false);
    }

    public void plantPumpkin()
    {
        pInteractions.currentTool = "action-Plant-Pumpkin";
        animPlant.SetBool("slide", false);
    }

    public void plantRadish()
    {
        pInteractions.currentTool = "action-Plant-Radish";
        animPlant.SetBool("slide", false);
    }

    public void plantTomato()
    {
        pInteractions.currentTool = "action-Plant-Tomato";
        animPlant.SetBool("slide", false);
    }

    public void plantWatermelon()
    {
        pInteractions.currentTool = "action-Plant-Watermelon";
        animPlant.SetBool("slide", false);
    }

    #endregion

    #endregion

    #endregion

    #region Options menu

    // Shows option menu
    // The following can be customized by the user in this menu
    // Volume of the background music and SFX as well as the quality of the game graphics rendering
    public void showmenu_Options()
    {
        menuOptions.SetActive(true);
    }

    public void closemenu_Options()
    {
        menuOptions.SetActive(false);
    }

    #endregion
}
