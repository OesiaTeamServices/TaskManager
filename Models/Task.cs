﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oesia.Models
{
    public class Task
    {
        public long Id { get; set; }
        [Display(Name = "ID")]
        public string TaskId { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public string Criticality { get; set; }
        public string Priority { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EstimatedStartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        [Display(Name = "Start Day")]
        public DateTime RealStartDate { get; set; }
        [Display(Name = "End Day")]
        public DateTime RealEndDate { get; set; }
        [Display(Name = "Time Est. (h) ")]
        public double EstimatedHours { get; set; }
        public double ElapsedHours { get; set; }
        public double PendingHours { get; set; }
        public string Status { get; set; }
        public List<Subtask> Subtasks { get; set; }
        public List<UserTask> UserTasks { get; set; }

        public long SubmoduleId { get; set; }
        public Submodule Submodule { get; set; }
    }
}
