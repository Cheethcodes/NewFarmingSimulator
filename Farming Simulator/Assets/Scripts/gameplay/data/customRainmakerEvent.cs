/*
 * 
 * Author: Jeff Johnson
 * Date Created: --------
 * Source: Unity Asset Store\Rainmaker - 2D and 3D Rain Particle System for Unity
 * 
 * Modified by: Gabriel Hansley Suarez
 * Date Modified: September 15, 2018
 * Last Date Modified: September 15, 2018
 * 
 * Contributors:
 * 
 * Credits:
 * 
 * License:
 * 
 * Note: Do not edit file. File is only used for RainMaker
 *     : Filename was changed from DemoScriptStartRainonSpaceBar
 *     
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DigitalRuby.RainMaker;

public class customRainmakerEvent : MonoBehaviour
{
    public BaseRainScript RainScript;
    public weatherGet[] weather;
    public static weatherGet currentWeather;

    private Text labelTemperature;
    // triggers when it will be rainy or sunny
    int triggerRain;
    int triggerSun;
    int hour;
    float changeTempTimer;
    public static bool newWeather = false;

    private void Start()
    {
        labelTemperature = GameObject.Find("container_Temperature").GetComponent<Text>();
        currentWeather = weather[Random.Range(0, 2)];
        labelTemperature.text = Random.Range(currentWeather.getTemperatureMin(), currentWeather.getTemperatureMax()).ToString();

        hour = timekeeper.hour_military;

        if (RainScript == null)
        {
            return;
        }
        RainScript.EnableWind = false;
        triggerRain = UnityEngine.Random.Range(0, currentWeather.getSunDuration() - 1);
        rainChancePicker();

        Debug.Log(currentWeather);
        Debug.Log(currentWeather.getWeatherType());
        Debug.Log("Starting TriggerRain " + triggerRain);
        Debug.Log(triggerRain + " " + currentWeather.getRainDuration() + " " + currentWeather.getSunDuration());
    }

    private void Update()
    {

        changeTempTimer += Time.deltaTime;

        if (hour == 23)
        {
            hour = timekeeper.hour_military;
        }

        if (newWeather == true)
        {
            Debug.Log("New Weather");
            newWeather = false;
            currentWeather = weather[Random.Range(0, 2)];
            Debug.Log(currentWeather + " " + currentWeather.getWeatherType());
            triggerRain = Random.Range(0, currentWeather.getSunDuration() - 1);
            Debug.Log("Brand new TriggerRain " + triggerRain);
            rainChancePicker();
        }

        if (currentWeather.getSunny() == true)
        {
            if (timekeeper.hour_military == hour+1)
            {
                currentWeather.setSunDuration(currentWeather.getSunDuration() - 1);
                hour = timekeeper.hour_military;
            }
            if (currentWeather.getSunDuration() <= 0 || currentWeather.getSunDuration() == triggerRain)
            {
                if (currentWeather.getSunDuration() == triggerRain)
                {
                    triggerRain = 0;
                }
                currentWeather.setRaining(true);
                currentWeather.setSunny(false);
            }
        }
        else if (currentWeather.getRaining() == true)
        {
            if (timekeeper.hour_military == hour+1)
            {
                currentWeather.setRainDuration(currentWeather.getRainDuration() - 1);
                hour = timekeeper.hour_military;
            }
            if (currentWeather.getRainDuration() <= 0 /*||currentWeather.getRainDuration() == triggerSun*/)
            {
                currentWeather.setRaining(false);
                currentWeather.setSunny(true);
            }
        }
        if (currentWeather.getSunDuration() <= 0 && currentWeather.getRainDuration() <= 0)
        {
            weatherSimulator.makeWeather = true;
            Debug.Log("Simulating new weather");
        }
        if (RainScript == null)
        {
            return;
        }
        else if (currentWeather.getRaining())
        {
            RainScript.RainIntensity = currentWeather.getRainIntensity();

            RainScript.EnableWind = true;

        }
        else if (currentWeather.getSunny())
        {
            RainScript.RainIntensity = 0f;
            RainScript.EnableWind = false;
        }

        if (changeTempTimer >= 5)
        {
            Debug.Log("Changing Temp");
            int newTemp = Random.Range(currentWeather.getTemperatureMin(), currentWeather.getTemperatureMax());
            if (hour >= 18)
                newTemp -= 10;
            labelTemperature.text = newTemp.ToString();
            changeTempTimer = 0;
        }

    }
    void rainChancePicker()
    {
        int x = Random.Range(1, 100);
        Debug.Log(x);
        if ((100 - currentWeather.getRainChancePercentage()) > x)
        {
            Debug.Log("Will not rain");
            currentWeather.setSunDuration(currentWeather.getSunDuration() + currentWeather.getRainDuration());
            currentWeather.setRainDuration(0);
            currentWeather.setSunny(true);
            currentWeather.setRaining(false);
            triggerRain = 0;

        }
        else
        {
            triggerRain = UnityEngine.Random.Range(0, currentWeather.getSunDuration() - 1);
        }
    }
}