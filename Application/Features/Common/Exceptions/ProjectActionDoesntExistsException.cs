using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Common.Exceptions
{
    public class ProjectActionDoesntExistsException : Exception
    {
        public const string message = "Project Action doesn't exists, Please check GUID";

        public ProjectActionDoesntExistsException()
            : base(message)
        {
        }
    }
}
