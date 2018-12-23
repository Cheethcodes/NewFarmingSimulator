using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weatherGet : MonoBehaviour {

    [SerializeField] int rainDuration;
    [SerializeField] int sunDuration;
    [SerializeField] float rainIntensity;
    [SerializeField] int rainChancePercentage;
    [SerializeField] float sunIntensity;
    [SerializeField] int temperatureMin;
    [SerializeField] int temperatureMax;
    [SerializeField] bool raining = false;
    [SerializeField] bool sunny = true;
    [SerializeField] string weatherType;

    public void setWeatherType(string weatherType)
    {
        this.weatherType = weatherType;
    }

    public string getWeatherType()
    {
        return weatherType;
    }

    public void setRainDuration(int rainDuration)
    {
        this.rainDuration = rainDuration;
    }

    public void setSunDuration(int sunDuration)
    {
        this.sunDuration = sunDuration;
    }

    public void setRainIntensity(float rainIntensity)
    {
        this.rainIntensity = rainIntensity;
    }

    public void setRainChancePercentage(int rainChancePercentage)
    {
        this.rainChancePercentage = rainChancePercentage;
    }

    public void setSunIntensity(float sunIntensity)
    {
        this.sunIntensity = sunIntensity;
    }

    public void setTemperatureMin(int temperatureMin)
    {
        this.temperatureMin = temperatureMin;
    }

    public void setTemperatureMax(int temperatureMax)
    {
        this.temperatureMax = temperatureMax;
    }

    public int getRainDuration()
    {
        return rainDuration;
    }

    public int getSunDuration()
    {
        return sunDuration;
    }

    public float getRainIntensity()
    {
        return rainIntensity;
    }

    public int getRainChancePercentage()
    {
        return rainChancePercentage;
    }

    public float getSunIntensity()
    {
        return sunIntensity;
    }

    public int getTemperatureMin()
    {
        return temperatureMin;
    }

    public int getTemperatureMax()
    {
        return temperatureMax;
    }

    public bool getRaining()
    {
        return raining;
    }

    public bool getSunny()
    {
        return sunny;
    }

    public void setRaining(bool raining)
    {
        this.raining = raining;
    }

    public void setSunny(bool sunny)
    {
        this.sunny = sunny;
    }
}
