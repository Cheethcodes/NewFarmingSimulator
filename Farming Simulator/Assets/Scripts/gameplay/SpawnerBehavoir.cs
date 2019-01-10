/*
 * 
 * Author: Gabriel Hansley Suarez
 * Date Created: January 10, 2019
 * Source: 
 * 
 * Modified by: Gabriel Hansley Suarez
 * Date Modified: January 10, 2019
 * Last Date Modified: January 10, 2019
 * 
 * Contributors:
 * 
 * Credits: -----------
 * 
 * License: 
 * 
 * Note: Acts as modifier for pest spawner script
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavoir : MonoBehaviour {
    
    private static float reactionTime;
    public static float newreactionTime;
    public static bool isKilled;

	// Use this for initialization
	void Start () {
        isKilled = false;
        reactionTime = 0;
        newreactionTime = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (isKilled == true)
        {
            if (newreactionTime < reactionTime + 5f && newreactionTime > reactionTime - 5f)
            {
                Spawner.difficulty = "medium";
                reactionTime = newreactionTime;
                isKilled = false;
            }

            else if (newreactionTime < reactionTime - 6f)
            {
                Spawner.difficulty = "hard";
                reactionTime = newreactionTime;
                isKilled = false;
            }

            else if (newreactionTime > reactionTime + 6f)
            {
                Spawner.difficulty = "easy";
                reactionTime = newreactionTime;
                isKilled = false;
            }

            else
            {
                Random.Range(0, Spawner.difficultyspawn.Length);
                reactionTime = newreactionTime;
                isKilled = false;
            }
        }

	}
}
