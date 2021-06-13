using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DataAccessLayer.Models
{
    public class RecruitmentAgent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9.-]+$", ErrorMessage = "Caractères autorisés : lettres, chiffres, '.' et '-'")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password), MaxLength(255)]
        public string Password { get; set; }

        public ICollection<Quizz> Quizzs { get; set; }
    }
}
