using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Common.Exceptions
{
    public class ManagerEmptyGuidException : Exception
    {
        public const string message = "Manager with  this GUID doesn't exists, Please check GUID";

        public ManagerEmptyGuidException()
            : base(message)
        {
        }
}
}
