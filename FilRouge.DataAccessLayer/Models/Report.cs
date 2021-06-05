using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DataAccessLayer.Models
{
    class Report
    {
        [Key]
        public int Id { get; set; }
        public Quizz Quizz { get; set; }
        public int GlobalGoodAnswersPercent { get; set; }

        public ICollection<AnswerPercentLevel> AnswerPercentLevels { get; set; }
    }
}
