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
    public class ReportService
    {
        private HttpClient httpClient;

        public ReportService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44300");
        }

        public async Task<IList<Report>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/report");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var report = JsonConvert.DeserializeObject<List<Report>>(responseBody);

                return report;
            }

            return null;
        }

    }
}