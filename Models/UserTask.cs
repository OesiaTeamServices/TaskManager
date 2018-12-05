using System;
using System.Collections.Generic;

namespace Oesia.Models
{
    public class UserTask
    {
        public long Id { get; set; }
        public AppUser AppUsers { get; set; }
        public Task Tasks { get; set; }
    }
}
