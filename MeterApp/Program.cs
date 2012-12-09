using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;
using Toolbox.NETMF;
using Toolbox.NETMF.NET;
using System.Xml;

namespace NetduinoPlusApplication1
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                string xml = GetXmlString();
                string ChangeInPercent = GetChangInPercent(xml);

                GetChangInPercent(xml);
                //Debug.Print(ChangeInPercent);
                Thread.Sleep(10000);
            }
        }

        private static void GetChangInPercent()
        {
            throw new NotImplementedException();
        }

        public static string GetXmlString()
        {
            // Creates a new web session
            //http://query.yahooapis.com/v1/public/yql?q=select%20ChangePercentRealtime%20from%20yahoo.finance.quotes%20where%20symbol%20%3D%20'" + StockTicker + "'&diagnostics=true&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";

            HTTP_Client WebSession = new HTTP_Client(new IntegratedSocket("query.yahooapis.com", 80));

            while (true)
            {
                string StockTicker = "qqq";
                // Requests the latest source
                string getstring = "/v1/public/yql?q=select%20ChangePercentRealtime%20from%20yahoo.finance.quotes%20where%20symbol%20%3D%20'qqq'&diagnostics=true&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
                HTTP_Client.HTTP_Response Response = WebSession.Get(getstring);


                // Did we get the expected response? (a "200 OK")
                if (Response.ResponseCode != 200)
                    throw new ApplicationException("Unexpected HTTP response code: " + Response.ResponseCode.ToString());

                // Fetches a response header
                //Debug.Print("Current date according to www.netmftoolbox.com: " + Response.ResponseHeader("date"));

                // Gets the response as a string

                return Response.ToString();
            }
        }

        static string GetChangInPercent(string downloadString)
        {
            XmlReader reader = new XmlReader();

            while (reader.HasValue)
            {
                Debug.Print(reader.Name);
                reader.Read();
            }



            string RealtimeResults = m.Groups[1].ToString();
            return RealtimeResults;
        }
    }
}
