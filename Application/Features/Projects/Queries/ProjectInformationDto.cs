using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Projects.Queries
{
    public class ProjectInformationDto
    {
        public ProgressStatus Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Feedback { get; set; }
    }
}
