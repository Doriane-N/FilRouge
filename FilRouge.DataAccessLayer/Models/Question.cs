using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DataAccessLayer.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(1000)]
        public string Text { get; set; }
        public int AnswersNb { get; set; }
        public int GoodAnswersNb { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public int Type { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<Quizz> Quizzs { get; set; }

    }
}
