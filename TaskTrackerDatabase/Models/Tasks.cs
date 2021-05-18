using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TaskTrackerDatabase
{
    public partial class Tasks
    {
        public Tasks()
        {
            Comments = new HashSet<Comments>();
            Taskofproject = new HashSet<Taskofproject>();
        }

        public int? Taskid { get; set; }
        public string Name { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Text { get; set; }
        public string State { get; set; }
        public string Priority { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Taskofproject> Taskofproject { get; set; }
    }
}
