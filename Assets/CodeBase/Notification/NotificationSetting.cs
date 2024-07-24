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
        // ��������� ������� ������������
        if (isOn)
        {
            // ����� ������������� �������
            Debug.Log("Toggle is ON");
            inputField.interactable = true; // ������ inputField �������������
            SetTextAlpha(1f); // ������������� ������ ��������������
                              // ��������� BoolValue � �������
            GameManager.Instance.CurrentProductionLine.Notificaations[Name].BoolValue = true;
        }
        else
        {
            // ����� ������������� ��������
            Debug.Log("Toggle is OFF");
            inputField.interactable = false; // ������ inputField ���������������
            SetTextAlpha(0.75f); // ������������� ������������ �� 75%
                                 // ��������� BoolValue � �������
            GameManager.Instance.CurrentProductionLine.Notificaations[Name].BoolValue = false;
        }
    }

    public void OnInputFieldValueChanged(string newValue)
    {
        float floatValue;
        if (float.TryParse(newValue, out floatValue))
        {
            // ��������� �������� ������� ������������� � float
            // ��������� FloatValue � �������
            GameManager.Instance.CurrentProductionLine.Notificaations[Name].FloatValue = floatValue;
        }
        else
        {
            // �� ������� ������������� ��������� �������� � float
            // ����� ������� ��������� �� ������ ��� ��������� ������ ��������
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
