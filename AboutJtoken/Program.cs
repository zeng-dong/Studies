using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace AboutJtoken
{
    class Program
    {
        static void Main(string[] args)
        {
            string responseString = @"{
    ""Main"": {
        ""type"": ""array"",
        ""items"": {
            ""type"": ""object"",
            ""properties"": {
                ""watchlistid"": {
                    ""type"": ""string"",
                    ""maxLength"": 20,
                    ""description"": ""Identification of the watch list. A watch list is a set of securities which is used for simulation in the Benchmark and Portfolio Analysis""
                },
                ""owner"": {
                    ""type"": ""string"",
                    ""readOnly"": true
                },
                ""watchlistname"": {
                    ""type"": ""string""
                },
                ""Items"": {
                    ""type"": ""array"",
                    ""items"": {
                        ""type"": ""object"",
                        ""properties"": {
                            ""watchtype"": {
                                ""type"": ""string"",
                                ""enum"": [
                                    ""Security"",
                                    ""Watch list""
                                ],
                                ""title"": ""Watch type""
                            },
                            ""securityid"": {
                                ""type"": ""string"",
                                ""title"": ""Security ID""
                            },
                            ""Securityno"": {
                                ""type"": ""string"",
                                ""title"": ""Security No.""
                            },
                            ""instrumenttype"": {
                                ""type"": ""string"",
                                ""title"": ""Instrument Type"",
                                ""readOnly"": true
                            },
                            ""watchlist"": {
                                ""type"": ""string"",
                                ""title"": ""Watch list"",
                                ""description"": ""Choose an existing Watch list, though not this""
                            },
                            ""segment"": {
                                ""type"": ""string"",
                                ""title"": ""Segment""
                            }
                        }
                    }
                },
				""Items2"": {
                    ""type"": ""array"",
                    ""items"": {
                        ""type"": ""object"",
                        ""properties"": {
                            ""watchtype"": {
                                ""type"": ""string"",
                                ""enum"": [
                                    ""Security"",
                                    ""Watch list""
                                ],
                                ""title"": ""Watch type""
                            },
                            ""securityid"": {
                                ""type"": ""string"",
                                ""title"": ""Security ID""
                            },
                            ""Securityno"": {
                                ""type"": ""string"",
                                ""title"": ""Security No.""
                            },
                            ""instrumenttype"": {
                                ""type"": ""string"",
                                ""title"": ""Instrument Type"",
                                ""readOnly"": true
                            },
                            ""watchlist"": {
                                ""type"": ""string"",
                                ""title"": ""Watch list"",
                                ""description"": ""Choose an existing Watch list, though not this""
                            },
                            ""segment"": {
                                ""type"": ""string"",
                                ""title"": ""Segment""
                            }
                        }
                    }
                }
            }
        }
    }
}";
            JObject jo = JObject.Parse(responseString);
            JToken dataSource = jo.SelectToken("$");
            string name = (dataSource.Single() as JProperty).Name;
            Console.WriteLine("Name - " + name);
            //Console.WriteLine(dataSource);
            var properties = dataSource.SelectTokens(name + ".items.properties[?(@..[?(@.type != 'array')])]").ToList();
            Console.WriteLine(properties);
            //..[?(@.type != 'array')]")/*.SelectTokens("$..[?(@.type != 'array')]")*/.ToList();//.Children().Where(p => p.Children().First()["type"].ToString() != "array")
            //.ToDictionary(p => (p as JProperty).Name);	
            //var properties = jo[name]["items"]["properties"].Children().Where(p => p.Children().First()["type"].ToString() != "array")//.ToList();
            //	.ToDictionary(p => (p as JProperty).Name);

            var items = jo[name]["items"]["properties"].Children().Where(p => p.Children().First()["type"].ToString() == "array")
                .ToDictionary(p => (p as JProperty).Name);

            Console.WriteLine("Properties: (Create a cicle for PropertyList)");
            foreach (var prop in properties)
            {
                //Console.WriteLine("Name - "+prop.Key);
                //Console.WriteLine("Value - "+ prop.Value);
                Console.WriteLine(prop);
            }
            Console.WriteLine("Items: (Create a cicle for Items)");
            foreach (var item in items)
            {
                Console.WriteLine("Name - " + item.Key);
                Console.WriteLine("Value - " + item.Value);
            }




            ///
        }
    }
}
