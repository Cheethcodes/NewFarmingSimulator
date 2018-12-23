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
    private float rainIntensity, rainDurationMin, rainDurationMax, rainChance;

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
                tempMin = 29;
                tempMax = 45;

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
                rainDurationMax = 24;
                rainIntensity = Random.Range(0f, 0.20f);

                // Temperature - COLD
                tempMin = 10;
                tempMax = 23;

                break;

            // Undefined
            default:
                break;
        }

        ////set how long the rain last
        //weatherEasy.setRainDuration(Random.Range(rainDurationMin, rainDurationMax));
        //weatherMedium.setRainDuration(Random.Range(rainDurationMin + 2, rainDurationMax + 2));
        //weatherHard.setRainDuration(Random.Range(rainDurationMin + 5, rainDurationMax + 5));

        ////set sun duration
        //weatherEasy.setSunDuration(23 - weatherEasy.getRainDuration());
        //weatherMedium.setSunDuration(23 - weatherMedium.getRainDuration());
        //weatherHard.setSunDuration(23 - weatherHard.getRainDuration());

        ////set rain intensity
        //setRainIntensity(weatherEasy, rainIntensity);
        //setRainIntensity(weatherMedium, rainIntensity + 0.10f);
        //setRainIntensity(weatherHard, rainIntensity + 0.20f);

        ////set sun intensity
        //setSunIntensity(weatherEasy, sunIntensity);
        //setSunIntensity(weatherMedium, sunIntensity + 2);
        //setSunIntensity(weatherHard, sunIntensity + 5);

        ////set TemperatureMin
        //weatherEasy.setTemperatureMin(tempMin);
        //weatherMedium.setTemperatureMin(tempMin + 2);
        //weatherHard.setTemperatureMin(tempMin + 5);

        ////set TemperatureMax
        //weatherEasy.setTemperatureMax(tempMax - 10);
        //weatherMedium.setTemperatureMax(tempMax - 5);
        //weatherHard.setTemperatureMax(tempMax);

        ////set rain chance percentage
        //weatherEasy.setRainChancePercentage(rainChancePercent);
        //weatherMedium.setRainChancePercentage(rainChancePercent + 5);
        //weatherHard.setRainChancePercentage(rainChancePercent + 10);

        ////set weather type
        //weatherEasy.setWeatherType(weatherType);
        //weatherMedium.setWeatherType(weatherType);
        //weatherHard.setWeatherType(weatherType);
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
