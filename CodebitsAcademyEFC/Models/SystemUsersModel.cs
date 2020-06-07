using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodebitsAcademyEFC.Models
{
    public class SystemUsersModel
    {
        [Key]
        
        public long Id { get; set; }

        [Required]
        [StringLength (50,MinimumLength =3, ErrorMessage = "You must enter between 5 characters to 30 Charaters ")]
        
        public string Username { get; set; }
        [Required]
        [StringLength (50,MinimumLength =3, ErrorMessage = "You must enter between 5 characters to 30 Charaters ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [Display (Name = "Confrim Password")]
        public string ConfirmPassword { get; set; }


        [Required]
        [RegularExpression(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}", ErrorMessage = "Pls Enter a Vailid email address example@yahoo.com")]

        [Display(Name = "Email Address")]
        public string Email { get; set; }



        [Required]
        [Display(Name ="Status")]
        public string Status { get; set; }


        [Required]
        [Display(Name ="Role")]
        public string Role { get; set; }


    }    

}
