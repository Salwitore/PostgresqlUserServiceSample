using RabbitMQ.Consumer;

class Program
{
    static void Main(string[] args)
    {

        ThreadPool.QueueUserWorkItem(delegate
        {
            var json = RabbitMQConsumer.Instance.RabbitConsumer("UserQueue");
        });
    }
}
