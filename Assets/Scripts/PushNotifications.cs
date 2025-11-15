using UnityEngine;
using Unity.Notifications.Android;
using System;

public class PushNotifications : MonoBehaviour
{
    // https://www.youtube.com/watch?v=fTpL7OSB4Gc
    public AndroidNotificationChannel notificationChannel;
    public AndroidNotification notification;
    public DateTime now = DateTime.Now;
    public DateTime fireTime;

    void Start() {
        if (Application.isEditor) {
            Debug.Log("Running in Editor - Notifications Disabled");
            return;
        } else {
            RequestPermission();
        }
    }

    async void RequestPermission() {
        AndroidRuntimePermissions.Permission result = await AndroidRuntimePermissions.RequestPermissionAsync("android.permission.POST_NOTIFICATIONS");
        if (result == AndroidRuntimePermissions.Permission.Granted) {
            Debug.Log("Notification permission granted.");
            ScheduleNotification();
        }
    }

    void ScheduleNotification() {
        if (PlayerPrefs.GetInt("NotificationScheduled", 0) == 1) {
            Debug.Log("Notification already scheduled.");
            return;
        }

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
            RepeatInterval = TimeSpan.FromDays(1), // Schedule for daily repetition
            FireTime = fireTime
        };

        AndroidNotificationCenter.SendNotification(notification, notificationChannel.Id);
        PlayerPrefs.SetInt("NotificationScheduled", 1);
    }
}
