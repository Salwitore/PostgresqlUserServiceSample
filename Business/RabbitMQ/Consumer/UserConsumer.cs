using Business.RabbitMQ.Interfaces;
using Data.EntityClasses;
using Newtonsoft.Json;
using RabbitMQ.Consumer;

namespace Business.RabbitMQ.Consumer
{
    public class UserConsumer : IUserConsumer
    {
        public User ConsumeUser(string queue)
        {
            var jsonUser = RabbitMQConsumer.Instance.RabbitConsumer("UserQueue");
            return JsonConvert.DeserializeObject<User>(jsonUser);

        }
    }
}
