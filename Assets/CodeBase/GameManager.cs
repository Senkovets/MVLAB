using Bitsplash.DatePicker.Tutorials;
using System;
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

    public SelectionTutorial SelectionTutorial;
    public ChartDataInitilalizer ChartDataInitilalizer;

    public Button ViewChartButton;

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
        Debug.Log("ViewChartButton");
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

    public void OpenSettings()
    {
        CloseAllWindows();
        // ��� ��� ��� �������� ��������
        settingsWindow.SetActive(true);
    }
}
