using CodebitsAcademyEFC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodebitsAcademyEFC.EmployeeRepository
{
    public class EmployeeDataRepository : IEmployee
    {
      

        private readonly DataContext _context;

        //Inject DataContext here thru Constructor
        public EmployeeDataRepository(DataContext context) => _context = context;
       //List Employee Method
        public IEnumerable<Employee> Employees => _context.EmployeesTable;

            //Or 
            //public IEnumerable<Employee> employees { get { return _context.EmployeesTable; } }

        public void AddEmployee(Employee employeeModel)
        {
            _context.EmployeesTable.Add(employeeModel);
            _context.SaveChanges();
        }

        public Employee Delete(int Id)
        {
            Employee employee = _context.EmployeesTable.Find(Id);
            if(employee != null)
            {
                _context.EmployeesTable.Remove(employee);
                //After remove the employee the save to database
                _context.SaveChanges();
            }
            return employee;
        }


    }
}
