using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FilRouge.ApiData.Models
{
    [DataContract]
    public class Candidate
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public User User { get; set; }
        [DataMember]
        public DifficultyLevel DifficultyLevel { get; set; }
    }
}