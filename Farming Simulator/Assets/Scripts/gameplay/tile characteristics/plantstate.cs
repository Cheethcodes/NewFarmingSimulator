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
 * Note: Some useless script that characterizes the plant game objects
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantstate : MonoBehaviour {

    #region Growth variables of the plant
    // STAGES and corresponding SPRITES
    //  1 - seed
    //  2 - immature
    //  3 - plant
    //  4 - mature
    // Harvestable state is at stage 3 and 4
    public static int growthStage;
    public Sprite[] nextStageImage;

    // TIME
    public int growthTime;

    // TIME LIVED
    private float growthTimeMature_1;
    private float growthTimeMature_2;
    private float growthTimeMature_3;
    private float growthTimeMature_4;

    #endregion

    // Defines what kind of plant
    public string plantName;

    void Start()
    {
        // Set all plant to birth + immature stage
        growthTimeMature_1 = Mathf.Round(growthTime / 4) * 1;
        growthTimeMature_2 = Mathf.Round(growthTime / 4) * 2;
        growthTimeMature_3 = Mathf.Round(growthTime / 4) * 3;
        growthTimeMature_4 = growthTime;
        growthStage = 0;
    }

    // Update is called once per frame
    void Update () {

        if (this.gameObject.GetComponent<plantTimer>().day == growthTimeMature_1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = nextStageImage[0];
        }
        else if (this.gameObject.GetComponent<plantTimer>().day == growthTimeMature_2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = nextStageImage[1];
        }
        else if (this.gameObject.GetComponent<plantTimer>().day == growthTimeMature_3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = nextStageImage[2];
        }

        Debug.Log(this.gameObject.GetComponent<plantTimer>().day + " : " + this.gameObject.GetComponent<plantTimer>().hour + " : " + this.gameObject.GetComponent<plantTimer>().msecs);

	}
}
