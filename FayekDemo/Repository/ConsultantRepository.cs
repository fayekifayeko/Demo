using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FayekDemo.Models;
using System.Data.Entity;

namespace FayekDemo.Repository
{
    public class ConsultantRepository : IConsultantRepository
    {
        private ConsultantContext _context = new ConsultantContext();
        public void AddAssignment(CreatedAssignment newAssignment)
        {
            Assignment newAssignment2 = new Assignment
            {
                AssignmentName = newAssignment.AssignmentName,
                ClientName = newAssignment.ClientName,
                Percentage = newAssignment.Percentage,
                StartDate = newAssignment.StartDate,
                EndDate = newAssignment.EndDate,
                Comment = newAssignment.Comment,
                ConsultantId = newAssignment.ConsultantId
            };

            _context.Assignments.Add(newAssignment2);
            _context.SaveChanges();
            Consultant relatedConsultant = _context.Consultants.Find(newAssignment.ConsultantId);
            _context.Entry(relatedConsultant).Collection(a => a.Assignments).Load();
            relatedConsultant.Assignments.Add(newAssignment2);
            _context.SaveChanges();
        }
        public void AddConsultant(Consultant consultant)
        {
            _context.Consultants.Add(consultant);
            _context.SaveChanges();

        }

        public void DeleteAssignment(int assignmentId)
        {
            Assignment selectedAssignment = _context.Assignments.Find(assignmentId);
            _context.Assignments.Remove(selectedAssignment);
            _context.SaveChanges();
        }

        public void DeleteConsultant(int consultantId)
        {
            Consultant selectedConsultant = _context.Consultants.Find(consultantId);
            _context.Consultants.Remove(selectedConsultant);
            _context.SaveChanges();
        }

        public List<Assignment> GetAllAssignments()
        {
            throw new NotImplementedException();
        }

        public List<Consultant> GetAllConsultants()
        {
            _context.Configuration.ProxyCreationEnabled = false;
            return _context.Consultants.ToList();
        }

        public List<AssignmentView> GetAllDetails()
        {
            return _context.Assignments.Select(assgn => new AssignmentView
            {
                AssignmentId = assgn.AssignmentId,
                AssignmentName = assgn.AssignmentName,
                ClientName = assgn.ClientName,
                Percentage = assgn.Percentage,
                StartDate = assgn.StartDate,
                EndDate = assgn.EndDate,
                Comment = assgn.Comment,
                ConsultantName = assgn.Consultant.Name,
                ConsultantId = assgn.ConsultantId,
                IsDeadline = System.Data.Entity.DbFunctions.DiffDays(DateTime.Now, assgn.EndDate) < 30 ? true : false
            }).ToList();
        }

        public Assignment GetAssignmentByConsultantId(int consultantId)
        {
            throw new NotImplementedException();
        }

        public Assignment GetAssignmentById(int assignmentId)
        {
            throw new NotImplementedException();
        }

        public Consultant GetConsultantByAssignmentId(int assignmentId)
        {
            throw new NotImplementedException();
        }

        public Consultant GetConsultantById(int consultantId)
        {
            throw new NotImplementedException();
        }


        public void UpdateAssignment(Assignment assignment)
        {
            Assignment updatedAssignment = _context.Assignments.SingleOrDefault(a => a.AssignmentId == assignment.AssignmentId);
            updatedAssignment.AssignmentName = assignment.AssignmentName;
            updatedAssignment.ClientName = assignment.ClientName;
            updatedAssignment.Comment = assignment.Comment;
            updatedAssignment.ConsultantId = assignment.ConsultantId;
            updatedAssignment.EndDate = assignment.EndDate;
            updatedAssignment.Percentage = assignment.Percentage;
            updatedAssignment.StartDate = assignment.StartDate;
            Consultant relatedConsultant = _context.Consultants.Find(assignment.ConsultantId);
            updatedAssignment.Consultant = relatedConsultant;
            DeleteAssignment(assignment.AssignmentId);
            _context.Assignments.Add(updatedAssignment);
            _context.SaveChanges();
        }





        public void UpdateConsultant(Consultant updatedConsultant)
        {
            _context.Entry(updatedConsultant).State = EntityState.Modified;


            _context.SaveChanges();
            //    Consultant oldConsultant = _context.Consultants.Find(updatedConsultant.ConsultantId);

            //    _context.Consultants.Remove(oldConsultant);
            //    _context.SaveChanges();
            //    _context.Consultants.Add(updatedConsultant);
            //    _context.SaveChanges();

        }
    }
}