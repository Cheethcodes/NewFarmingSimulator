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
                Debug.Log("choose medium");
                isKilled = false;
            }

            else if (newreactionTime < reactionTime - 6f)
            {
                Spawner.difficulty = "hard";
                reactionTime = newreactionTime;
                Debug.Log("choose hard");
                isKilled = false;
            }

            else if (newreactionTime > reactionTime + 6f)
            {
                Spawner.difficulty = "easy";
                reactionTime = newreactionTime;
                Debug.Log("choose easy");
                isKilled = false;
            }

            else
            {
                Random.Range(0, Spawner.difficultyspawn.Length);
                reactionTime = newreactionTime;
                Debug.Log("choose random");
                isKilled = false;
            }
        }

	}
}
