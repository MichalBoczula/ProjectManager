using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Common.Exceptions
{
    public class EmployeeDoesntExistsException : Exception
    {
        public const string message = "Employee doesn't exists, Please check EMAIL";

        public EmployeeDoesntExistsException()
            : base(message)
        {
        }
    }
}
