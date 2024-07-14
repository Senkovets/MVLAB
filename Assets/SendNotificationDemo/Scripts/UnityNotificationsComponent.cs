﻿using UnityEngine;
using Unity.Notifications.Android;

public class UnityNotificationsComponent : MonoBehaviour
{
    private void Awake()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Name = "News|Новости.",
            Description = "Новости о проекте.",
            Id = "news",
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

        AndroidNotificationCenter.SendNotification(notification, "news");
    }
    
}