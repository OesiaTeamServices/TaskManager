using System;
using System.Collections.Generic;

namespace Oesia.Models
{
    public class UserSubtask
    {
        public long Id { get; set; }
        public DateTime PlayTime { get; set; }
        public DateTime PauseTime { get; set; }
        public DateTime StopTime { get; set; }
        public DateTime RecordTime { get; set; }
        //public string RouteToLogFile { get; set; }
        public AppUser AppUsers { get; set; }
        public Subtask Subtasks { get; set; }
    }
}
