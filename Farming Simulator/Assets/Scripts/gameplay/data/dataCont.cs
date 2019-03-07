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
 * Note: Updates data that may result from any actions made by the user
 *       Also any automated system that return updated data will also be recorded here
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dataCont : MonoBehaviour {

    // Score and money variables
    private Text moneyContainer, scoreContainer;
    public static int moneyValue, scoreValue, moneyEarned, moneySpent;

    void Start()
    {
        // Initialize money and score values
        moneyContainer = GameObject.Find("container_Money").GetComponent<Text>();
        scoreContainer = GameObject.Find("container_Score").GetComponent<Text>();

        moneyValue = int.Parse(moneyContainer.text);
        scoreValue = int.Parse(scoreContainer.text);

        moneyEarned = 0;
        moneySpent = 0;
    }

    void Update()
    {
        moneyContainer.text = moneyValue.ToString();
        scoreContainer.text = scoreValue.ToString();
    }

}
