var factory =  new ConnectionFactory() { HostName = "localhost"};

using var connection = factory.CreateConnection();

using var chanel = connection.CreateModel();

chanel.QueueDeclare("first", exclusive: false, durable: true, autoDelete: false, arguments: null);

while (true)
{
    var body = Encoding.UTF8.GetBytes(Console.ReadLine() ?? string.Empty);
        
    chanel.BasicPublish(exchange: "", routingKey: "first", basicProperties: null, body: body);
}

