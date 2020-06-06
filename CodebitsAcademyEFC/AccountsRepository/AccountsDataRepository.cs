using CodebitsAcademyEFC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodebitsAcademyEFC.AccountsRepository
{
    public class AccountsDataRepository:IAccounts
    {
        private readonly DataContext _dataContext;
        public AccountsDataRepository(DataContext dataContext) => _dataContext = dataContext;

        public IEnumerable<SystemUsersModel> AllSystemUsers => _dataContext.SystemUsersTable;


        public void AddSystemUser(SystemUsersModel systemUsersModel)
        {
            _dataContext.SystemUsersTable.Add(systemUsersModel);
            _dataContext.SaveChanges();
        }

    }
}
