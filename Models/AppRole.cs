using System;
using Microsoft.AspNetCore.Identity;

namespace Oesia.Models
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base()
        {

        }

        public AppRole(string roleName) : base(roleName)
        {

        }

        public AppRole(string roleName, string description, DateTime creationDate) : base(roleName)
        {
            this.Description = description;
            this.CreationDate = creationDate;
        }

        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }

}
