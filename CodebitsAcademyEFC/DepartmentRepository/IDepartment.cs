using CodebitsAcademyEFC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodebitsAcademyEFC.DepartmentRepository
{
     public interface IDepartment
    {
        IEnumerable <Department> AllDepartments { get; }
        public void AddDepartment(Department department);
    }
}
