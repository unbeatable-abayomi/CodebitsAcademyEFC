using CodebitsAcademyEFC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodebitsAcademyEFC.EmployeeRepository
{
    public interface IEmployee
    {
        IEnumerable <Employee> Employees { get; }

        public void AddEmployee(Employee employeeModel);

       Employee Delete(long Id);

        Employee GetEmployee(long Id);

        public void EditEmployee(Employee employee);
    }
}
