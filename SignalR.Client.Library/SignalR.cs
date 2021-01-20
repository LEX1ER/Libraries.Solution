using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Linq;
using System.Web;

namespace SignalR.Client.Library
{
    public class SignalR
    {
        HubConnection HubConnection;
        string url;
        string qs;
        public SignalR Url(string url)
        {
            this.url = url;
            return this;
        }
        public SignalR QueryParams(object qpObjects)
        {
            this.qs = GetQueryString(qpObjects);
            return this;
        }

        public HubConnection Connect()
        {
            var queryString = !string.IsNullOrEmpty(qs) ? $"?{qs}" : string.Empty;

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
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }

        public SignalR()
        {
        }
    }
}
