using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DataAccessLayer.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Quizz Quizz { get; set; }

        [Required]
        public int GlobalGoodAnswersPercent { get; set; }

        [Required]
        public ICollection<AnswerPercentLevel> AnswerPercentLevels { get; set; }
    }
}
