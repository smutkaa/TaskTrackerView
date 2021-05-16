using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TaskTrackerDatabase
{
    public partial class ExecutorField
    {
        public int? Executorid { get; set; }
        public int? Fieldid { get; set; }

        public virtual Executor Executor { get; set; }
        public virtual Field Field { get; set; }
    }
}
