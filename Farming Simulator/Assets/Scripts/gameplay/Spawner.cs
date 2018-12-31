using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    private IList<GameObject> plants = new List<GameObject>();
    public GameObject Pest;
    public GameObject spawnedPest;
    public static string difficulty = "easy";
    private int numberspawn = 1;
    public float timeleft = 90;
    public static float pestlifespan;
    // Use this for initialization
    void Start () {
		
	}
	void Plant()
    {

    }
	// Update is called once per frame
	void Update () {
        if(GameObject.FindGameObjectsWithTag("plant").Length != 0)
        {
            timeleft -= Time.deltaTime;
        }
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("plant"))
        {

            plants.Add(fooObj);
        }
        if((plants.Count > 0)&(timeleft < 0))
        {
            int randomIndex = Random.Range(0, plants.Count);

            //pass in the game object into your MoveToward() method
            Vector3 center = plants[randomIndex].transform.position;
            if (difficulty.Equals("easy"))
            {
                numberspawn = 1;
            }
            if (difficulty.Equals("medium"))
            {
                numberspawn = 3;
            }
            if (difficulty.Equals("hard"))
            {
                numberspawn = 7;
            }
            for (int i = 0; i < numberspawn; i++)
            {
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
            if (difficulty.Equals("medium"))
            {
                timeleft = Random.Range(80, 90);
            }
            if (difficulty.Equals("hard"))
            {
                timeleft = Random.Range(80, 90);
            }
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
