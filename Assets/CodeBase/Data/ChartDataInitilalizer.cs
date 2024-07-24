using E2C;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class ChartDataInitilalizer : MonoBehaviour
{
    public E2Chart E2Chart;
    public E2ChartData E2ChartData;

    private void Start()
    {
        /*Dictionary<DateTime, float> temperatureData = GenerateTemperatureData(100);

        BuildChart(temperatureData, "Temperature", "Линия 1");*/
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

    public void BuildChart(Dictionary<DateTime, float> data, string parametrName, string productionLine)
    {
        E2ChartData.Series series = new E2ChartData.Series();
        series.name = parametrName;
        E2ChartData.title = productionLine;
        series.dataY = new List<float>(data.Values);
        E2ChartData.series.Add(series);

        E2ChartData.categoriesX = new List<string>(data.Keys.Select(date => date.ToString("dd/MM/yyyy HH:mm:ss")));
               

        E2Chart.UpdateChart();
    }
    public void BuildChart(Dictionary<DateTime, float> data, string parametrName, string productionLine, DateTime FirstDate, DateTime LastDate)
    {
        E2ChartData.Series series = new E2ChartData.Series();
        series.name = parametrName;
        E2ChartData.title = productionLine;

        // Фильтруем ключи по заданному промежутку
        var filteredData = data.Where(pair => pair.Key >= FirstDate && pair.Key <= LastDate)
                              .ToDictionary(pair => pair.Key, pair => pair.Value);

        series.dataY = new List<float>(filteredData.Values);
        E2ChartData.series.Add(series);

        E2ChartData.categoriesX = new List<string>(filteredData.Keys.Select(date => date.ToString("dd/MM/yyyy HH:mm:ss")));
        // Здесь мы используем Select для преобразования каждой даты в строку
        // и добавляем ее в список категорий

        E2Chart.UpdateChart();
    }


    public void ClearChart()
    {
        E2ChartData.series.Clear();
        E2ChartData.categoriesX.Clear();
        E2ChartData.categoriesY.Clear();
    }
}
