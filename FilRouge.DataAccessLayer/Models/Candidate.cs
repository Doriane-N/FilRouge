using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DataAccessLayer.Models
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
    }
}
