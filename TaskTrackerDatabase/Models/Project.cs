using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TaskTrackerDatabase
{
    public partial class Project
    {
        public Project()
        {
            Taskofproject = new HashSet<Taskofproject>();
        }

        public int? Projectid { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public decimal Price { get; set; }
        public int? Customerid { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Taskofproject> Taskofproject { get; set; }
    }
}
