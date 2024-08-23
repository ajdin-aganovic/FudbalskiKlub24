//// See https://aka.ms/new-console-template for more information
using EasyNetQ;
using FudbalskiKlub.Model.Messages;
using FudbalskiKlub.Services.Model;
using FudbalskiKlub.Subscriber;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


var factory = new ConnectionFactory
{
    HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "rabbitmq",
    Port = int.Parse(Environment.GetEnvironmentVariable("RABBITMQ_PORT") ?? "5672"),
    UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest",
    Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest",
};
factory.ClientProvidedName = "Rabbit Test Consumer";
IConnection connection = factory.CreateConnection();
IModel channel = connection.CreateModel();

string exchangeName = "EmailExchange";
string routingKey = "email_queue";
string queueName = "EmailQueue";

channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
channel.QueueDeclare(queueName, true, false, false, null);
channel.QueueBind(queueName, exchangeName, routingKey, null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, args) =>
{
    var body = args.Body.ToArray();
    string message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Primljena poruka: {message}");
    //EmailJS emailService = new EmailJS();
    //emailService.SendEmail("aydox09@gmail.com", "Obavijest od Fudbalskog kluba", "Samo jedan testni mail");

    channel.BasicAck(args.DeliveryTag, false);
};

channel.BasicConsume(queueName, false, consumer);

Console.WriteLine("Cekaju se poruke. Pritisnite 'Q' da izadjete iz aplikacije.");

Thread.Sleep(Timeout.Infinite);

channel.Close();
connection.Close();
