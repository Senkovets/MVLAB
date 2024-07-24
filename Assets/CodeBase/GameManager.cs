using Bitsplash.DatePicker.Tutorials;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ����������� ���������� ��� �������� ������������� ���������� ������
    public static GameManager Instance { get; private set; }

    // ���������� ��� �������� �������� ����
    public GameObject authorizationWindow;
    public GameObject objectsWindow;
    public GameObject graphWindow;
    public GameObject settingsWindow;

    public SelectionTutorial DataPicker;
    public ChartDataInitilalizer ChartDataInitilalizer;

    public TMP_Dropdown ParametrDropdown;
    public Button ViewChartButton;

    public ProductionLine CurrentProductionLine;

    private void Awake()
    {
        // ��������, ���������� �� ��� ��������� ������
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ��������� ������ � ����� "�� ����������"
        }
        else
        {
            Destroy(gameObject); // ���������� ��������
        }
    }

    private void Start()
    {
        ViewChartButton.onClick.AddListener(OnViewChartButtonClicked);
    }

    private void OnViewChartButtonClicked()
    {
        Debug.Log("ViewChartButton_Build");
        BuildChart();
    }

    public void BuildChart()
    {
        ChartDataInitilalizer.BuildChart(CurrentProductionLine.GetParameterData(ParametrDropdown.options[ParametrDropdown.value].text),
                                         ParametrDropdown.options[ParametrDropdown.value].text,
                                         CurrentProductionLine.Name);
    }
    private void CloseAllWindows()
    {
        // ������� ��� ����
        authorizationWindow.SetActive(false);
        objectsWindow.SetActive(false);
        graphWindow.SetActive(false);
        settingsWindow.SetActive(false);
    }

    public void OpenAuthorization()
    {
        CloseAllWindows();
        // ��� ��� ��� �������� ���� �����������
        authorizationWindow.SetActive(true);
    }

    public void OpenObjectsWindow()
    {
        CloseAllWindows();
        // ��� ��� ��� �������� ���� ��������
        objectsWindow.SetActive(true);
    }

    public void OpenGraph()
    {
        CloseAllWindows();
        // ��� ��� ��� �������� �������
        graphWindow.SetActive(true);
    }

    public void OpenGraph(ProductionLine productionLine)
    {
        CloseAllWindows();
        graphWindow.SetActive(true);
        CurrentProductionLine = productionLine;

        DataPicker.SelectDateRange();
        UpdateDropdownOptions();
    }

    public void OpenSettings()
    {
        CloseAllWindows();
        // ��� ��� ��� �������� ��������
        settingsWindow.SetActive(true);
    }

    private void UpdateDropdownOptions()
    {
        // �������� ������� �����
        ParametrDropdown.ClearOptions();

        // �������� ����� �� _parametrs
        List<string> keys = new List<string>(CurrentProductionLine._parametrs.Keys);

        // �������� ������ ���� � �����
        foreach (string key in keys)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData(key);
            ParametrDropdown.options.Add(optionData);
        }

        // �������� ������ ����� (���� �����)
        ParametrDropdown.value = 0;
        ParametrDropdown.RefreshShownValue();
    }
}
