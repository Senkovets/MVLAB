using Bitsplash.DatePicker.Tutorials;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Статическая переменная для хранения единственного экземпляра класса
    public static GameManager Instance { get; private set; }

    // Переменные для хранения объектов окон
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
        // Проверка, существует ли уже экземпляр класса
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Переводим объект в режим "не уничтожать"
        }
        else
        {
            Destroy(gameObject); // Уничтожаем дубликат
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
        // Закрыть все окна
        authorizationWindow.SetActive(false);
        objectsWindow.SetActive(false);
        graphWindow.SetActive(false);
        settingsWindow.SetActive(false);
    }

    public void OpenAuthorization()
    {
        CloseAllWindows();
        // Ваш код для открытия окна авторизации
        authorizationWindow.SetActive(true);
    }

    public void OpenObjectsWindow()
    {
        CloseAllWindows();
        // Ваш код для открытия окна объектов
        objectsWindow.SetActive(true);
    }

    public void OpenGraph()
    {
        CloseAllWindows();
        // Ваш код для открытия графика
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
        // Ваш код для открытия настроек
        settingsWindow.SetActive(true);
    }

    private void UpdateDropdownOptions()
    {
        // Очистите текущие опции
        ParametrDropdown.ClearOptions();

        // Получите ключи из _parametrs
        List<string> keys = new List<string>(CurrentProductionLine._parametrs.Keys);

        // Добавьте каждый ключ в опции
        foreach (string key in keys)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData(key);
            ParametrDropdown.options.Add(optionData);
        }

        // Выберите первую опцию (если нужно)
        ParametrDropdown.value = 0;
        ParametrDropdown.RefreshShownValue();
    }
}
