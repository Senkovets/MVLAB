using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Authorization : MonoBehaviour
{
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public Button loginButton;
    public Toggle rememberMeToggle;

    private void Start()
    {
        loginButton.onClick.AddListener(OnLoginButtonClicked);

        // Загрузить сохраненные данные пользователя, если они есть
        if (PlayerPrefs.HasKey("email") && PlayerPrefs.HasKey("password"))
        {
            emailInputField.text = PlayerPrefs.GetString("email");
            passwordInputField.text = PlayerPrefs.GetString("password");
            rememberMeToggle.isOn = PlayerPrefs.GetInt("rememberMe") == 1;
        }
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
