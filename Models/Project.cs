using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oesia.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string ProjectId { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double EstimatedHours { get; set; }
        public double ElapsedHours { get; set; }
        public double PendingHours { get; set; }
        public string Status { get; set; }
        public List<Module> Modules { get; set; }
        public List<UserProject> UserProjects { get; set; }
    }
}
