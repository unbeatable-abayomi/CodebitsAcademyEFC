using CodebitsAcademyEFC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodebitsAcademyEFC.AccountsRepository
{
     public interface IAccounts
    {
        IEnumerable<SystemUsersModel> AllSystemUsers { get; }

        public void AddSystemUser(SystemUsersModel systemUsers);

        SystemUsersModel GetSystemUser(long Id);
        public void EditSystemUser(SystemUsersModel systemUsersModel);
        public void DeleteSystemUser(SystemUsersModel systemUsersModel);

        IQueryable<SystemUsersModel> Search(string surname);
        public bool Authentiction(string username, string password);
    }
}
