using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.Enums;

namespace TaskTrackerBusinessLogic.BindingModels
{
    public class UserBindingModel
    {
        public int? Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
