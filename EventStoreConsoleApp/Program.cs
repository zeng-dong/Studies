using EventStore.ClientAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EventStoreConsoleApp
{
    class Program
    {
        static string StreamId(Guid id) => String.Format("BankAccount {0}", id.ToString());


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IEventStoreConnection connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.ConnectAsync();

            var aggregateId = Guid.NewGuid();
            List<IEvent> events = new List<IEvent>();

            events.Add(new AccountCreated(aggregateId, "Bitter Bite"));
            events.Add(new FundsDespoited(aggregateId, 150));
            events.Add(new FundsDespoited(aggregateId, 100));
            events.Add(new FundsWithdrawed(aggregateId, 60));
            events.Add(new FundsWithdrawed(aggregateId, 94));
            events.Add(new FundsDespoited(aggregateId, 4));

            foreach (var evt in events)
            {
                var jsonString = JsonConvert
                    .SerializeObject(evt, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None });

                var jsonPayload = Encoding.UTF8.GetBytes(jsonString);
                var esDataType = new EventData(Guid.NewGuid(), evt.GetType().Name, true, jsonPayload, null);
                connection.AppendToStreamAsync(StreamId(aggregateId), ExpectedVersion.Any, esDataType);
            }

            Console.ReadLine();
        }
    }
}
