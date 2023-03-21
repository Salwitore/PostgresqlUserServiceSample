using Data.EntityClasses;

namespace Business.RabbitMQ.Interfaces
{
    public interface IUserProducer
    {

        void PublishUser(User user);
    }
}
