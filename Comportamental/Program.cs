using System;
using System.Collections.Generic;

namespace NotificationAppBehavioral
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new NotificationSender();
            sender.Attach(new EmailSubscriber());
            sender.Detach(new SMSSubscriber());

            sender.SendNotification("Olá, mundo!");
        }
    }

    public class NotificationSender
    {
        private readonly List<INotificationObserver> _observers = new List<INotificationObserver>();

        public void Attach(INotificationObserver observer) => _observers.Add(observer);
        public void Detach(INotificationObserver observer) => _observers.Remove(observer);

        public void SendNotification(string message)
        {
            Console.WriteLine($"Enviando notificação: {message}");
            Notify(message);
        }

        private void Notify(string message)
        {
            foreach (var observer in _observers)
                observer.Update(message);
        }
    }

    public interface INotificationObserver
    {
        void Update(string message);
    }

    public class EmailSubscriber : INotificationObserver
    {
        public void Update(string message) => Console.WriteLine($"EmailSubscriver recebeu: {message}");
    }

    public class SMSSubscriber : INotificationObserver
    {
        public void Update(string message) => Console.WriteLine($"SMSSubscriver recebeu: {message}");
    }
}