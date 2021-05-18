using System;
using System.Collections.Generic;
using System.Collections;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TaskTrackerDatabase
{
    public partial class Comments
    {
        public int? Commentid { get; set; }
        public string Text { get; set; }
        public BitArray Mark { get; set; }
        public int? Customerid { get; set; }
        public int? Taskid { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Tasks Task { get; set; }
    }
}
