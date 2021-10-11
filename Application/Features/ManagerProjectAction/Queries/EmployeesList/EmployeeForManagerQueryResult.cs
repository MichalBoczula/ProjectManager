using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Queries.EmployeesList
{
    public class EmployeeForManagerQueryResult : Tuple<bool, List<Exception>, List<EmployeeForManagerVm>>
    {
        public bool AreThereException { get { return Item1; } }
        public List<Exception> ExceptionsList { get { return Item2; } }
        public List<EmployeeForManagerVm> Vm { get { return Item3; } }

        public EmployeeForManagerQueryResult(
            bool areThereException,
            List<Exception> exceptionsList,
            List<EmployeeForManagerVm> vm) 
            : base(areThereException, exceptionsList, vm)
        {
        }

    }
}
