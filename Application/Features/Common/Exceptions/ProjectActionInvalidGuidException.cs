using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Common.Exceptions
{
    public class ProjectActionInvalidGuidException : Exception
    {
        public const string message = "Invalid Project Action GUID, GUID has format 00000000-0000-0000-0000-000000000000, check, correct and send request again";

        public ProjectActionInvalidGuidException()
            : base(message)
        {
        }
    }
}
