using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Authorization : MonoBehaviour
{
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public Button loginButton;
    public Toggle rememberMeToggle;
    public Toggle showPasswordToggle;
    public GameObject ObjectWindow;

    private void Start()
    {
        loginButton.onClick.AddListener(OnLoginButtonClicked);
        showPasswordToggle.onValueChanged.AddListener(OnShowPasswordToggleChanged); 

        // Загрузить сохраненные данные пользователя, если они есть
        if (PlayerPrefs.HasKey("email") && PlayerPrefs.HasKey("password"))
        {
            emailInputField.text = PlayerPrefs.GetString("email");
            passwordInputField.text = PlayerPrefs.GetString("password");
            rememberMeToggle.isOn = PlayerPrefs.GetInt("rememberMe") == 1;
        }
    }

    private void OnShowPasswordToggleChanged(bool showPassword)
    {
        if (showPassword)
        {
            passwordInputField.contentType = TMP_InputField.ContentType.Standard; // Показать пароль
        }
        else
        {
            passwordInputField.contentType = TMP_InputField.ContentType.Password; // Скрыть пароль
        }

        // Обновить поле ввода, чтобы применить новый тип содержимого
        passwordInputField.ForceLabelUpdate();
    }

    private void OnLoginButtonClicked()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        // Проверка валидности данных
        if (IsValidEmail(email) && IsValidPassword(password))
        {
            // Отправить запрос на сервер для проверки существования пользователя
            bool userExists = CheckUserExists(email, password);

            if (userExists)
            {
                // Отправить второй запрос для получения данных пользователя
                GetUserDetails(email, password);

                // Сохранить данные пользователя, если выбрана опция "запомнить меня"
                if (rememberMeToggle.isOn)
                {
                    PlayerPrefs.SetString("email", email);
                    PlayerPrefs.SetString("password", password);
                    PlayerPrefs.SetInt("rememberMe", 1);
                }
                else
                {
                    PlayerPrefs.DeleteKey("email");
                    PlayerPrefs.DeleteKey("password");
                    PlayerPrefs.SetInt("rememberMe", 0);
                }

                EndAuthorization();
            }
            else
            {
                Debug.Log("Пользователь не найден");
            }
        }
        else
        {
            Debug.Log("Неверные данные");
        }
    }

    private void EndAuthorization()
    {
        ObjectWindow.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private bool IsValidEmail(string email)
    {
        // Простая проверка электронной почты с использованием System.Net.Mail
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private bool IsValidPassword(string password)
    {
        // Простая проверка пароля на длину
        if (password.Length < 8)
        {
            return false;
        }

        // Дополнительные проверки могут включать проверку на наличие цифр, специальных символов и т.д.
        return true;
    }


    private bool CheckUserExists(string email, string password)
    {
        Debug.Log("CheckUserExists");
        return true;
    }

    private void GetUserDetails(string email, string password)
    {
        Debug.Log("GetUserDetails");
;    }
}
