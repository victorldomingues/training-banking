using System.Collections.Generic;
using System.Linq;
using TrainingBanking.Shared.Notifications.Contracts;

namespace TrainingBanking.Shared.Notifications
{
    /// <summary>
    /// By Victor Domingues
    /// </summary>
    public class NotificationManager : INotifications
    {
        private readonly List<Notification> _notifications;
        public NotificationManager()
        {
            _notifications =  new List<Notification>();
        }

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public void Add(string message, string key = null)
        {
            _notifications.Add(new Notification()
            {
                Message = message,
                Key = key
            });
        }

        public void Add(IEnumerable<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public bool IsValid()
        {
            return !Notifications.Any();
        }
    }
}
