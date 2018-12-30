using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Pharmacies.Data;
using Pharmacies.Models;
using Pharmacies.Web.Models.AccountViewModels;
using Pharmacies.Web.Services.Contracts;
using System.Linq;

namespace Pharmacies.Web.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IMapper autoMapper;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly PharmaciesDbContext context;

        private SignInManager<PharmaciesUser> signIn { get; }
        private UserManager<PharmaciesUser> UserManager { get; }

        public AccountsService(PharmaciesDbContext context, RoleManager<IdentityRole> roleManager, SignInManager<PharmaciesUser> signInManager, UserManager<PharmaciesUser> userManager, IMapper autoMapper)
        {
            this.context = context;
            this.roleManager = roleManager;
            this.autoMapper = autoMapper;
            this.signIn = signInManager;
            this.UserManager = userManager;
        }

        public void CreateUser(RegisterViewModel model)
        {
            var user = this.autoMapper.Map<PharmaciesUser>(model);
            var result = this.UserManager.CreateAsync(user, model.Password).Result;
            string role = "User";
            if (this.signIn.UserManager.Users.Count() == 1)
            {
                role = "Admin";
            }
            var roleResult = this.signIn.UserManager.AddToRoleAsync(user, role).Result;
            
            if (result.Succeeded)
            {
                this.SignInUser(user, model.Password);
            }
        }

        public void SignInUser(PharmaciesUser user, string password)
        {
             this.signIn.PasswordSignInAsync(user, password, false, false).Wait();
        }

       

        public void Promote(string id)
        {
            var user = this.UserManager.Users.Where(u => u.Id == id).FirstOrDefault();
            this.UserManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
        }

        public void Demote(string id)
        {
            var user = this.UserManager.Users.Where(u => u.Id == id).FirstOrDefault();
            this.UserManager.RemoveFromRoleAsync(user, "Admin").GetAwaiter().GetResult();
        }

    }
}
