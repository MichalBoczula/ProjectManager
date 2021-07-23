﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProjectsActions.Queries.List
{
    public class ProjectActionDto
    {
        public string Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Feedback { get; set; }
        public DateTimeOffset Established { get; set; }
        public DateTimeOffset Done { get; set; }
        public DateTimeOffset DeadLine { get; set; }
    }
}
