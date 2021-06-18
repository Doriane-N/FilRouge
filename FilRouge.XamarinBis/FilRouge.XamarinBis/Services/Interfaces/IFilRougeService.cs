using FilRouge.XamarinBis.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.XamarinBis.Services.Interfaces
{
    public interface IFilRougeService
    {
        Task<RecruitmentAgent> GetAsync(string login);

        Task<List<RecruitmentAgent>> GetAllAsync();

        bool Authenticate(string user, string password);
    }
}
