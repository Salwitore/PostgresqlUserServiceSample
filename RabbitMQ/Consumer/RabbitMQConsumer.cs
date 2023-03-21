using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Connection;
using System.Text;

namespace RabbitMQ.Consumer
{
    public class RabbitMQConsumer
    {
        #region Member

        /// <summary>
        /// Bu class çağırıldığında tanımlanır
        /// </summary>
        private static readonly Lazy<RabbitMQConsumer>
            instance = new Lazy<RabbitMQConsumer>(() => new RabbitMQConsumer());

        /// <summary>
        /// Rabbitmq bağlantısı getirmek için oluşturulan class
        /// </summary>
        private RabbitMQConnection rabbitMqServices;

        /// <summary>
        /// Modeli dinlemek için kullanıclan event
        /// </summary>
        private EventingBasicConsumer eventingBasicConsumer;

        #endregion

        #region Property

        /// <summary>
        /// bu classa dışardan erişimi sağlar
        /// </summary>
        public static RabbitMQConsumer Instance => instance.Value;

        /// <summary>
        /// Rabbitmq bağlantısı getirmek için oluşturulan class
        /// </summary>
        public RabbitMQConnection RabbitMqServices
        {
            get
            {
                if (rabbitMqServices == null || !rabbitMqServices.IsConnected)
                {
                    rabbitMqServices = new RabbitMQConnection();
                }

                return rabbitMqServices;
            }
            set => rabbitMqServices = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        private RabbitMQConsumer()
        {
        }

        #endregion

        #region Method

        /// <summary>
        /// Gelen kuyruktaki mesajları okur
        /// </summary>
        /// <param name="queue"></param>
        public string RabbitConsumer(string queue)
        {
            try
            {
                IModel channel = RabbitMqServices.GetChannel(queue);
                eventingBasicConsumer = new EventingBasicConsumer(channel);
                eventingBasicConsumer.Received += EventingBasicConsumerOnReceived;
                var json = channel.BasicConsume(queue, true, eventingBasicConsumer);
                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex + "RabbitmqConsumer"}"
                );
                return null;
            }
        }

        /// <summary>
        ///kuyruktaki mesaj düştükten sonra çalışan metot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventingBasicConsumerOnReceived(object sender, BasicDeliverEventArgs e)
        {
            string jsonData = Encoding.UTF8.GetString(e.Body.ToArray());
            Console.WriteLine(jsonData);
        }
        #endregion
    }
}
