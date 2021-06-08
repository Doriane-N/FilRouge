using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DataAccessLayer.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(1000)]
        public string Text { get; set; }
        public bool IsGood { get; set; }
        public Question Question { get; set; }

        public ICollection<Quizz> Quizzs { get; set; }
    }
}
