﻿using RabbitMQ.Client;

namespace RabbitMQ.Connection
{
    public class RabbitMQConnection
    {
        #region Properties

        private static readonly object _lockObj = new object();
        public IConnection Connection { get; set; }

        public bool IsConnected { get; set; } = false;

        #endregion

        public RabbitMQConnection()
        {
            GetConnection();
        }


        #region Method

        /// <summary>
        /// Rabbitmq bağlantısı oluşturup döner
        /// </summary>
        /// <returns></returns>
        public IConnection GetConnection()
        {
            if (IsConnected)
                return Connection;
            try
            {
                lock (_lockObj)
                {
                    if (IsConnected)
                        return Connection;
                    ConnectionFactory connectionFactory = new ConnectionFactory
                    {
                        Uri = new Uri("amqp://guest:guest@localhost:5672")
                    };
                    Connection = connectionFactory.CreateConnection();
                    IsConnected = true;
                    return Connection;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{"RabbitMQConnection" + ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Channel oluşturup döner(IModel NonThreadsafety çalıştiği için böyle düzenlendi)
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public IModel GetChannel(string queueName)
        {
            IModel channel = Connection.CreateModel();
            channel.QueueDeclare(queueName, false, false, true, null);

            return channel;
        }

        #endregion

    }
}
