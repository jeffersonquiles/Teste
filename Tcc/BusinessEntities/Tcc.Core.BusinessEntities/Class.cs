using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Core.BusinessEntities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacharId { get; set; }
        public string TeacherName { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateByPersonId { get; set; }
        public int UpdateByPersonId { get; set; }
        public bool IsDeleted { get; set; }
        public Guid UniqueId { get; set; }
        public IList<ClassPeriod> ClassPeriod { get;set;}
    }
}
