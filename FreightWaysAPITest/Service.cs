using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace FreightWaysAPITest
{
    public class Service : IDisposable
    {
        HttpClient client;

        public Service()
        {
           
            client = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com/posts/idontexist") };

            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

       

     
        public ListResponse<JsonHolderEntity> CallIDontExistEndpoint()
        {
            using (var response = client.GetAsync("").Result)
            {
                if(response.IsSuccessStatusCode)
                {
                    var points = JsonConvert.DeserializeObject<List<JsonHolderEntity>>(response.Content.ReadAsStringAsync().Result);
                    return new ListResponse<JsonHolderEntity>(response.StatusCode, points);
                }

               return new ListResponse<JsonHolderEntity>(response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
        }

        public void Dispose()
        {
            if (client != null)
            {
                client.Dispose();
                client = null;
            }
        }
    }
}
