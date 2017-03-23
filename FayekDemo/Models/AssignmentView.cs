using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FayekDemo.Models
{
    public class AssignmentView
    {
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }

        public string ClientName { get; set; }
        public string Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
        public string ConsultantName { get; set; }
        public bool IsDeadline { get; set; }
         public int ConsultantId { get; set; }

    }
}