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

        public Question()
        {
            Answers = new List<Answer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        [Display(Name = "Libellé")]
        public string Text { get; set; }

        [Required]
        public int AnswersNb { get; set; }

        public int GoodAnswersNb { get; set; }

        [Required]
        public DifficultyLevel DifficultyLevel { get; set; }

        [Required]
        [Display(Name = "Type de réponse")]
        public QuestionType Type { get; set; }

        [Required]
        public ICollection<Answer> Answers { get; set; }

        public ICollection<Quizz> Quizzs { get; set; }

    }

    public enum QuestionType
    {
        [Display(Name = "plusieurs réponses possibles")]
        MultipleChoice,
        [Display(Name = "une seule bonne réponse")]
        SingleChoice,
        [Display(Name = "réponse libre")]
        FreeAnswer
    }
}
