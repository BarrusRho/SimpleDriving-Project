using System;
using UnityEngine;

#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

namespace MobileGameDev.SimpleDriving
{
    public class NotificationHandler : MonoBehaviour
    {
#if UNITY_ANDROID
        private const string ChannelId = "notification_channel";

        public void ScheduleNotification(DateTime dateTime)
        {
            AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel
            {
                Id = ChannelId,
                Name = "Notification Channel",
                Description = "Some random description",
                Importance = Importance.Default
            };

            AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

            AndroidNotification notification = new AndroidNotification
            {
                Title = "Energy Rechardged!",
                Text = "Your energy has recharged, CustomTimestamp back and play again!",
                SmallIcon = "default",
                LargeIcon = "default",
                FireTime = dateTime
            };

            AndroidNotificationCenter.SendNotification(notification, ChannelId);

        }
#endif
    }
}