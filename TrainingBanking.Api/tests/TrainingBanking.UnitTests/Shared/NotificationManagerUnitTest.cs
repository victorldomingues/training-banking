using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingBanking.Shared.Notifications;
using TrainingBanking.Shared.Notifications.Contracts;

namespace TrainingBanking.UnitTests.Shared
{
    [TestClass]
    public class NotificationManagerUnitTest
    {
        private INotifications _notifications;
        [TestInitialize]
        public void Setup()
        {
            _notifications = new NotificationManager();
        }

        [TestMethod]
        public void Should_Be_Adding_A_Notification()
        {

            var notificationsCount = _notifications.Notifications.Count;
            _notifications.Add("Test", "MyKey");

            var notificationByKey = _notifications.Notifications.FirstOrDefault(x => x.Key == "MyKey");

            Assert.AreEqual(notificationsCount + 1, _notifications.Notifications.Count);

            Assert.IsNotNull(notificationByKey);

        }

        [TestMethod]
        public void Should_Be_Adding_Many_Notifications()
        {

            var notificationsCount = _notifications.Notifications.Count;

            _notifications.Add(new List<Notification>()
            {
                new Notification()
                {
                    Message = "Test 2",
                    Key = "MyKey2"
                },
                new Notification()
                {
                    Message = "Test 3",
                    Key = "MyKey3"
                }
            });

            var notificationByKey2 = _notifications.Notifications.FirstOrDefault(x => x.Key == "MyKey2");
            var notificationByKey3 = _notifications.Notifications.FirstOrDefault(x => x.Key == "MyKey3");


            Assert.AreEqual(notificationsCount + 2, _notifications.Notifications.Count);

            Assert.IsNotNull(notificationByKey2);

            Assert.IsNotNull(notificationByKey3);

        }


        [TestMethod]
        public void Should_Be_Invalid_Having_Notifications()
        {
            var notificationsCount = _notifications.Notifications.Count;
            var isValid = notificationsCount < 1;

            Assert.AreEqual(_notifications.IsValid(), isValid);
            Assert.AreEqual(_notifications.IsValid(), true);
            
            _notifications.Add("Test", "MyKey");
            
            notificationsCount = _notifications.Notifications.Count;
            
            isValid = notificationsCount < 1;

            Assert.AreEqual(_notifications.IsValid(), isValid);
            Assert.AreEqual(_notifications.IsValid(), false);
        }
    }
}
