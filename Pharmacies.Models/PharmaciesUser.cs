using System;
using Microsoft.AspNetCore.Identity;

namespace Pharmacies.Models
{
    public class PharmaciesUser : IdentityUser
    {
        public string Uin { get; set; }
    }
}
