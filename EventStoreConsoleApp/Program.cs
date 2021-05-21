using EventStore.ClientAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventStoreConsoleApp
{
    class Program
    {
        static string StreamId(Guid id) => String.Format("BankAccount {0}", id.ToString());


        static void Main(string[] args)
        {
            IEventStoreConnection connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.ConnectAsync();

            var aggregateId = Guid.NewGuid();
            Console.WriteLine($"Aggregate ID: {aggregateId}");
            List<IEvent> events = new List<IEvent>();

            events.Add(new AccountCreated(aggregateId, "Bitter Bite"));
            events.Add(new FundsDeposited(aggregateId, 150));
            events.Add(new FundsDeposited(aggregateId, 100));
            events.Add(new FundsWithdrawed(aggregateId, 60, "bite hard drive"));
            events.Add(new FundsWithdrawed(aggregateId, 94, "bite cpu"));
            events.Add(new FundsDeposited(aggregateId, 4));

            foreach (var evt in events)
            {
                var jsonString = JsonConvert
                    .SerializeObject(evt, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.None });

                var jsonPayload = Encoding.UTF8.GetBytes(jsonString);
                var esDataType = new EventData(Guid.NewGuid(), evt.GetType().Name, true, jsonPayload, null);
                connection.AppendToStreamAsync(StreamId(aggregateId), ExpectedVersion.Any, esDataType);
            }

            var results = Task.Run(() =>
                connection.ReadStreamEventsForwardAsync(StreamId(aggregateId), StreamPosition.Start, 999, false));
            Task.WaitAll();
            var resultsData = results.Result;

            var bankState = new BankAccount();
            foreach (var evnt in resultsData.Events)
            {
                var esJsonData = Encoding.UTF8.GetString(evnt.Event.Data);
                Console.WriteLine($"state change: {evnt.Event.EventType}");
                if (evnt.Event.EventType == "AccountCreated")
                {
                    var state = JsonConvert.DeserializeObject<AccountCreated>(esJsonData);
                    bankState.Apply(state);
                }
                else if (evnt.Event.EventType == "FundsDespoited")
                {
                    var state = JsonConvert.DeserializeObject<FundsDeposited>(esJsonData);
                    bankState.Apply(state);
                }
                else
                {
                    var state = JsonConvert.DeserializeObject<FundsWithdrawed>(esJsonData);
                    bankState.Apply(state);
                    Console.WriteLine($"transaction reason: {state.Reason}");
                }

                Console.WriteLine($"CurrentBalance: {bankState.CurrentBalance}");

            }

            Console.WriteLine($"Final State after replay : {bankState.CurrentBalance}");

            Console.ReadLine();
        }
    }
}
