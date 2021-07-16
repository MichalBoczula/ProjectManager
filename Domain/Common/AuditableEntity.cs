using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset Modified { get; set; }
        public int StatusId { get; set; }
        public string InactivatedBy { get; set; }
        public DateTimeOffset Inactivated { get; set; }
    }
}
