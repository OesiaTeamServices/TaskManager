using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oesia.Models
{
    public class Module
    {
        public long Id { get; set; }
        public string ModuleId { get; set; }
        public string Description { get; set; }
        public double EstimatedHours { get; set; }
        public double ElapsedHours { get; set; }
        public double PendingHours { get; set; }
        public string Status { get; set; }
        public List<Submodule> Submodules { get; set; }
       
        public long ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
