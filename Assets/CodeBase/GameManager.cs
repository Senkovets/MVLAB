using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Статическая переменная для хранения единственного экземпляра класса
    public static GameManager Instance { get; private set; }

    // Переменные для хранения объектов окон
    public GameObject authorizationWindow;
    public GameObject objectsWindow;
    public GameObject graphWindow;
    public GameObject settingsWindow;

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

    public void OpenSettings()
    {
        CloseAllWindows();
        // Ваш код для открытия настроек
        settingsWindow.SetActive(true);
    }
}
