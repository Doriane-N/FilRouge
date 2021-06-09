using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace FilRouge.Web.Services
{
    public class AgentService
    {
        private HttpClient httpClient;

        public AgentService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44373"); //URI à changer
        }

        public Pizza Get(int id)
        {
            var response = this.httpClient.Exists($"/api/pizzas/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync();
                var pizza = JsonConvert.DeserializeObject<Pizza>(responseBody);

                return pizza;
            }

            return null;
        }

        public async Task<bool> Create(Pizza pizza)
        {
            var content = new StringContent(JsonConvert.SerializeObject(pizza), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/pizzas", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}