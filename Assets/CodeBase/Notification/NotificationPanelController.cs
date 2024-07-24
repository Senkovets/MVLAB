using UnityEngine;

public class NotificationPanelController : MonoBehaviour
{
    public NotificationSetting NotificationSettingPrefab;
    private ProductionLine _currentProductionLine;
    void Start()
    {
        Debug.Log("sas");
        _currentProductionLine = GameManager.Instance.CurrentProductionLine;
        foreach (var item in _currentProductionLine._parametrs)
        {
            Debug.Log(item);
            NotificationSetting line = Instantiate(NotificationSettingPrefab, transform.position, Quaternion.identity);
            line.transform.SetParent(transform);
            line.transform.localScale = Vector3.one;
            line.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            line.transform.localPosition = Vector3.zero;
            line.UpdateView(item.Key, false, 2f);
        }
    }

    void Update()
    {

    }
}
