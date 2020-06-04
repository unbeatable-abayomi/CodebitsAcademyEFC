using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodebitsAcademyEFC.Models
{
    public class Employee
    {
        [Required]
      
        public long Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        [Display (Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Range(18, 100)]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Pls Enter a Vailid email address example@yahoo.com")]
        [RegularExpression(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}")]

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Pls Enter a Vailid Number xxx-xxx-xxxx")]
        [RegularExpression(@"[0]\d{10}$")]
        public string PhoneNumber { get; set; }
    }
}
