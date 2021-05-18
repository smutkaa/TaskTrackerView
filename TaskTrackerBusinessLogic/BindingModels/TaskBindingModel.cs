using System;
using System.Collections.Generic;
using System.Text;
using TaskTrackerBusinessLogic.Enums;

namespace TaskTrackerBusinessLogic.BindingModels
{
    public class TaskBindingModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Text { get; set; }
        public int? Projectid { get; set; }
        public int? ImplementerId { get; set; }
        public string State { get; set; }
        public string Priority { get; set; }
    }
}
