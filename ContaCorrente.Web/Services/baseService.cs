using ContaCorrente.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ContaCorrente.Web.Services
{
    public class BaseService<T> where T : class
    {
        readonly string uri;

        public BaseService(string _uri)
        {
            uri = _uri; 
        }

        public async Task<List<T>> Get()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri);
                List<T> clients = new List<T>();
                if (response.IsSuccessStatusCode)
                {
                    clients = await response.Content.ReadAsAsync<List<T>>();
                }

                return clients;
            }
        }

        public async Task<T> Get(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri + id.ToString());
                T client = null;
                if (response.IsSuccessStatusCode)
                {
                    client = await response.Content.ReadAsAsync<T>();
                }

                return client;
            }
        }

        public async Task<int> Post(T item)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                int id = 0;
                var response = await httpClient.PostAsJsonAsync(uri, item);
                if (response.IsSuccessStatusCode)
                {
                    id = await response.Content.ReadAsAsync<int>();
                }

                return id;
            }
        }

        public async Task<int> Put(T item)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                int id = 0;
                var response = await httpClient.PutAsJsonAsync(uri, item);
                if (response.IsSuccessStatusCode)
                {
                    id = await response.Content.ReadAsAsync<int>();
                }

                return id;
            }
        }

        public async Task<int> Delete(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(uri + id);
                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsAsync<int>();
                }

                return id;
            }
        }

    }
}