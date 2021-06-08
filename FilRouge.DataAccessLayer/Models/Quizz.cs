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
        public int QuestionsNb { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public RecruitmentAgent RecruitmentAgent { get; set; }
        public int AnsweredQuestionsNb { get; set; }
        public Candidate Candidate { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
