using Application.Features.ProjectsActions.Queries.List;
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
            CreateMap<Project, ProjectInformationDto>()
                .ForMember(p => p.Status, opt => opt.MapFrom(x => x.Status.ToString()));
            CreateMap<ProjectAction, ProjectActionDto>()
                .ForMember(pa => pa.Status, opt => opt.MapFrom(x => x.Status.ToString()));
        }
    }
}
