using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Core.BusinessEntities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TeacherDetail TeacherDetail { get; set; }
        public IList<Class> ActiveClasses { get; set; }
    }
}
