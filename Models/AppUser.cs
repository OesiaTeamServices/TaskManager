using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Oesia.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser() : base()
        {
        }

        public string UserId { get; set; }
        public string ProjectId { get; set; }
        public string TaskId { get; set; }
        public string SubtaskId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }

        public List<UserProject> UserProjects { get; set; }
        public List<UserTask> UserTasks { get; set; }
        public List<UserSubtask> UserSubtasks { get; set; }
    }
}
