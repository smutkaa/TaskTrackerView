using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTrackerBusinessLogic.BindingModels
{
    public class ProjectBindingModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public decimal Price { get; set; }
        public int? Clientid { get; set; }
        public Dictionary<int?, int?> TaskodProject { get; set; }

        public Dictionary<int?, (string, DateTime, DateTime, string, string, string)> Tasks { get; set; }
    }
}
