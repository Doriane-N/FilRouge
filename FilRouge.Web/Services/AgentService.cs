using FilRouge.DataAccessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            this.httpClient.BaseAddress = new Uri("https://localhost:44300");
        }

        public async Task<RecruitmentAgent> Get(string login, String psw)
        {
            var response = await this.httpClient.GetAsync($"/api/agents?login={login}&psw={psw}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var agent = JsonConvert.DeserializeObject<RecruitmentAgent>(responseBody);
                return agent;
            }
            return null;
        }

        public async Task<RecruitmentAgent> Get(string login)
        {
            var response = await this.httpClient.GetAsync($"/api/agents?login={login}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var agent = JsonConvert.DeserializeObject<RecruitmentAgent>(responseBody);
                return agent;
            }
            return null;
        }

        public async Task<IList<RecruitmentAgent>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/agents");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var agents = JsonConvert.DeserializeObject<List<RecruitmentAgent>>(responseBody);

                return agents;
            }

            return new List<RecruitmentAgent>();
        }

        public async Task<HttpResponseMessage> Create(RecruitmentAgent agent)
        {
            var content = new StringContent(JsonConvert.SerializeObject(agent), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/agents", content);

            return response;
        }
    }

}