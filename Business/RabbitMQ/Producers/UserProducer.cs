using Business.RabbitMQ.Interfaces;
using Data.EntityClasses;
using Newtonsoft.Json;
using RabbitMQ.Producer;

namespace Business.RabbitMQ.Producers
{
    public class UserProducer : IUserProducer
    {
        public void PublishUser(User user)
        {
            RabbitMQProducer.Instance.Publish("UserQueue",JsonConvert.SerializeObject(user));
        }
    }
}
