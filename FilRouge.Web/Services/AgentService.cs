using FilRouge.DataAccessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FilRouge.Web.Services
{
    public class AgentService
    {
        private HttpClient httpClient;

        public AgentService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44300"); //URI à changer
        }

        public async Task<RecruitmentAgent> Get(string login)
        {
            var response = await this.httpClient.GetAsync($"/api/agent?login={login}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var agent = JsonConvert.DeserializeObject<RecruitmentAgent>(responseBody);
                return agent;
            }
            return null;
        }

            //var pizzas = JsonConvert.DeserializeObject<List<Pizza>>(responseBody);


            //public Pizza Get(int id)
            //{
            //    var response = this.httpClient.Exists($"/api/pizzas/{id}");

            //    if (response.IsSuccessStatusCode)
            //    {
            //        string responseBody = response.Content.ReadAsStringAsync();
            //        var pizza = JsonConvert.DeserializeObject<Pizza>(responseBody);

            //        return pizza;
            //    }

            //    return null;
            //}

            //public async Task<bool> Create(Pizza pizza)
            //{
            //    var content = new StringContent(JsonConvert.SerializeObject(pizza), Encoding.UTF8, "application/json");
            //    var response = await this.httpClient.PostAsync($"/api/pizzas", content);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        return true;
            //    }

            //    return false;
            //}
        }
    }