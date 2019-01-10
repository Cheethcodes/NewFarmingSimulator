using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavoir : MonoBehaviour {

    GameObject gamePest;
    private float reactionTime;
    private float newreactionTime;

	// Use this for initialization
	void Start () {
        gamePest = this.gameObject.GetComponent<Spawner>().Pest;
        reactionTime = 0;
        newreactionTime = 0;
	}
	
	// Update is called once per frame
	void Update () {

        newreactionTime = 0; //insert pest survival time final here ;

        if (!GameObject.Find("Pest Prefab(Clone)") && Spawner.timeleft <= 0)
        {
            if (newreactionTime < reactionTime + 5f && newreactionTime > reactionTime - 5f)
            {
                Spawner.difficulty = "medium";
                reactionTime = newreactionTime;
            }

            else if (newreactionTime < reactionTime - 6f)
            {
                Spawner.difficulty = "hard";
                reactionTime = newreactionTime;
            }

            else if (newreactionTime > reactionTime + 6f)
            {
                Spawner.difficulty = "easy";
                reactionTime = newreactionTime;
            }

            else
            {
                Random.Range(0, Spawner.difficultyspawn.Length);
                reactionTime = newreactionTime;
            }
        }

	}
}
