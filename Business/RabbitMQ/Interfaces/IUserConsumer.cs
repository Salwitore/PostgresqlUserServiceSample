using Data.EntityClasses;

namespace Business.RabbitMQ.Interfaces
{
    public interface IUserConsumer
    {
        User ConsumeUser(string queue);
    }
}
