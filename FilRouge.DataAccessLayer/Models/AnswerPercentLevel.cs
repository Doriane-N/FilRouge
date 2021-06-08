using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DataAccessLayer.Models
{
    public class AnswerPercentLevel
    {
        [Key]
        public int Id { get; set; }

        public Report Report { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public int GoodAnswersPercent { get; set; }
    }
}
