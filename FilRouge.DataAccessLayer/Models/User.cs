using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge.DataAccessLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress), MaxLength(100)]
        public string Email { get; set; }

    }
}
