using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotificationSetting : MonoBehaviour
{
    public string Name;
    public Toggle toggleButton;
    public TextMeshProUGUI textMeshProUGUI;
    public TMP_InputField inputField;

    //private Dictionary<string, NotificaationData> _notificaations;

    public void UpdateView(string name, bool isOn, float value)
    {
        Name = name;
        textMeshProUGUI.text = name;
        inputField.text = value.ToString();
        ChangeNotificationState(isOn);
    }

    private void Start()
    {
       // _notificaations = GameManager.Instance.CurrentProductionLine.Notificaations;
        toggleButton.onValueChanged.AddListener(OnToggleValueChanged);
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
    }

    public void ChangeNotificationState(bool isOn)
    {
        toggleButton.isOn = isOn;
        OnToggleValueChanged(isOn);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        // Обработка события переключения
        if (isOn)
        {
            // Когда переключатель включен
            Debug.Log("Toggle is ON");
            inputField.interactable = true; // Делаем inputField интерактивным
            SetTextAlpha(1f); // Устанавливаем полную непрозрачность
                              // Обновляем BoolValue в словаре
            GameManager.Instance.CurrentProductionLine.Notificaations[Name].BoolValue = true;
        }
        else
        {
            // Когда переключатель выключен
            Debug.Log("Toggle is OFF");
            inputField.interactable = false; // Делаем inputField неинтерактивным
            SetTextAlpha(0.75f); // Устанавливаем прозрачность на 75%
                                 // Обновляем BoolValue в словаре
            GameManager.Instance.CurrentProductionLine.Notificaations[Name].BoolValue = false;
        }
    }

    public void OnInputFieldValueChanged(string newValue)
    {
        float floatValue;
        if (float.TryParse(newValue, out floatValue))
        {
            // Введенное значение успешно преобразовано в float
            // Обновляем FloatValue в словаре
            GameManager.Instance.CurrentProductionLine.Notificaations[Name].FloatValue = floatValue;
        }
        else
        {
            // Не удалось преобразовать введенное значение в float
            // Можно вывести сообщение об ошибке или выполнить другие действия
        }
    }


    private void SetTextAlpha(float alpha)
    {
        Color currentColor = textMeshProUGUI.color;
        textMeshProUGUI.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
    }

    private void OnDisable()
    {
        toggleButton.onValueChanged.RemoveListener(OnToggleValueChanged);
        inputField.onValueChanged.RemoveListener(OnInputFieldValueChanged);
    }
}
