using FayekDemo.Models;
using FayekDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FayekDemo.Controllers
{
    public class HomeController : ApiController
    {

        private ConsultantRepository _repository =new ConsultantRepository();
        List<AssignmentView> My_Result;

        public List<AssignmentView> GetAssignmentView()
        {

            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                if (ctx.Cache["CacheKey"] == null)
                {
                    My_Result = _repository.GetAllDetails();
                    ctx.Cache.Insert("CacheKey", My_Result, null,
          System.Web.Caching.Cache.NoAbsoluteExpiration,
          TimeSpan.FromMinutes(1));

                }

            }





            My_Result = ctx.Cache["CacheKey"] as List<AssignmentView>;

            return My_Result;
        }

        public List<Consultant> GetConsultants()
        {
            
            return _repository.GetAllConsultants();
        }

        public void CreateAssignment(CreatedAssignment newAssignment)
        {
            _repository.AddAssignment(newAssignment);
        }

        [HttpPost]
        public void DeleteAssignment(int assignmentId)
        {
            _repository.DeleteAssignment(assignmentId);
        }

        public void UpdateAssignment(Assignment selectAssignmentToUpdate)
        {
            _repository.UpdateAssignment(selectAssignmentToUpdate);
        }

        public void CreateConsultant(Consultant newConsultant)
        {
            _repository.AddConsultant(newConsultant);
        }

        public void UpdateConsultant(Consultant updatedConsultant)
        {
            _repository.UpdateConsultant(updatedConsultant);
        }

        [HttpPost]
        public void DeleteConsultant(int consultantId)
        {
            _repository.DeleteConsultant(consultantId);
        }
    }
}
