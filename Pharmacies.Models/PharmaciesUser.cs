using System;
using Microsoft.AspNetCore.Identity;

namespace Pharmacies.Models
{
    public class PharmaciesUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Uin { get; set; }
    }
}
