using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ����������� ���������� ��� �������� ������������� ���������� ������
    public static GameManager Instance { get; private set; }

    // ���������� ��� �������� �������� ����
    public GameObject authorizationWindow;
    public GameObject objectsWindow;
    public GameObject graphWindow;
    public GameObject settingsWindow;

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
