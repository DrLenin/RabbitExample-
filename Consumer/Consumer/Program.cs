var factory =  new ConnectionFactory() { HostName = "localhost"};

using var connection = factory.CreateConnection();

using var chanel = connection.CreateModel();

var consumer = new EventingBasicConsumer(chanel);

consumer.Received += (_, es) =>
{
    var body = es.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);
};

chanel.BasicConsume(queue: "first", autoAck: true, consumer: consumer);

Console.ReadKey();