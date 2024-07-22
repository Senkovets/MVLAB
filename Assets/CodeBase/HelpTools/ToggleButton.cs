using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    // Объект, который нужно показывать/прятать
    public GameObject targetObject;

    // Кнопка, которая будет переключать активность объекта
    public Button toggleButton;

    private void Start()
    {
        // Добавляем слушатель к кнопке
        toggleButton.onClick.AddListener(ToggleObject);
    }

    // Метод для переключения активности объекта
    private void ToggleObject()
    {
        // Если объект активен, делаем его неактивным, и наоборот
        targetObject.SetActive(!targetObject.activeSelf);
    }
}
