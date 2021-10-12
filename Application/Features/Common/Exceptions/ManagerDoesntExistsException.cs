using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Common.Exceptions
{
    public class ManagerDoesntExistsException : Exception
    {
        public const string message = "Manager doesn't exists, Please check EMAIL";

        public ManagerDoesntExistsException()
            : base(message)
        {
        }
    }
}
