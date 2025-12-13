using UnityEngine;
using Unity.Notifications.Android;
using System;

public class PushNotifications : MonoBehaviour
{
    // https://www.youtube.com/watch?v=fTpL7OSB4Gc
    public GameObject enableNotificationsButton;
    public AndroidNotificationChannel notificationChannel;
    public AndroidNotification notification;
    public DateTime now = DateTime.Now;
    public DateTime fireTime;

    void Start() {
        if (Application.isEditor) {
            Debug.Log("Running in Editor - Notifications Disabled");
            return;
        } else {
            InitialRequestPermission();
        }
    }

    public async void RequestPermission() {
        AndroidRuntimePermissions.Permission result = await AndroidRuntimePermissions.RequestPermissionAsync("android.permission.POST_NOTIFICATIONS");
        if (result == AndroidRuntimePermissions.Permission.Granted) {
            Debug.Log("Notification permission granted.");
            enableNotificationsButton.SetActive(false);
            ScheduleNotification();
        } else if (result == AndroidRuntimePermissions.Permission.Denied) {
            AndroidRuntimePermissions.OpenSettings();
        }
    }

    // :P
    async void InitialRequestPermission() {
        AndroidRuntimePermissions.Permission result = await AndroidRuntimePermissions.RequestPermissionAsync("android.permission.POST_NOTIFICATIONS");
        if (result == AndroidRuntimePermissions.Permission.Granted) {
            Debug.Log("Notification permission granted.");
            enableNotificationsButton.SetActive(false);
            ScheduleNotification();
        } else if (result == AndroidRuntimePermissions.Permission.Denied) {
            return;
        }
    }

    // Some of the code below is attributed to Microsoft Copilot

    void ScheduleNotification() {
        notificationChannel = new AndroidNotificationChannel() {
            Id = "daily_reminder_channel",
            Name = "Daily Reminders",
            Importance = Importance.High,
            Description = "Daily notifications for your app."
        };
        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        fireTime = new DateTime(now.Year, now.Month, now.Day, 9, 0, 0); // Example: 9:00 AM daily

        // If the desired fire time has already passed today, schedule for tomorrow
        if (fireTime < now) {
            fireTime = fireTime.AddDays(1);
        }

        notification = new AndroidNotification() {
            Title = "Daily Reminder",
            Text = "Don't forget to complete your missions!",
            FireTime = fireTime,
            RepeatInterval = TimeSpan.FromDays(1),
            SmallIcon = "icon_0",
            ShowTimestamp = false
        };

        // Cancel any previously scheduled notifications to avoid duplicates and clear any existing ones
        AndroidNotificationCenter.CancelAllNotifications();
        AndroidNotificationCenter.SendNotification(notification, notificationChannel.Id);
    }
}
