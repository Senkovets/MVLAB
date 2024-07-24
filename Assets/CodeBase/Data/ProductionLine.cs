using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductionLine : MonoBehaviour
{
    public string Name;

    public float WorkAllTime;
    public float WorkMonthTime;
    public float WorkWeekTime;
    public float WorkDayTime;

    public Dictionary<string, Dictionary<DateTime, float>> _parametrs = new Dictionary<string, Dictionary<DateTime, float>>();
    private Dictionary<DateTime, float> _temperatureData = new Dictionary<DateTime, float>();
    private Dictionary<DateTime, float> _vibrationData = new Dictionary<DateTime, float>();

    public TextMeshProUGUI NameTextMesh;
    public TextMeshProUGUI WorkAllTimeTextMesh;
    public TextMeshProUGUI WorkMonthTimeTextMesh;
    public TextMeshProUGUI WorkWeekTimeTextMesh;
    public TextMeshProUGUI WorkDayTimeTextMesh;
    public TextMeshProUGUI TemperatureTextMesh;
    public TextMeshProUGUI VibrationTextMesh;
    public Button ChartButton;

    private void Start()
    {
        TestFillVariables();
        ChartButton.onClick.AddListener(OnChartButtonClicked);

        _parametrs[Constants.TemperatureKey] = _temperatureData;
        _parametrs[Constants.VibrationKey] = _vibrationData;

    }

    public Dictionary<DateTime, float> GetParameterData(string key)
    {
        if (_parametrs.TryGetValue(key, out var innerDictionary))
        {
            return innerDictionary;
        }
        else
        {
            // ���� ���� �� ������, ����� ������� ������ ������� ��� null
            return null;
        }
    }


    private void OnChartButtonClicked()
    {
        GameManager.Instance.OpenGraph(this);
    }

    public void TestFillVariables()
    {
        Name = "�����_" + UnityEngine.Random.Range(1, 100);
        WorkAllTime = Mathf.Round(UnityEngine.Random.Range(500f, 2000f) * 10f) / 10f;
        WorkMonthTime = Mathf.Round(UnityEngine.Random.Range(100f, 500f) * 10f) / 10f;
        WorkWeekTime = Mathf.Round(UnityEngine.Random.Range(20f, 100f) * 10f) / 10f;
        WorkDayTime = Mathf.Round(UnityEngine.Random.Range(1f, 20f) * 10f) / 10f;

        _temperatureData = new Dictionary<DateTime, float>()
    {
        { DateTime.Now.AddDays(-1), Mathf.Round(UnityEngine.Random.Range(15f, 25f) * 10f) / 10f },
        { DateTime.Now, Mathf.Round(UnityEngine.Random.Range(15f, 25f) * 10f) / 10f }
    };

        _vibrationData = new Dictionary<DateTime, float>()
    {
        { DateTime.Now.AddDays(-1), Mathf.Round(UnityEngine.Random.Range(3f, 7f) * 10f) / 10f },
        { DateTime.Now, Mathf.Round(UnityEngine.Random.Range(3f, 7f) * 10f) / 10f }
    };

        // �������� �����������
        UpdateView();
    }



    public void UpdateView()
    {
        NameTextMesh.text = Name;
        WorkAllTimeTextMesh.text = WorkAllTime.ToString();
        WorkMonthTimeTextMesh.text = WorkMonthTime.ToString();
        WorkWeekTimeTextMesh.text = WorkWeekTime.ToString();
        WorkDayTimeTextMesh.text = WorkDayTime.ToString();

        // ��� ����������� ��������� ������ � ����������� � ��������
        if (_temperatureData.Count > 0)
        {
            KeyValuePair<DateTime, float> lastTemperatureData = _temperatureData.Last();
            TemperatureTextMesh.text = lastTemperatureData.Value.ToString();
        }

        if (_vibrationData.Count > 0)
        {
            KeyValuePair<DateTime, float> lastVibrationData = _vibrationData.Last();
            VibrationTextMesh.text = lastVibrationData.Value.ToString();
        }
    }


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
            return float.NaN; 
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
            return float.NaN; 
        }
    }
}
