using System;
using System.Net.Http;

namespace Employee.Web.Helper
{
    public class HelperApi
    {
        HttpClientHandler _ClientHandler = new HttpClientHandler();
        public HelperApi()
        {
            _ClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        }
        public HttpClient Initial()
        {
            var Client = new HttpClient(_ClientHandler);
            Client.BaseAddress = new Uri("https://localhost:44390/");
            return Client;
        }
    }
}
