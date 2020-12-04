using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Models
{
    public class SockClient : IDisposable
    {
        private HttpClient HttpClient = new HttpClient();

        public SockClient()
        {

        }
        public SockClient(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private string ConnectionString = "http://localhost:45023";

        //METHODS
        public async Task GetDatabase()
        {

        }

        public async Task GetCollection<T>(DbEngineType engine = DbEngineType.Napalm)
        {

        }

        //METHODS

        public async void Dispose()
        {
            HttpClient.Dispose();
            ConnectionString = null;



        }
    }
}
