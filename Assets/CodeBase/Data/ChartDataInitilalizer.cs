using E2C;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartDataInitilalizer : MonoBehaviour
{
    public E2Chart E2Chart;
    public E2ChartData E2ChartData;
    public List<float> testData = new List<float>() { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f };

    private void Start()
    {
        E2ChartData.Series test = new E2ChartData.Series();
        test.name = "test";
        test.dataY = testData;
        E2ChartData.series.Add(test);
        E2ChartData.categoriesX = new List<string>() { "hello", "hello", "hello", "hello" };

        E2Chart.UpdateChart();
    }
}
