using Microsoft.Extensions.DependencyInjection;
using TrainingBanking.Shared.Notifications.Contracts;

namespace TrainingBanking.Shared.Notifications.Extensions
{
    public static class UseNotificationExtension
    {
        public static void UseNotifications(this IServiceCollection services)
        {
            services.AddScoped<INotifications, NotificationManager>();
        }
    }
}
