using CodebitsAcademyEFC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodebitsAcademyEFC.AccountsRepository
{
    public class AccountsDataRepository : IAccounts
    {
        private readonly DataContext _dataContext;
        public AccountsDataRepository(DataContext dataContext) => _dataContext = dataContext;

        public IEnumerable<SystemUsersModel> AllSystemUsers => _dataContext.SystemUsersTable;

        public SystemUsersModel GetSystemUser(long Id)
        {
            SystemUsersModel systemUsersModel = _dataContext.SystemUsersTable.Find(Id);
            return systemUsersModel;

        }
        public void AddSystemUser(SystemUsersModel systemUsersModel)
        {
            _dataContext.SystemUsersTable.Add(systemUsersModel);
            _dataContext.SaveChanges();
        }


        public void EditSystemUser(SystemUsersModel systemUsersModel)
        {
            _dataContext.Entry(systemUsersModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public void DeleteSystemUser(SystemUsersModel systemUsersModel)
        {

            _dataContext.SystemUsersTable.Remove(systemUsersModel);
            _dataContext.SaveChanges();
        }

        public IQueryable<SystemUsersModel> Search(string surname)
        {
            IQueryable<SystemUsersModel> systemUser = _dataContext.SystemUsersTable.Where(user => user.Username.Contains(surname) || user.Role.Contains(surname) || user.Status.Contains(surname));

            return systemUser;
        }
        public bool Authentiction(string username, string password)
        {
            var user = _dataContext.SystemUsersTable.Where(name=>name.Username.Contains(username)&&name.Password.Contains(password));
            if (user.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
