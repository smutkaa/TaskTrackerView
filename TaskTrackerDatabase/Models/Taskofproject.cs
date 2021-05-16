using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TaskTrackerDatabase
{
    public partial class Taskofproject
    {
        public int? Projectid { get; set; }
        public int? Taskid { get; set; }

        public virtual Project Project { get; set; }
        public virtual Tasks Task { get; set; }
    }
}
