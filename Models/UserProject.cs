using System;
using System.Collections.Generic;

namespace Oesia.Models
{
    public class UserProject
    {
        public long Id { get; set; }
        public AppUser AppUsers { get; set; }
        public Project Projects { get; set; }
    }
}
