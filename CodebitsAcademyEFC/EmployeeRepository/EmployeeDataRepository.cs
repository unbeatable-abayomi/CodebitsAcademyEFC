using CodebitsAcademyEFC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


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

        public Employee GetEmployee(long Id)
        {
            return _context.EmployeesTable.Find(Id);
        }

        public Employee Delete(long Id)
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

        public void EditEmployee(Employee employee)
        {
            
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public IQueryable<Employee> Search(string Surname)
        {

            var emm = _context.EmployeesTable.Where(c => c.LastName.Contains(Surname));


            

            //return _context.EmployeesTable.Where(c => c.LastName == surname).OrderBy(c => c.Age);
            //return _context.EmployeesTable.Where(s => s.LastName.Contains(surname));
            //var emmplee = _context.EmployeesTable.Where(c => c.LastName == surname);
            //IQueryable<Employee> employee = _context.EmployeesTable.Where(c => c.LastName == surname);
            return emm;
        }

       
    }
}
