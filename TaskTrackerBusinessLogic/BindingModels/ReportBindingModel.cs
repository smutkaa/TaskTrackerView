using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTrackerBusinessLogic.BindingModels
{
    public class ReportBindingModel
    {
        public int? ClientId { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
