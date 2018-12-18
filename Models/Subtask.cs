using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oesia.Models
{
    public class Subtask
    {
        public long Id { get; set; }
        [Display(Name = "ID")]
        public string SubtaskId { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Time Est. (h)")]
        public double EstimatedHours { get; set; }
        public double ElapsedHours { get; set; }
        public double PendingHours { get; set; }
        public string Observations { get; set; }
        public string Status { get; set; }
        public List<UserSubtask> UserSubtasks { get; set; }

        public long TaskId { get; set; }
        public Oesia.Models.Task Task { get; set; }
    }
}
