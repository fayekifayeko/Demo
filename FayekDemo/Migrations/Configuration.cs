namespace FayekDemo.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FayekDemo.Repository.ConsultantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FayekDemo.Repository.ConsultantContext context)
        {
            var consultants = new List<Consultant>
            {
            new Consultant {ConsultantId=1,Name="Fayek"},
            new Consultant {ConsultantId=2,Name="Nour"},
            new Consultant {ConsultantId=3,Name="Sally"},
            new Consultant {ConsultantId=4,Name="Dina"}


            };

            consultants.ForEach(s => context.Consultants.Add(s));
            context.SaveChanges();
            var assignments = new List<Assignment>
            {
            new Assignment{AssignmentId=1,AssignmentName="TM",ClientName="EON",Percentage="30%",StartDate=DateTime.Parse("2016-09-01"),EndDate=DateTime.Parse("2017-04-30"),Comment="Project for Eon",ConsultantId=1}
            //new Assignment{AssignmentId=2,AssignmentName="Website",ClientName="Telia",Percentage="80%",StartDate=DateTime.Parse("2016-07-21"),EndDate=DateTime.Parse("2017-03-31"),Comment="Website for Telia",ConsultantId=1},
            //new Assignment{AssignmentId=3,AssignmentName="Web Services",ClientName="Jayway",Percentage="60%",StartDate=DateTime.Parse("2016-09-01"),EndDate=DateTime.Parse("2017-04-06"),Comment="Webservices for Jayway",ConsultantId=2},
            //new Assignment{AssignmentId=1,AssignmentName="back-end",ClientName="H&M",Percentage="90%",StartDate=DateTime.Parse("2016-07-23"),EndDate=DateTime.Parse("2017-03-28"),Comment="back-end for H&M",ConsultantId=3},
            //new Assignment{AssignmentId=1,AssignmentName="front-end",ClientName="Mackdonalds",Percentage="50%",StartDate=DateTime.Parse("2016-11-11"),EndDate=DateTime.Parse("2017-08-21"),Comment="front-end for Mackdonalds",ConsultantId=4}

            };
            assignments.ForEach(s => context.Assignments.Add(s));
            context.SaveChanges();
        }
    }
}
