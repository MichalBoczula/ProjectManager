using Application.Features.EmployeeProjectsActions.Queries.Details;
using Application.Features.EmployeeProjectsActions.Queries.List;
using Application.Features.ManagerProjectAction.Queries.ProjectDetails;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMapsForEmployee();
            CreateMapsForManager();
        }

        private void CreateMapsForManager()
        {
            CreateMap<Employee, EmployeeForManagersProjectDetailsDto>()
                .ForMember(m => m.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"));
            CreateMap<ProjectAction, ProjectActionForMangersProjectDetailsDto>()
                .ForMember(m => m.Status, opt => opt.MapFrom(x => x.Status.ToString()))
                .ForMember(m => m.Employee, opt => opt.Ignore());
            CreateMap<Project, ProjectForManagersDto>()
                .ForMember(m => m.Status, opt => opt.MapFrom(x => x.Status.ToString()));
        }

        private void CreateMapsForEmployee()
        {
            CreateMap<Project, ProjectInformationDto>()
                .ForMember(p => p.Status, opt => opt.MapFrom(x => x.Status.ToString()));
            CreateMap<ProjectAction, ProjectActionDto>()
                .ForMember(pa => pa.Status, opt => opt.MapFrom(x => x.Status.ToString()));
            CreateMap<Manager, ManagerForProjectDetailsDto>()
                .ForMember(m => m.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"));
            CreateMap<ProjectAction, ProjectActionDetailsDto>()
                .ForMember(pa => pa.Status, opt => opt.MapFrom(x => x.Status.ToString()));
        }
    }
}
