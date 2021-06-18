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
    public class QuizzService
    {
        private HttpClient httpClient;

        public QuizzService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44300");
        }

        public async Task<IList<Quizz>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/quizz");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var quizz = JsonConvert.DeserializeObject<List<Quizz>>(responseBody);

                return quizz;
            }

            return null;
        }
        public async Task<bool> Create(Quizz quizz)
        {
            var content = new StringContent(JsonConvert.SerializeObject(quizz), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/quizz", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}