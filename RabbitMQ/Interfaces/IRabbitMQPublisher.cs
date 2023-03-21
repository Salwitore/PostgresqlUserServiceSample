namespace RabbitMQ.Interfaces
{
    public interface IRabbitMQPublisher
    {
        void Publish(string queueName, object message);
    }
}
