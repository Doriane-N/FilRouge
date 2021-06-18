using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilRouge.XamarinBis.Models
{
    public class User
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }
    }

    public class RecruitmentAgent
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("User")]
        public User User { get; set; }

        [JsonProperty("IsAdmin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("Login")]
        public string Login { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Quizzs")]
        public object Quizzs { get; set; }
    }
}
