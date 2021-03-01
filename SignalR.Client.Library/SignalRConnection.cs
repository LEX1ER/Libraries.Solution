using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Client.Library
{
    public class SignalRConnection
    {
        HubConnection HubConnection;
        string url;
        string qs;
        string queryString;
        public SignalRConnection Url(string url)
        {
            this.url = url;
            return this;
        }
        public SignalRConnection QueryParams(object qpObjects)
        {
            this.qs = GetQueryString(qpObjects);
            return this;
        }

        public string GetUrl()
        {

            var fullUrl = $"{url}{queryString}";
            return fullUrl;
        }

        public HubConnection ConnectToHub()
        {
            queryString = !string.IsNullOrEmpty(qs) ? $"?{qs}" : string.Empty;

            HubConnection = new HubConnectionBuilder()
                .WithUrl($"{url}{queryString}")
                .WithAutomaticReconnect()
                .Build();
            HubConnection.StartAsync();

            return HubConnection;
        }

        string GetQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             select p;

            ICollection<string> collectionOfProperties = new List<string>();
            foreach (var property in properties)
            {
                if(property.PropertyType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    var genericCollectionOfValueInAProperty = (List<string>)property.GetValue(obj, null);

                    var Name = $"{property.Name}[]";
                    foreach (var value in genericCollectionOfValueInAProperty)
                    {
                        var NameAndValue = $"{Name}={HttpUtility.UrlEncode(value)}";
                        collectionOfProperties.Add(NameAndValue);
                    }
                }
                else
                {
                    var NameAndValue = $"{property.Name}={HttpUtility.UrlEncode(property.GetValue(obj, null).ToString())}";
                    collectionOfProperties.Add(NameAndValue);
                }
            }

            //var properties = from p in obj.GetType().GetProperties()

            //                 let 

            //                 where p.GetValue(obj, null) != null
            //                 select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", collectionOfProperties.ToArray());
        }
    }
}
