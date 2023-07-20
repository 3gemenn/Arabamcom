using Arabamcom.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arabamcom.Core.Services;
using System.Threading.Tasks;
using Arabamcom.Repository.DbContext;
using Arabamcom.Core.DTOs;
using Arabamcom.Core.Enums;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Dapper;
using Arabamcom.Core.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Arabamcom.Service.Services
{
    public class AdvertVisitService : IAdvertVisitService
    {
        private readonly ConnectionHelper _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private bool noAck;

        public AdvertVisitService(ConnectionHelper context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Record(int id)
        {
            try
            {
                new Thread(async () =>
                {
                    var factory = new ConnectionFactory()
                    {
                        HostName = "localhost"
                    };
                    using (IConnection connection = factory.CreateConnection())
                    using (IModel channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "Record",
                                                         durable: false,
                                                         exclusive: false,
                                                         autoDelete: false,
                                                         arguments: null);

                        var consumer = new EventingBasicConsumer(channel);

                        channel.BasicConsume(queue: "Record",
                                                 noAck = true,
                                                 consumer: consumer);
                    }
                    while (true)
                    {
                        string? ipAddress = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
                        //string ipAddress = "34655346";
                        string query = "";
                        var date = DateTime.Now;
                        query = "INSERT INTO AdvertVisits(AdvertId,IpAdress,VisitDate) VALUES (@AdvertId,@IpAdress,@VisitDate)";
                        using (var connection = _context.CreateConnection())
                        {
                            var table = new AdvertVisit
                            {
                                AdvertId = id,
                                IpAdress = ipAddress,
                                VisitDate = date,

                            };

                            await connection.ExecuteAsync(query, table);
                            
                        }
                    }
                }).Start();
                return true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                return false;
            }
           
               


        }


    }
}


