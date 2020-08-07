using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Infrastructure.RabbitMQ
{
    public class RabbitMQConfiguration
    {
        public string HostName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }
    }
}
