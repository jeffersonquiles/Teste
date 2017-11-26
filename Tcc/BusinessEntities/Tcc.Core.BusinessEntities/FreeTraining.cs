using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Core.BusinessEntities
{
    public  class FreeTraining
    {
        public int Id { get; set; }
        public string Name { get; set; }
	    public string Description { get; set; }
	    public string TrainingSessions { get; set; }
	    public int FreeTrainingTypeId { get; set; }
        public IList<ExerciseFreeTraining> ExerciseFreeTraining { get; set; }
    }
}
