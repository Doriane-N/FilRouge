using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FilRouge.ApiData.Models
{
    [DataContract]
    public class DifficultyLevel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Level { get; set; }
        [DataMember]
        public ICollection<Candidate> Candidates { get; set; }
        [DataMember]
        public ICollection<Question> Questions { get; set; }
        [DataMember]
        public ICollection<Quizz> Quizzs { get; set; }
        [DataMember]
        public ICollection<AnswerPercentLevel> AnswerPercentLevels { get; set; }
    }
}