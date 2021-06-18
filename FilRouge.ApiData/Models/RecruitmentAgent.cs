using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FilRouge.ApiData.Models
{
    [DataContract]
    public class RecruitmentAgent
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public User User { get; set; }
        [DataMember]
        public bool IsAdmin { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public ICollection<Quizz> Quizzs { get; set; }
    }
}