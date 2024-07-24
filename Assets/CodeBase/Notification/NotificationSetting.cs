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
        // ��������� ������� ������������
        if (isOn)
        {
            // ����� ������������� �������
            Debug.Log("Toggle is ON");
            inputField.interactable = true; // ������ inputField �������������
            SetTextAlpha(1f); // ������������� ������ ��������������
        }
        else
        {
            // ����� ������������� ��������
            Debug.Log("Toggle is OFF");
            inputField.interactable = false; // ������ inputField ���������������
            SetTextAlpha(0.75f); // ������������� ������������ �� 75%
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
