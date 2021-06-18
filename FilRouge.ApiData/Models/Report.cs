using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FilRouge.ApiData.Models
{
    [DataContract]
    public class Report
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Quizz Quizz { get; set; }
        [DataMember]
        public int GlobalGoodAnswersPercent { get; set; }
        [DataMember]
        public ICollection<AnswerPercentLevel> AnswerPercentLevels { get; set; }
    }
}