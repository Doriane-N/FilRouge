using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FilRouge.ApiData.Models
{
    [DataContract]
    public class Question
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public int AnswersNb { get; set; }
        [DataMember]
        public int GoodAnswersNb { get; set; }
        [DataMember]
        public DifficultyLevel DifficultyLevel { get; set; }
        [DataMember]
        public int Type { get; set; }
        [DataMember]
        public ICollection<Answer> Answers { get; set; }
        [DataMember]
        public ICollection<Quizz> Quizzs { get; set; }
    }
}