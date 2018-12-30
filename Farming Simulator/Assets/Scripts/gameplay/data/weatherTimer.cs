using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weatherTimer : MonoBehaviour
{
    public static int hour;
    float sec;

    void Start()
    {
        sec = 0;
        hour = 1;
    }

    void Update()
    {
        sec += Time.deltaTime;

        if (sec >= 1.0f)
        {
            hour++;

            if (hour == 24)
            {
                hour = 0;
            }
        }
    }
}
