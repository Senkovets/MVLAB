using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Data : MonoBehaviour
{
    public UnityEvent AddData = new UnityEvent();

    [Serializable]
    public struct WeatherInfo
    {
        public string date;
        public int temperatureC;
        public string summary;
    }

    public List<WeatherInfo> DataList = new List<WeatherInfo>();

    public void AddWeatherDataFromJson(string jsonString)
    {
        WeatherInfo[] weatherInfos = JsonHelper.FromJson<WeatherInfo>(jsonString);
        DataList = new List<WeatherInfo>(weatherInfos);
        //weatherDataList.AddRange(weatherInfos);
        AddData?.Invoke();
    }

    public int GetTemperature()
    {
        if (DataList.Count > 0)
        {
            return DataList[DataList.Count - 1].temperatureC;
        }
        else
        {
            Debug.Log("No weather data available.");
            return 0;
        }
    }


}