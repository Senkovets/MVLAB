using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotificationSetting : MonoBehaviour
{
    public string Name;
    public Toggle toggleButton;
    public TextMeshProUGUI textMeshProUGUI;
    public TMP_InputField inputField;

    public void UpdateView(string Name, bool isOn, float value)
    {
        textMeshProUGUI.text = Name;
        inputField.text = value.ToString();
        ChangeNotificationState(isOn);
    }

    private void Start()
    {
        toggleButton.onValueChanged.AddListener(OnToggleValueChanged);
    }

    public void ChangeNotificationState(bool isOn)
    {
        toggleButton.isOn = isOn;
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
        }
        else
        {
            // Когда переключатель выключен
            Debug.Log("Toggle is OFF");
            inputField.interactable = false; // Делаем inputField неинтерактивным
            SetTextAlpha(0.75f); // Устанавливаем прозрачность на 75%
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
    }
}
