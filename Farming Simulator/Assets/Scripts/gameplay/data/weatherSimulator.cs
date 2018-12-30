/*
 * 
 * Author: Gabriel Hansley Suarez
 * Date Created: December 23, 2018
 * Source: 
 * 
 * Modified by: Gabriel Hansley Suarez
 * Date Modified: December 23, 2018
 * Last Date Modified: December 23, 2018
 * 
 * Contributors:
 * 
 * Credits: -----------
 * 
 * License: 
 * 
 * Note: Weather Generator 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weatherSimulator : MonoBehaviour {

    // Weather difficulties
    public weatherGet wEasy;
    public weatherGet wMedium;
    public weatherGet wHard;

    #region Variables for weather

    // Type of weather
    public string[] weatherTypeArray;
    private string weatherType;

    // Sun
    private float sunIntensity;

    // Rain
    private float rainIntensity;
    private int rainDurationMin, rainDurationMax, rainChance;

    // Temperature
    // Ceiling and floor values
    private int tempMin, tempMax;

    #endregion
    
    public static bool makeWeather;

    void Awake()
    {
        // Available weather types
        weatherTypeArray = new string[] { "sunny", "rainy", "cold" };

        // Initial weather type at the start of the game play
        chooseWeather();
    }

    void Update()
    {
        if (makeWeather == true)
        {
            makeWeather = false;
            chooseWeather();
            customRainmakerEvent.newWeather = true;
        }
    }

    void chooseWeather()
    {
        switch (weatherTypeArray[Random.Range(0, 2)])
        {
            /*
            * NOTE that simulated weather values are different from real time weather values because of the following factors:
            *       1. Location (location in Earth, nearness to the body of water, nearness to the equator / poles)
            *       2. Geography (altitude, landforms)
            *       3. Time (morning, evening)
            *       4. Global warming (including greenhouse gas emmisions, pollution and pollutants)
            */

            // Sunny
            case "sunny":

                // Weather type definition
                weatherType = "sunny";

                // Sun - MOST DOMINANT
                sunIntensity = Random.Range(5.00f, 10.00f);

                // Rain
                // Chances of raining during sunny days is 5%
                // Rain can only last up to 4 hours in the game
                // Because of factors like the sun's heat and temperature, water evaporates more easily and amount of water falling from the sky will be less
                rainChance = 5;
                rainDurationMin = 0;
                rainDurationMax = 4;
                rainIntensity = Random.Range(0.00f, 0.40f);

                // Temperature - HOT
                tempMin = 25;
                tempMax = 40;

                wEasy.setRainDuration(Random.Range(rainDurationMin, rainDurationMax));
                wMedium.setRainDuration(Random.Range(rainDurationMin, rainDurationMax));
                wHard.setRainDuration(Random.Range(rainDurationMin, rainDurationMax));
                setRainIntensity(wEasy, rainIntensity);
                setRainIntensity(wMedium, rainIntensity);
                setRainIntensity(wHard, rainIntensity);
                setSunIntensity(wEasy, sunIntensity);
                setSunIntensity(wMedium, sunIntensity + 2);
                setSunIntensity(wHard, sunIntensity + 5);

                wEasy.setTemperatureMin(tempMin);
                wMedium.setTemperatureMin(tempMin + 2);
                wHard.setTemperatureMin(tempMin + 5);

                wEasy.setTemperatureMax(tempMax - 10);
                wMedium.setTemperatureMax(tempMax - 5);
                wHard.setTemperatureMax(tempMax);

                break;

            // Rainy
            case "rainy":

                // Weather type definition
                weatherType = "rainy";

                // Sun
                // Variable is weakened by the amount of water and clouds
                sunIntensity = Random.Range(0.00f, 4.5f);

                // Rain - MOST DOMINANT
                // Chances of raining during rainy days is 80%
                // Rain can last 1 whole day in the game
                rainChance = 80;
                rainDurationMin = 4;
                rainDurationMax = 24;
                rainIntensity = Random.Range(0.40f, 0.70f);
                

                // Temperature - MILD
                tempMin = 20;
                tempMax = 29;

                //set weather
                wEasy.setRainDuration(Random.Range(rainDurationMin, rainDurationMax));
                wMedium.setRainDuration(Random.Range(rainDurationMin + 2, rainDurationMax));
                wHard.setRainDuration(Random.Range(rainDurationMin + 5, rainDurationMax));

                setRainIntensity(wEasy, rainIntensity);
                setRainIntensity(wMedium, rainIntensity + 0.10f);
                setRainIntensity(wHard, rainIntensity + 0.20f);

                setSunIntensity(wEasy, sunIntensity);
                setSunIntensity(wMedium, sunIntensity);
                setSunIntensity(wHard, sunIntensity);

                wEasy.setTemperatureMin(tempMin);
                wMedium.setTemperatureMin(tempMin-1);
                wHard.setTemperatureMin(tempMin-2);

                wEasy.setTemperatureMax(tempMax - 5);
                wMedium.setTemperatureMax(tempMax - 2);
                wHard.setTemperatureMax(tempMax);

                break;

            // Cold
            case "cold":

                // Weather type definition
                weatherType = "cold";

                // Sun
                sunIntensity = Random.Range(1.50f, 6.00f);

                // Rain
                // Chances of raining during cold days is 50%
                // Rain may last 1 whole day
                rainChance = 50;
                rainDurationMin = 0;
                rainDurationMax = 12;
                rainIntensity = Random.Range(0f, 0.20f);

                // Temperature - COLD
                tempMin = 18;
                tempMax = 22;

                wEasy.setRainDuration(Random.Range(rainDurationMin, rainDurationMax));
                wMedium.setRainDuration(Random.Range(rainDurationMin + 2, rainDurationMax + 3));
                wHard.setRainDuration(Random.Range(rainDurationMin + 5, rainDurationMax + 8));

                setRainIntensity(wEasy, rainIntensity);
                setRainIntensity(wMedium, rainIntensity + 0.10f);
                setRainIntensity(wHard, rainIntensity + 0.20f);

                setSunIntensity(wEasy, sunIntensity);
                setSunIntensity(wMedium, sunIntensity);
                setSunIntensity(wHard, sunIntensity);

                wEasy.setTemperatureMin(tempMin);
                wMedium.setTemperatureMin(tempMin-2);
                wHard.setTemperatureMin(tempMin - 5);

                wEasy.setTemperatureMax(tempMax);
                wMedium.setTemperatureMax(tempMax - 2);
                wHard.setTemperatureMax(tempMax-5);
                break;

            // Undefined
            default:
                break;
        }

        //set sun duration
        wEasy.setSunDuration(23 - wEasy.getRainDuration());
        wMedium.setSunDuration(23 - wMedium.getRainDuration());
        wHard.setSunDuration(23 - wHard.getRainDuration());

        ////set rain chance percentage
        wEasy.setRainChancePercentage(rainChance);
        wMedium.setRainChancePercentage(rainChance);
        wHard.setRainChancePercentage(rainChance);

        ////set weather type
        wEasy.setWeatherType(weatherType);
        wMedium.setWeatherType(weatherType);
        wHard.setWeatherType(weatherType);
    }

    #region Weather sun and rain intensities

    // Rain
    void setRainIntensity(weatherGet weather, float rainIntensity)
    {
        if (weather.getRainDuration() > 0)
        {
            weather.setRainIntensity(rainIntensity);
        }
    }

    // Sun
    void setSunIntensity(weatherGet weather, float sunIntensity)
    {
        if (weather.getSunDuration() > 0)
        {
            weather.setSunIntensity(sunIntensity);
        }
    }

    #endregion
}
