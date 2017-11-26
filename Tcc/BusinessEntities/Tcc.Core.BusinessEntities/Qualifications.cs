using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Core.BusinessEntities
{
    public class Qualifications
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherDetailId { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateByPersonId { get; set; }
        public int UpdateByPersonId { get; set; }
        public bool IsDeleted { get; set; }
        public Guid UniqueId { get; set; }
    }
}
