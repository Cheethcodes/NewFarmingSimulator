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
    public GameObject thepest;
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
        thepest = Spawner.spawnedPest;

        if(pesthealth == 0)
        {
            Destroy(thepest);
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
        //this will get the time the counter has when the pest was killed
        pestsurvivaltimefinal = Mathf.RoundToInt(pestsurvivaltimecounter);
        Spawner.pestlifespan = pestsurvivaltimefinal;
        pesthealth -= 20;

    }

    public void MoveTowardsPlant()
    {
        //pass in the game object into your MoveToward() method
        transform.LookAt(targetplant.transform);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        if (Vector3.Distance(transform.position, targetplant.transform.position) >= MinDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetplant.transform.position, MoveSpeed);
        }
    }
}