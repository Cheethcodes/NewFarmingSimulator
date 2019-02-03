using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private IList<GameObject> plants = new List<GameObject>();
    public GameObject Pest;
    public static GameObject spawnedPest;
    public static string difficulty;
    private int numberspawn;
    public static float timeleft;
    public static string[] difficultyspawn = { "easy", "medium", "hard" };
    int startDifficultyIndex;

    void Start()
    {
        startDifficultyIndex = Random.Range(0, difficultyspawn.Length);
        difficulty = difficultyspawn[startDifficultyIndex];
        timeleft = 10f;
    }

    void Update ()
    {
        if(GameObject.FindGameObjectsWithTag("plant").Length != 0)
        {
            timeleft -= Time.deltaTime;
        }

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("plant"))
        {
            plants.Add(fooObj);
        }

        if((plants.Count > 0) & (timeleft < 0))
        {
            

            if (difficulty.Equals("easy"))
            {
                numberspawn = 1;
            }
            else if (difficulty.Equals("medium"))
            {
                numberspawn = 3;
            }
            else if (difficulty.Equals("hard"))
            {
                numberspawn = 7;
            }
            else { }

            for (int i = 0; i < numberspawn; i++)
            {
                int randomIndex = Random.Range(0, plants.Count);
                // Pass in the game object into your MoveToward() method
                Vector3 center = plants[randomIndex].transform.position;
                Vector3 pos = RandomCircle(center, 20f);
                Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
                spawnedPest = Instantiate(Pest, pos, Quaternion.identity);
                spawnedPest.GetComponent<Pest>().targetplant = plants[randomIndex];
            }
        }

        if(timeleft < 0)
        {
            if (difficulty.Equals("easy"))
            {
                timeleft = Random.Range(80, 90);
            }
            else if (difficulty.Equals("medium"))
            {
                timeleft = Random.Range(50, 90);
            }
            else if (difficulty.Equals("hard"))
            {
                timeleft = Random.Range(24, 80);
            }
            else { }
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
