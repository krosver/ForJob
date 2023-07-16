using System;
using System.Collections;
using Unity.Notifications.Android;
using UnityEngine;

public class Notification : MonoBehaviour
{
    [SerializeField] private CurrentNumber _currentHH;
    [SerializeField] private CurrentNumber _currentMM;
    void Start()
    {
        NotificationInitialize();
    }
    void NotificationInitialize()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "Alarm_id",
            Name = "Alarm",
            Importance = Importance.High,
            Description = "Generation notifications for alarm",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void SendNotification()
    {
        //RequestNotificationPermission();
        DateTime alarmTime = DateTime.Now;
        var notification = new AndroidNotification();
        notification.Title = "ALARM";
        notification.Text = $"{alarmTime}";
        DateTime fireTime = DateTime.Now;
        fireTime.AddHours(_currentHH.Current);
        fireTime.AddMinutes(_currentMM.Current);
        notification.FireTime = fireTime;

        AndroidNotificationCenter.SendNotification(notification, "Alarm_id");
    }
    IEnumerator RequestNotificationPermission()
    {
        var request = new PermissionRequest();
        while (request.Status == PermissionStatus.RequestPending)
            yield return null;
    }

}
