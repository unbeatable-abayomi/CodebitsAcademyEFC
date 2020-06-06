
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodebitsAcademyEFC.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }
       


        public DbSet<Employee> EmployeesTable { get; set; }
        public DbSet<SystemUsersModel> SystemUsersTable { get; set; }


    }
}
