using System;
using System.Collections.Generic;
using UnityEngine;

public class ProductionLine : MonoBehaviour
{
    public string Name;
    public float WorkAllTime;
    public float WorkMonthTime;
    public float WorkWeekTime;
    public float WorkDayTime;

    private Dictionary<DateTime, float> _temperatureData = new Dictionary<DateTime, float>();
    private Dictionary<DateTime, float> _vibrationData = new Dictionary<DateTime, float>();

    public void AddTemperature(DateTime timestamp, float temperature)
    {
        _temperatureData[timestamp] = temperature;
    }

    public float GetTemperature(DateTime timestamp)
    {
        if (_temperatureData.TryGetValue(timestamp, out float temperature))
        {
            return temperature;
        }
        else
        {
            Debug.LogWarning($"No temperature data available for timestamp: {timestamp}");
            return float.NaN; // или другое значение по умолчанию
        }
    }

    public void AddVibration(DateTime timestamp, float vibration)
    {
        _vibrationData[timestamp] = vibration;
    }

    public float GetVibration(DateTime timestamp)
    {
        if (_vibrationData.TryGetValue(timestamp, out float vibration))
        {
            return vibration;
        }
        else
        {
            Debug.LogWarning($"No vibration data available for timestamp: {timestamp}");
            return float.NaN; // или другое значение по умолчанию
        }
    }
}
