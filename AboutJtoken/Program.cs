using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace AboutJtoken
{
    class Program
    {
        static void Main(string[] args)
        {
            RunMyData();
        }

        private static void RunMyData()
        {
            string myString = @"{
                 'errors': null,
                 'succeeded': true,
                 'message': null,
                 'data': {
                 'entity': {
                         name: 'Spoiled Products',
                         code: 'SP',
                         useAutomaticCostAccount: false,
                         useAutomaticPriceAccount: false,
                         type: 2,
                         pricePostingAccountId: 'ed5ad8a4-08ef-41af-a30b-5c158b1e5fdf',
                         costPostingAccountId: 'c4fe7992-29c2-41db-88b6-783c853df5b9'
                     },
                     'readOnlyFields': ['type'],
                   'validationRules': {                    
                     'fields': {
                        'CreditReason.Code': {
                            'required': {},
                            'limitedLength': { min: 1, max: 12}
                        },          
                        'CreditReason.Name': {
                            'required': {},
                            'limitedLength': { min: 1, max: 50}       
                        },
                        'CreditReason.UseAutomaticPriceAccount': {
                            required: {}
                        },          
                        'CreditReason.UseAutomaticCostAccount': {
                            required: {}
                        },     
                        'CreditReason.CostPostingAccountId' : {
                             'required': {  
                                'when': [
                                   { 
                                      fieldName: 'type', 
                                      fieldValue: 2, 
                                      operator: 'equals'
                                    },
                                    {
                                      fieldName: 'useAutomaticCostAccount',
                                      operator: 'equals',
                                      fieldValue: false
                                   }
                                ]},
                             'options': {
                                  'c4fe7992-29c2-41db-88b6-783c853df5b9' :  { name: 'Wells Fargo' , number: '5880' }
                             }
                          },
                          'CreditReason.PricePostingAccountId' : {
                             'required': {
                                 when: [{
                                      fieldName: 'useAutomaticPriceAccount',
                                      operator: 'equals',
                                      fieldValue: false
                                  }]
                            },
                             'options': {
                                  'ed5ad8a4-08ef-41af-a30b-5c158b1e5fdf' :  { name: 'Chase' , number: '4990' }
                             }
                          }
                     }
                   }
                 }  
                }";

            JObject jo = JObject.Parse(myString);

            var first = jo.Children().First();
            var last = jo.Children().Last();


            //JToken dataSource = jo.SelectToken("$");
            JToken dataSource = last.SelectToken("$");


            var singleJProperty = (dataSource.Single() as JProperty);

            string name = singleJProperty.Name;
            Console.WriteLine("Name - " + name);

            var properties = dataSource.SelectTokens("[?(@..[?(@.type != 'array')])]").ToList();

            Console.WriteLine(properties);

            var nameEntry = jo[name];

            var entity = jo[name]["data"]["entity"];

            var children = entity.Children()
                .ToDictionary(p => (p as JProperty).Name);

            Console.WriteLine("Properties: (Create a cicle for PropertyList)");
            foreach (var prop in properties)
            {
                Console.WriteLine(prop);
            }

            Console.WriteLine("Entity: ");
            foreach (var item in children)
            {
                Console.WriteLine("Name - " + item.Key);
                Console.WriteLine("Value - " + item.Value);
            }
        }

        private static void RunHisData()
        {
            string myString = @"{ 'data':{
                 'errors': null,
                 'succeeded': true,
                 'message': null,
                 'data': {
                 'entity': {
                         name: 'Spoiled Products',
                         code: 'SP',
                         useAutomaticCostAccount: false,
                         useAutomaticPriceAccount: false,
                         type: 2,
                         pricePostingAccountId: 'ed5ad8a4-08ef-41af-a30b-5c158b1e5fdf',
                         costPostingAccountId: 'c4fe7992-29c2-41db-88b6-783c853df5b9'
                     },
                     'readOnlyFields': ['type'],
                   'validationRules': {                    
                     'fields': {
                        'CreditReason.Code': {
                            'required': {},
                            'limitedLength': { min: 1, max: 12}
                        },          
                        'CreditReason.Name': {
                            'required': {},
                            'limitedLength': { min: 1, max: 50}       
                        },
                        'CreditReason.UseAutomaticPriceAccount': {
                            required: {}
                        },          
                        'CreditReason.UseAutomaticCostAccount': {
                            required: {}
                        },     
                        'CreditReason.CostPostingAccountId' : {
                             'required': {  
                                'when': [
                                   { 
                                      fieldName: 'type', 
                                      fieldValue: 2, 
                                      operator: 'equals'
                                    },
                                    {
                                      fieldName: 'useAutomaticCostAccount',
                                      operator: 'equals',
                                      fieldValue: false
                                   }
                                ]},
                             'options': {
                                  'c4fe7992-29c2-41db-88b6-783c853df5b9' :  { name: 'Wells Fargo' , number: '5880' }
                             }
                          },
                          'CreditReason.PricePostingAccountId' : {
                             'required': {
                                 when: [{
                                      fieldName: 'useAutomaticPriceAccount',
                                      operator: 'equals',
                                      fieldValue: false
                                  }]
                            },
                             'options': {
                                  'ed5ad8a4-08ef-41af-a30b-5c158b1e5fdf' :  { name: 'Chase' , number: '4990' }
                             }
                          }
                     }
                   }
                 }  
                }}";

            string hisString = @"{
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

            JObject jo = JObject.Parse(myString);
            JToken dataSource = jo.SelectToken("$");

            var singleJProperty = (dataSource.Single() as JProperty);

            string name = singleJProperty.Name;
            Console.WriteLine("Name - " + name);
            //Console.WriteLine(dataSource);
            //var properties = dataSource.SelectTokens(name + ".items.properties[?(@..[?(@.type != 'array')])]").ToList();
            var properties = dataSource.SelectTokens(name + ".[?(@..[?(@.type != 'array')])]").ToList();
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
        }

        public static JToken GetSample2()
        {
            return JToken.Parse(@"{
            'books': [
                {
                  'title' : 'The Great Gatsby',
                  'author' : 'F. Scott Fitzgerald'
                },
                {
                  'title' : 'The Grapes of Wrath',
                  'author' : 'John Steinbeck'
                }
                ]
            }");
        }


    }
}
