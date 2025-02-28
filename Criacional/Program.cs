using System;

namespace NotificationAppCreational
{
    class Program
    {
        static void Main(string[] args)
        {
            INotification notification = NotificationFactory.CreateNotification("sms", "Olá, mundo!");
            notification.Send();
        }
    }
    
    public static class NotificationFactory
    {
        public static INotification CreateNotification(string type, string message)
        {
            return type.ToLower() switch
            {
                "email" => new EmailNotification(message),
                "sms" => new SMSNotification(message),
                _ => throw new ArgumentException("Tipo de notificação inválido")
            };
        }
    }

    public interface INotification
    {
        void Send();
    }

    public class EmailNotification : INotification
    {
        private readonly string _message;
        public EmailNotification(string message) => _message = message;
        public void Send() => Console.WriteLine($"Email: {_message}");
    }

    public class SMSNotification : INotification
    {
        private readonly string _message;
        public SMSNotification(string message) => _message = message;
        public void Send() => Console.WriteLine($"SMS: {_message}");
    }
}