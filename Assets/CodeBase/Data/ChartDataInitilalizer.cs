using E2C;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartDataInitilalizer : MonoBehaviour
{
    public E2Chart E2Chart;
    public E2ChartData E2ChartData;

    private void Start()
    {
        Dictionary<DateTime, float> temperatureData = GenerateTemperatureData(100);

        BuildChart(temperatureData, "Temperature", "Линия 1");
    }

    private Dictionary<DateTime, float> GenerateTemperatureData(int count)
    {
        Dictionary<DateTime, float> data = new Dictionary<DateTime, float>();
        DateTime startDate = new DateTime(2024, 7, 1, 14, 0, 0);
        System.Random random = new System.Random();

        for (int i = 0; i < count; i++)
        {
            DateTime date = startDate.AddHours(i);
            float temperature = (float)(random.NextDouble() * 10 + 20); // Random temperature between 20.0 and 30.0
            data[date] = temperature;
        }

        return data;
    }

    private void BuildChart(Dictionary<DateTime, float> data, string parametrName, string productionLine)
    {
        E2ChartData.Series series = new E2ChartData.Series();
        series.name = parametrName;
        E2ChartData.title = productionLine;
        series.dataY = new List<float>(data.Values);
        E2ChartData.series.Add(series);

        E2ChartData.categoriesX = new List<string>();
        foreach (DateTime date in data.Keys)
        {
            E2ChartData.categoriesX.Add(date.ToString("dd/MM/yyyy HH:mm:ss"));
        }

        E2Chart.UpdateChart();
    }
}
