using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FilRouge.ApiData.Models
{
    [DataContract]
    public class Quizz
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public int QuestionsNb { get; set; }
        [DataMember]
        public DifficultyLevel DifficultyLevel { get; set; }
        [DataMember]
        public RecruitmentAgent RecruitmentAgent { get; set; }
        [DataMember]
        public int AnsweredQuestionsNb { get; set; }
        [DataMember]
        public Candidate Candidate { get; set; }
        [DataMember]
        public ICollection<Question> Questions { get; set; }
        [DataMember]
        public ICollection<Answer> Answers { get; set; }
        [DataMember]
        public Report Report { get; set; }

    }
}