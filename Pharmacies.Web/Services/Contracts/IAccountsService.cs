using Pharmacies.Web.Models.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacies.Web.Services.Contracts
{
    public interface IAccountsService
    {
        void CreateUser(RegisterViewModel model);
        void Demote(string id);
        void Promote(string id);
    }
}
