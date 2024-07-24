using UnityEngine;

public class NotificationPanelController : MonoBehaviour
{
    public NotificationSetting NotificationSettingPrefab;
    private ProductionLine _currentProductionLine;
    private void OnEnable()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
            Debug.Log("destroy");
        }
        _currentProductionLine = GameManager.Instance.CurrentProductionLine;
        foreach (var item in _currentProductionLine.Notificaations)
        {
            Debug.Log("spawn");
            NotificationSetting line = Instantiate(NotificationSettingPrefab, transform.position, Quaternion.identity);
            line.transform.SetParent(transform);
            line.transform.localScale = Vector3.one;
            line.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            line.transform.localPosition = Vector3.zero;
            line.UpdateView(item.Key, item.Value.BoolValue, item.Value.FloatValue);
        }
    }

    void Update()
    {

    }
}
