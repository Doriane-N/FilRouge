using FilRouge.XamarinBis.Models;
using FilRouge.XamarinBis.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Web.Helpers;

namespace FilRouge.XamarinBis.Services
{
    public class FilRougeService : IFilRougeService
    {
        public bool Authenticate(string login, string password)
        {
            var foundAgent = GetAsync(login).Result;

            if (foundAgent != null && Crypto.VerifyHashedPassword(foundAgent.Password, password))
            {
                return true;
            }
            return false;
        }

        public async Task<RecruitmentAgent> GetAsync(string login)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://localhost:44300/api/agents/{login}").ConfigureAwait(false);
            var recruitmentagent = JsonConvert.DeserializeObject<RecruitmentAgent>(response);

            return recruitmentagent;
        }

        public async Task<List<RecruitmentAgent>> GetAllAsync()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://localhost:44300/api/agents").ConfigureAwait(false);
            var recruitmentagent = JsonConvert.DeserializeObject<List<RecruitmentAgent>>(response);

            return recruitmentagent;
        }

    }
}
