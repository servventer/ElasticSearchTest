using Nest;
using System;

namespace ElasticSearch
{
    class Program
    {

        static void Main(string[] args)
        {

        }


        public Document GetDataById(string uri, string index, string type, string id, string user, string pass)
        {
             
            var connectionSettings = new ConnectionSettings(new Uri(uri));
            connectionSettings.BasicAuthentication(user, pass);
            var client = new ElasticClient(connectionSettings);

            var searchResults = client.Get<Document>(id, g => g
            .Index(index)
            .Type(type)
            );

            return searchResults.Source;
        }

    }
    public class Document : DeviceSwap { }

    public class DeviceSwap
    {
        public string QuoteNumber { get; set; }
        public string CustomerNumber { get; set; }
        public string FaultyDeviceSerialNumber { get; set; }

    }


}
