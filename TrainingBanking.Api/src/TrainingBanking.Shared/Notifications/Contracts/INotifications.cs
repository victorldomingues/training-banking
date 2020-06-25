using System.Collections.Generic;

namespace TrainingBanking.Shared.Notifications.Contracts
{
    /// <summary>
    /// By Victor Domingues
    /// </summary>
    public interface INotifications
    {
        IReadOnlyCollection<Notification> Notifications { get; }
        void Add(string message, string key = null);
        void Add(IEnumerable<Notification> notifications);
        bool IsValid();
    }
}
