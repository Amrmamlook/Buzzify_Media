using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Invalid Name")]
        [StringLength(30,MinimumLength =4)]
        public string Name { get; set; }

        [ForeignKey("Department")]
         public int? DeparId { get; set; }
        
        public byte[]? Image { get; set; }

        [Range(10,90,ErrorMessage ="Invalid Age")]
        [Required]
        public int Age { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(3)]
        public string Password { get; set; }
        [Compare("Password")]
        [NotMapped]
        public string CPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = " Invalid Email Format")]
        [UniqueEmail]
        public string Email { get; set; }
        public virtual Department? Department { get; set; }

    }
}
