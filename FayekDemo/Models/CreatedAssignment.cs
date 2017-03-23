using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FayekDemo.Models
{
    public class CreatedAssignment
    {
        public string AssignmentName { get; set;}
        public string ClientName { get; set; }
        public int ConsultantId { get; set; }
        public DateTime EndDate { get; set; }
        public string Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public string Comment { get; set; }

    }
}