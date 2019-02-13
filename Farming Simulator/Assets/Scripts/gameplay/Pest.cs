/*
 * 
 * Author: Antonio Lorenzo Hecali
 * Date Created: 
 * Source: 
 * 
 * Credits: -----------
 * 
 * License: 
 * 
 * Note:
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pest : MonoBehaviour
{
    public Transform targetPest;
    float MoveSpeed = 0.2f;
    float MinDist = 0f;
    public GameObject[] plant;
    public int plant_length;
    private int randomIndex;
    public int counter = 0;
    public float pestsurvivaltimecounter;
    public int pestsurvivaltimefinal;
    public int pesthealth;
    public GameObject targetplant;
    private IList<GameObject> plants = new List<GameObject>();

    void Start()
    {
        //thepest = targetPest.gameObject;
        if (Spawner.difficulty.Equals("easy"))
        {
            pesthealth = 40;
        }
        else if (Spawner.difficulty.Equals("medium"))
        {
            pesthealth = 60;
        }
        else if (Spawner.difficulty.Equals("hard"))
        {
            pesthealth = 100;
        }
        else { }
    }

    void Update()
    {
        pesthealth = Mathf.Clamp(pesthealth, 0, 100);

        if(pesthealth == 0)
        {   
            //only pass the time of the last killed pest
            if (GameObject.FindGameObjectsWithTag("Pest").Length == 1) {
                //this will get the time the counter has when the pest was killed
                pestsurvivaltimefinal = Mathf.RoundToInt(pestsurvivaltimecounter);
                SpawnerBehavoir.newreactionTime = pestsurvivaltimefinal;
                SpawnerBehavoir.isKilled = true;
            }
            
            Destroy(gameObject);
            
        }
        MoveTowardsPlant();
        pestsurvivaltimecounter += Time.deltaTime;
    }

    public int Compare(string x, string y)
    {
        return x.CompareTo(y);
    }

    void OnMouseDown()
    {
        
        pesthealth -= 20;
    }

    public void MoveTowardsPlant()
    {
        //pass in the game object into your MoveToward() method
        try {
            transform.LookAt(targetplant.transform);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            if (Vector3.Distance(transform.position, targetplant.transform.position) >= MinDist)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetplant.transform.position, MoveSpeed);
            }
        } catch {
            foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("plant")) {
                plants.Add(fooObj);
            }
            targetplant = plants[Random.Range(0, plants.Count)];
            plants= new List<GameObject>();
        }
        
    }

    void OnApplicationQuit()
    {
        Destroy(gameObject);
    }
}