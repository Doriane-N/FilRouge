using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FilRouge.ApiData.Models
{
    [DataContract]
    public class AnswerPercentLevel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Report Report { get; set; }
        [DataMember]
        public DifficultyLevel DifficultyLevel { get; set; }
        [DataMember]
        public int GoodAnswersPercent { get; set; }
    }
}