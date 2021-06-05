using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DataAccessLayer.Models
{
    class RecruitmentAgent
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }
        public bool IsAdmin { get; set; }
        [MaxLength(50)]
        public string Login { get; set; }
        [DataType(DataType.Password), MaxLength(50)]
        public string Password { get; set; }

        public ICollection<Quizz> Quizzs { get; set; }
    }
}
