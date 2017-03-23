using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FayekDemo.Models
{
    public class Consultant
    {
        [Key]
        public int ConsultantId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}