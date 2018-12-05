using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oesia.Models
{
    public class Submodule
    {
        public long Id { get; set; }
        public string SubmoduleId { get; set; }
        public string Description { get; set; }
        public double EstimatedHours { get; set; }
        public double ElapsedHours { get; set; }
        public double PendingHours { get; set; }
        public string Status { get; set; }
        public List<Task> Tasks{ get; set; }
    }
}
