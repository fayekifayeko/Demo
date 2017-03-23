using FayekDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FayekDemo.Repository
{
    public interface IConsultantRepository
    {
         List<AssignmentView> GetAllDetails();
         List<Assignment> GetAllAssignments();
         Assignment GetAssignmentById(int assignmentId);
         Assignment GetAssignmentByConsultantId(int consultantId);
         void AddAssignment(CreatedAssignment newAssignment);
         void UpdateAssignment( Assignment assignment);
         void DeleteAssignment(int assignmentId);

         List<Consultant> GetAllConsultants();
         Consultant GetConsultantById(int consultantId);
         Consultant GetConsultantByAssignmentId(int assignmentId);
         void AddConsultant(Consultant consultant);
        void UpdateConsultant(Consultant consultant);
        void DeleteConsultant(int consultantId);


    }
}