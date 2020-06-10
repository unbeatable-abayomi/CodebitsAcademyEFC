﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CodebitsAcademyEFC.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUsers class
    public class ApplicationUsers : IdentityUser
    {
        [PersonalData]
        [Column(TypeName =("nvarchar(100)"))]
        public string Surname { get; set; }
        [PersonalData]
        [Column(TypeName = ("nvarchar(100)"))]
        public string Othernames { get; set; }
    }
}
