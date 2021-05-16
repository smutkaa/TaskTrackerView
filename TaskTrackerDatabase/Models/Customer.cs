using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TaskTrackerDatabase
{
    public partial class Customer
    {
        public Customer()
        {
            Comments = new HashSet<Comments>();
            Project = new HashSet<Project>();
        }

        public int Customerid { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int? Userid { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Project> Project { get; set; }
    }
}
