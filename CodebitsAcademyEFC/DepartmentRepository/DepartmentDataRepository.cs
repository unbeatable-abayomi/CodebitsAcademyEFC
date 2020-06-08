using CodebitsAcademyEFC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodebitsAcademyEFC.DepartmentRepository
{
    public class DepartmentDataRepository: IDepartment
    {
        private readonly DataContext _dataContext;
        public DepartmentDataRepository(DataContext dataContext) => _dataContext = dataContext;

        public IEnumerable<Department> AllDepartments => _dataContext.DepartmentsTable;

        public void AddDepartment (Department department)
        {
            _dataContext.DepartmentsTable.Add(department);
            _dataContext.SaveChanges();
        }
      

    }

}
