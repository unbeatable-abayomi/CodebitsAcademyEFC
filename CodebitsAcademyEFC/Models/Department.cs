using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodebitsAcademyEFC.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength (55,MinimumLength =3)]
        public  string Name { get; set; }
    }
}
