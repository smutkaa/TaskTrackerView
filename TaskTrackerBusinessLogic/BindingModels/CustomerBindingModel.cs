using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.Enums;

namespace TaskTrackerBusinessLogic.BindingModels
{
    public class CustomerBindingModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int? UserId { get; set; }
    }

}
