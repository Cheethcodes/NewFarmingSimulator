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

    #region Audio target

    AudioSource audiosrc;
    AudioClip[] audioclip;

    #endregion

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
        // Initialize audio and clips
        audiosrc = GameObject.Find("GameManager").GetComponent<AudioSource>();
        audioclip = GameObject.Find("GameManager").GetComponent<GameMgr>().audioClips;

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

    #region Help menu

    public void showmenu_Help()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            menuHelp.SetActive(true);
            playAudio(0);
        }
        else
            return;
    }

    public void closemenu_Help()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            menuHelp.SetActive(false);
            playAudio(0);
        }
        else
            return;
    }

    #endregion

    #region Play menu

    #region Main Play menu

    // Tool selector
    public void toggleToolSelector()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (animBuild.GetBool("slide") == false && animPlant.GetBool("slide") == false)
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
            else if (animBuild.GetBool("slide") == true && animPlant.GetBool("slide") == false)
            {
                counterTools += 1;
                counterBuild += 1;

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
            else if (animBuild.GetBool("slide") == false && animPlant.GetBool("slide") == true)
            {
                counterTools += 1;
                counterPlant += 1;

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
            else { }
            
            playAudio(0);
        }
        else
            return;
    }

    // Building selector
    public void toggleBldgSelector()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (animTools.GetBool("slide") == false && animPlant.GetBool("slide") == false)
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
            else if (animTools.GetBool("slide") == true && animPlant.GetBool("slide") == false)
            {
                counterTools += 1;
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
            else if (animTools.GetBool("slide") == false && animPlant.GetBool("slide") == true)
            {
                counterBuild += 1;
                counterPlant += 1;

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
            else { }

            playAudio(0);
        }
        else
            return;
    }

    // Plant selector
    public void togglePlantSelector()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (animTools.GetBool("slide") == false && animBuild.GetBool("slide") == false)
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
            else if (animTools.GetBool("slide") == true && animBuild.GetBool("slide") == false)
            {
                counterTools += 1;
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
            else if (animTools.GetBool("slide") == false && animBuild.GetBool("slide") == true)
            {
                counterBuild += 1;
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
            else { }

            playAudio(0);
        }
        else
            return;
    }

    #endregion

    #region Sub Play menu

    #region Tools

    // Array of images for buttons
    public Sprite[] playTools_btnImages;

    // Default tool
    public void selectDefaultTool()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            counterTools += 1;

            pInteractions.currentTool = "action-None";
            menuToolsBTN.GetComponent<Image>().sprite = playTools_btnImages[0];
            animTools.SetBool("slide", false);

            playAudio(0);
        }
        else
            return;
    }

    // Move tool used for moving objects in the game
    public void selectMoveTool()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            counterTools += 1;

            pInteractions.currentTool = "action-Move";
            //menuToolsBTN.GetComponent<Image>().sprite = playTools_btnImages[1];
            animTools.SetBool("slide", false);

            playAudio(0);
        }
        else
            return;
    }

    // Cultivate grass tool
    public void selectCultivateTool()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            counterTools += 1;

            pInteractions.currentTool = "action-Cultivate";
            menuToolsBTN.GetComponent<Image>().sprite = playTools_btnImages[2];
            animTools.SetBool("slide", false);

            playAudio(0);
        }
        else
            return;
    }

    // Watering tool
    public void selectWaterTool()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            counterTools += 1;

            pInteractions.currentTool = "action-Water";
            menuToolsBTN.GetComponent<Image>().sprite = playTools_btnImages[3];
            animTools.SetBool("slide", false);

            playAudio(0);
        }
        else
            return;
    }

    // Harvest tool
    public void selectHarvestTool()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            counterTools += 1;

            pInteractions.currentTool = "action-Harvest";
            menuToolsBTN.GetComponent<Image>().sprite = playTools_btnImages[4];
            animTools.SetBool("slide", false);

            playAudio(0);
        }
        else
            return;
    }

    public void selectRecycleTool()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            counterTools += 1;

            pInteractions.currentTool = "action-Sell";
            menuToolsBTN.GetComponent<Image>().sprite = playTools_btnImages[5];
            animTools.SetBool("slide", false);

            playAudio(0);
        }
        else
            return;
    }

    public void selectFertilizerTool()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            counterTools += 1;

            pInteractions.currentTool = "action-Fertilize";
            menuToolsBTN.GetComponent<Image>().sprite = playTools_btnImages[1];
            animTools.SetBool("slide", false);

            playAudio(0);
        }
        else
            return;
    }

    #endregion

    #region Buildings

    public void buildGreenhouse()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            counterBuild += 1;

            animBuild.SetBool("slide", false);

            playAudio(0);
        }
    }

    #endregion

    #region Plants

    // Array of images for button
    public Sprite[] playPlants_btnImages;

    public void plantCarrot()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            counterPlant += 1;

            pInteractions.currentTool = "action-Plant-Carrot";
            menuPlantBTN.GetComponent<Image>().sprite = playPlants_btnImages[0];
            animPlant.SetBool("slide", false);

            playAudio(0);
        }
        else
            return;
    }

    public void plantOnion()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            counterPlant += 1;

            pInteractions.currentTool = "action-Plant-Onion";
            menuPlantBTN.GetComponent<Image>().sprite = playPlants_btnImages[1];
            animPlant.SetBool("slide", false);

            playAudio(0);
        }
        else
            return;
    }

    public void plantPumpkin()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            counterPlant += 1;

            pInteractions.currentTool = "action-Plant-Pumpkin";
            menuPlantBTN.GetComponent<Image>().sprite = playPlants_btnImages[2];
            animPlant.SetBool("slide", false);

            playAudio(0);
        }
        else
            return;
    }

    public void plantRadish()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            counterPlant += 1;

            pInteractions.currentTool = "action-Plant-Radish";
            menuPlantBTN.GetComponent<Image>().sprite = playPlants_btnImages[3];
            animPlant.SetBool("slide", false);

            playAudio(0);
        }
        else
            return;
    }

    public void plantTomato()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            counterPlant += 1;

            pInteractions.currentTool = "action-Plant-Tomato";
            menuPlantBTN.GetComponent<Image>().sprite = playPlants_btnImages[4];
            animPlant.SetBool("slide", false);

            playAudio(0);
        }
        else
            return;
    }

    public void plantWatermelon()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            counterPlant += 1;

            pInteractions.currentTool = "action-Plant-Watermelon";
            menuPlantBTN.GetComponent<Image>().sprite = playPlants_btnImages[5];
            animPlant.SetBool("slide", false);

            playAudio(0);
        }
        else
            return;
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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            menuOptions.SetActive(true);

            playAudio(0);
        }
        else
            return;
    }

    public void closemenu_Options()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            menuOptions.SetActive(false);

            playAudio(0);
        }
        else
            return;
    }

    #endregion

    // Intitialize how audio is played
    void playAudio(int x)
    {
        audiosrc.clip = audioclip[x]; // play corresponding audio clip
        audiosrc.Play(); // Audio source attached to the player
    }

}
