using System;
using System.Net.NetworkInformation;

namespace NotificationAppStructural
{
    class Program
    {
        static void Main(string[] args)
        {
            INotification notification = new SimpleNotification("Olá, mundo!");
            INotification decoratedNotification = new NotificationLoggerDecorator(notification);
            decoratedNotification.Send();
        }
    }

    public interface INotification
    {
        void Send();
    }

    public class SimpleNotification : INotification
    {
        private readonly string _message;
        public SimpleNotification(string message) => _message = message;
        public void Send() => Console.WriteLine($"Enviando notificação: {_message}");
    }

    public class NotificationLoggerDecorator : INotification
    {
        private readonly INotification _innerNotification ;
        public NotificationLoggerDecorator(INotification notification) => _innerNotification  = notification;
        public void Send()
        {
            Console.WriteLine("Log: Iniciando o envio da notificação.");
            _innerNotification.Send();
            Console.WriteLine("Log: Notificação enviada com sucesso.");
        }
    }
}