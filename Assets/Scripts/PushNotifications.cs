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

    // Some of the code below is attributed to Microsoft Copilot

    void ScheduleNotification() {
        // Check if a notification was already scheduled today
        string lastDate = PlayerPrefs.GetString("LastNotification", "");
        string today = DateTime.Now.ToString("yyyy-MM-dd");

        if (lastDate == today) {
            Debug.Log("Notification already scheduled today.");
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
        // Save today's date so we don't schedule twice
        PlayerPrefs.SetString("LastNotification", today);
    }
}
