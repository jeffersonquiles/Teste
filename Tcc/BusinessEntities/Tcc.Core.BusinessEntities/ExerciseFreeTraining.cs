using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Core.BusinessEntities
{
    public class ExerciseFreeTraining
    {
        public int Id { get; set; }
        public string Name { get; set; }
	    public int FreeTrainingId { get; set; }
    }
}
