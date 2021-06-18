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
    public class DifficultyLevelService
    {
        private HttpClient httpClient;

        public DifficultyLevelService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44300");
        }
        public async Task<IList<DifficultyLevel>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/difficultylevel");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var difficultyLevels = JsonConvert.DeserializeObject<List<DifficultyLevel>>(responseBody);

                return difficultyLevels;
            }

            return null;
        }
    }
}