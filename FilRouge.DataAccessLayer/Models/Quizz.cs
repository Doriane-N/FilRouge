using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DataAccessLayer.Models
{
    public class Quizz
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public int QuestionsNb { get; set; }

        [Required]
        public DifficultyLevel DifficultyLevel { get; set; }

        [Required]
        public RecruitmentAgent RecruitmentAgent { get; set; }

        [Required]
        public int AnsweredQuestionsNb { get; set; }

        [Required]
        public Candidate Candidate { get; set; }

        [Required]
        public ICollection<Question> Questions { get; set; }

        [Required]
        public ICollection<Answer> Answers { get; set; }
    }
}
