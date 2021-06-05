using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DataAccessLayer.Models
{
    class DifficultyLevel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Level { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Quizz> Quizzs { get; set; }
        public ICollection<AnswerPercentLevel> AnswerPercentLevels { get; set; }

    }
}
