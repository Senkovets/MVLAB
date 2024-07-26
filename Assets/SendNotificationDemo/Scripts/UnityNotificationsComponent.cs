using UnityEngine;
using Unity.Notifications.Android;

public class UnityNotificationsComponent : MonoBehaviour
{
    private void Awake()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Name = "Notification|Предупреждения",
            Description = "Предупреждения о превышении параметров на линиях",
            Id = "Notification",
            Importance = Importance.High,
        };
        
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void SendNotification()
    {
        AndroidNotification notification = new AndroidNotification()
        {
            Title = "Заголовок тестового уведомления",
            Text = "Текст тестового уведомления. | Текст тестового уведомления. | Текст тестового уведомления.",
            FireTime = System.DateTime.Now.AddSeconds(5),
            SmallIcon = "icon_0",
            LargeIcon = "icon_1"
        };

        AndroidNotificationCenter.SendNotification(notification, "Notification");
    }

    public void SendNotification(string lineName, string parameter, float value)
    {
        string title = $"Предупреждение: {parameter} на линии {lineName} превысил норму";
        string text = $"На линии {lineName}, значение параметра {parameter} достигло {value}, что превышает норму.";

        AndroidNotification notification = new AndroidNotification()
        {
            Title = title,
            Text = text,
            FireTime = System.DateTime.Now.AddSeconds(5),
            SmallIcon = "icon_0",
            LargeIcon = "icon_1"
        };

        AndroidNotificationCenter.SendNotification(notification, "Notification");
    }
}
