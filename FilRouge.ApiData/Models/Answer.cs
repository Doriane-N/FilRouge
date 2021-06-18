using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FilRouge.ApiData.Models
{
    [DataContract]
    public class Answer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]   
        public string Text { get; set; }
        [DataMember]
        public bool IsGood { get; set; }
        [DataMember]
        public Question Question { get; set; }
        [DataMember]
        public ICollection<Quizz> Quizzs { get; set; }
    }
}