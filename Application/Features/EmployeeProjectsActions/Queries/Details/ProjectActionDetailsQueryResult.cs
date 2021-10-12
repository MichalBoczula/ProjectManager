using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.EmployeeProjectsActions.Queries.Details
{
    public class ProjectActionDetailsQueryResult : Tuple<bool, List<Exception>, ProjectActionDetailsVm>
    {
        public bool AreThereException { get { return Item1; } }
        public List<Exception> ExceptionsList { get { return Item2; } }
        public ProjectActionDetailsVm Vm { get { return Item3; } }

        public ProjectActionDetailsQueryResult(
            bool areThereException,
            List<Exception> exceptionsList,
           ProjectActionDetailsVm vm)
            : base(areThereException, exceptionsList, vm)
        {
        }
        

    }
}
