using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Seed
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            #region General
            var firstProjectGuid = Guid.NewGuid();
            var secondProjectGuid = Guid.NewGuid();
            var thirdProjectGuid = Guid.NewGuid();
            var firstEmployeeGuid = Guid.NewGuid();
            var secondEmployeeGuid = Guid.NewGuid();
            var thirdEmployeeGuid = Guid.NewGuid();
            var managerGuid = Guid.NewGuid();
            var deadline = new DateTimeOffset();
            deadline = deadline.AddMonths(2);
            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee()
                    {
                        Id = firstEmployeeGuid,
                        FirstName = "Adam",
                        LastName = "Kowalski"
                    });
            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee()
                    {
                        Id = secondEmployeeGuid,
                        FirstName = "Tomasz",
                        LastName = "Nowak"
                    });
            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee()
                    {
                        Id = thirdEmployeeGuid,
                        FirstName = "Adam",
                        LastName = "Smith"
                    });
            modelBuilder.Entity<Manager>()
                .HasData(
                    new Employee()
                    {
                        Id = managerGuid,
                        FirstName = "Paul",
                        LastName = "Allen"
                    });
            #endregion

            #region First Project
            modelBuilder.Entity<Project>()
                .HasData(
                    new Project()
                    {
                        Id = firstProjectGuid,
                        Title = "Backend",
                        Description = "Backend API project in CQRS architecture pattern.",
                        Status = ProjectStatus.Open,
                        CreatedBy = "Admin",
                        Created = DateTimeOffset.Now,
                        StatusId = 1
                    });
            modelBuilder.Entity<ProjectAction>()
              .HasData(
                  new ProjectAction()
                  {
                      Id = Guid.NewGuid(),
                      Title = "Domain",
                      Description = "Make domain classes",
                      Feedback = "",
                      ProjectId = firstProjectGuid,
                      CreatedBy = "Admin",
                      Created = DateTimeOffset.Now,
                      Established = DateTimeOffset.Now,
                      DeadLine = deadline,
                      StatusId = 1,
                      EmployeeId = firstEmployeeGuid,
                      Status = ProgressStatus.ToDo,
                      ManagerId = managerGuid
                  });
            modelBuilder.Entity<ProjectAction>()
                .HasData(
                    new ProjectAction()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Application",
                        Description = "Write Queries and Commands",
                        Feedback = "",
                        ProjectId = firstProjectGuid,
                        CreatedBy = "Admin",
                        Created = DateTimeOffset.Now,
                        Established = DateTimeOffset.Now,
                        DeadLine = deadline,
                        StatusId = 1,
                        EmployeeId = firstEmployeeGuid,
                        Status = ProgressStatus.ToDo,
                        ManagerId = managerGuid
                    });
            modelBuilder.Entity<ProjectAction>()
                .HasData(
                    new ProjectAction()
                    {
                        Id = Guid.NewGuid(),
                        Title = "UnitTests",
                        Description = "Write and run unit tests",
                        Feedback = "",
                        ProjectId = firstProjectGuid,
                        CreatedBy = "Admin",
                        Created = DateTimeOffset.Now,
                        Established = DateTimeOffset.Now,
                        DeadLine = deadline,
                        StatusId = 1,
                        EmployeeId = firstEmployeeGuid,
                        Status = ProgressStatus.ToDo,
                        ManagerId = managerGuid
                    });
            modelBuilder.Entity<ProjectAction>()
                .HasData(
                    new ProjectAction()
                    {
                        Id = Guid.NewGuid(),
                        Title = "API",
                        Description = "Create API Controllers",
                        Feedback = "",
                        ProjectId = firstProjectGuid,
                        CreatedBy = "Admin",
                        Created = DateTimeOffset.Now,
                        Established = DateTimeOffset.Now,
                        DeadLine = deadline,
                        StatusId = 1,
                        EmployeeId = firstEmployeeGuid,
                        Status = ProgressStatus.ToDo,
                        ManagerId = managerGuid
                    });
            modelBuilder.Entity<ProjectAction>()
                .HasData(
                    new ProjectAction()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Integration Tests",
                        Description = "Create and run Integration Tests",
                        Feedback = "",
                        ProjectId = firstProjectGuid,
                        CreatedBy = "Admin",
                        Created = DateTimeOffset.Now,
                        Established = DateTimeOffset.Now,
                        DeadLine = deadline,
                        StatusId = 1,
                        EmployeeId = secondEmployeeGuid,
                        Status = ProgressStatus.ToDo,
                        ManagerId = managerGuid
                    });
            modelBuilder.Entity<ProjectEmployeeManager>()
               .HasData(
                   new ProjectEmployeeManager()
                   {
                       ManagerId = managerGuid,
                       EmployeeId = firstEmployeeGuid,
                       ProjectId = firstProjectGuid
                   });
            modelBuilder.Entity<ProjectEmployeeManager>()
               .HasData(
                   new ProjectEmployeeManager()
                   {
                       ManagerId = managerGuid,
                       EmployeeId = secondEmployeeGuid,
                       ProjectId = firstProjectGuid
                   });
            #endregion

            #region Second Project
            modelBuilder.Entity<Project>()
               .HasData(
                   new Project()
                   {
                       Id = secondProjectGuid,
                       Title = "Persistance Layer",
                       Description = "DB infrastructure create in Code First approach.",
                       Status = ProjectStatus.Open,
                       CreatedBy = "Admin",
                       Created = DateTimeOffset.Now,
                       StatusId = 1
                   });
            modelBuilder.Entity<ProjectAction>()
                .HasData(
                    new ProjectAction()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Schema",
                        Description = "Create Db schema",
                        Feedback = "",
                        ProjectId = secondProjectGuid,
                        CreatedBy = "Admin",
                        Created = DateTimeOffset.Now,
                        Established = DateTimeOffset.Now,
                        DeadLine = deadline,
                        StatusId = 1,
                        EmployeeId = secondEmployeeGuid,
                        Status = ProgressStatus.ToDo,
                        ManagerId = managerGuid
                    });
            modelBuilder.Entity<ProjectAction>()
                .HasData(
                    new ProjectAction()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Data seed",
                        Description = "Create data seed",
                        Feedback = "",
                        ProjectId = secondProjectGuid,
                        CreatedBy = "Admin",
                        Created = DateTimeOffset.Now,
                        Established = DateTimeOffset.Now,
                        DeadLine = deadline,
                        StatusId = 1,
                        EmployeeId = secondEmployeeGuid,
                        Status = ProgressStatus.ToDo,
                        ManagerId = managerGuid
                    });
            modelBuilder.Entity<ProjectAction>()
                .HasData(
                    new ProjectAction()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Initial Migration",
                        Description = "Initial Db with test data",
                        Feedback = "",
                        ProjectId = secondProjectGuid,
                        CreatedBy = "Admin",
                        Created = DateTimeOffset.Now,
                        Established = DateTimeOffset.Now,
                        DeadLine = deadline,
                        StatusId = 1,
                        EmployeeId = secondEmployeeGuid,
                        Status = ProgressStatus.ToDo,
                        ManagerId = managerGuid
                    });
            modelBuilder.Entity<ProjectEmployeeManager>()
                .HasData(
                    new ProjectEmployeeManager()
                    {
                        ManagerId = managerGuid,
                        EmployeeId = secondEmployeeGuid,
                        ProjectId = secondProjectGuid
                    });
            #endregion

            #region ThirdProject
            modelBuilder.Entity<Project>()
                .HasData(
                    new Project()
                    {
                        Id = thirdProjectGuid,
                        Title = "Frontend",
                        Description = "Create consumer for API in Angular framework.",
                        Status = ProjectStatus.Open,
                        CreatedBy = "Admin",
                        Created = DateTimeOffset.Now,
                        StatusId = 1
                    });
            modelBuilder.Entity<ProjectAction>()
                .HasData(
                    new ProjectAction()
                    {
                        Id = Guid.NewGuid(),
                        Title = "UI Plan",
                        Description = "Plan UI for application",
                        Feedback = "",
                        ProjectId = thirdProjectGuid,
                        CreatedBy = "Admin",
                        Created = DateTimeOffset.Now,
                        Established = DateTimeOffset.Now,
                        DeadLine = deadline,
                        StatusId = 1,
                        EmployeeId = thirdEmployeeGuid,
                        Status = ProgressStatus.ToDo,
                        ManagerId = managerGuid
                    });
            modelBuilder.Entity<ProjectAction>()
                .HasData(
                    new ProjectAction()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Create components",
                        Description = "Create angular components",
                        Feedback = "",
                        ProjectId = thirdProjectGuid,
                        CreatedBy = "Admin",
                        Created = DateTimeOffset.Now,
                        Established = DateTimeOffset.Now,
                        DeadLine = deadline.AddDays(1),
                        StatusId = 1,
                        EmployeeId = thirdEmployeeGuid,
                        Status = ProgressStatus.ToDo,
                        ManagerId = managerGuid
                    });
            modelBuilder.Entity<ProjectAction>()
                .HasData(
                    new ProjectAction()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Conection with API",
                        Description = "Connect Frontent with Backend via API",
                        Feedback = "",
                        ProjectId = thirdProjectGuid,
                        CreatedBy = "Admin",
                        Created = DateTimeOffset.Now,
                        Established = DateTimeOffset.Now,
                        DeadLine = deadline.AddDays(1),
                        StatusId = 1,
                        EmployeeId = thirdEmployeeGuid,
                        Status = ProgressStatus.ToDo,
                        ManagerId = managerGuid
                    });
            modelBuilder.Entity<ProjectAction>()
                .HasData(
                    new ProjectAction()
                    {
                        Id = Guid.NewGuid(),
                        Title = "Application style",
                        Description = "Add css",
                        Feedback = "",
                        ProjectId = thirdProjectGuid,
                        CreatedBy = "Admin",
                        Created = DateTimeOffset.Now,
                        Established = DateTimeOffset.Now,
                        DeadLine = deadline.AddDays(1),
                        StatusId = 1,
                        EmployeeId = thirdEmployeeGuid,
                        Status = ProgressStatus.ToDo,
                        ManagerId = managerGuid
                    });
            modelBuilder.Entity<ProjectEmployeeManager>()
                .HasData(
                    new ProjectEmployeeManager()
                    {
                        ManagerId = managerGuid,
                        EmployeeId = thirdEmployeeGuid,
                        ProjectId = thirdProjectGuid
                    });
            #endregion
        }
    }
}
