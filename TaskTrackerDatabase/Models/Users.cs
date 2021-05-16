using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TaskTrackerDatabase
{
    public partial class Users
    {
        public Users()
        {
            Customer = new HashSet<Customer>();
            Executor = new HashSet<Executor>();
        }

        public int Userid { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? Role { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Executor> Executor { get; set; }
    }
}
