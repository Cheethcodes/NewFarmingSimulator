using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "weatherTimer")]
public class weatherTimer : ScriptableObject
{
    public int month;
    public int day;
    public int year;
    public int hour;
    float irlTime;
    public bool paused;

    void Start()
    {
        month = 1;
        day = 1;
        year = 1;
        hour = 1;
    }

    public void CalculateTime()
    {
        irlTime += Time.deltaTime;
        if (irlTime >= 1) //control how many irl seconds is one game hour 
        {
            hour += 1;
            irlTime = 0;
        }
        if (hour == 25)
        {
            day += 1;
            hour = 1;
        }
        if ((month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) && day == 32)
        {
            day = 1;
            month += 1;
        }
        else if (month == 2 && day == 29)
        {
            day = 1;
            month += 1;
        }
        else if (day == 31)
        {
            month += 1;
            day = 1;
        }
        if (month == 13)
            year += 1;
    }
    public string getDate()
    {
        return month.ToString() + "/" + day.ToString() + "/" + year.ToString();
    }
    public override string ToString()
    {
        return month + "/" + day + "/" + year + "   " + hour + ":00";
    }
}
