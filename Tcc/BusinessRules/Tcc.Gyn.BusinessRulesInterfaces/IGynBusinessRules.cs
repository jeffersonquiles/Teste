using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Gyn.BusinessEntities;

namespace Tcc.Gyn.BusinessRulesInterfaces
{
    public interface IGynBusinessRules
    {
        #region Gyns

        IList<Tcc.Gyn.BusinessEntities.Gyn> GetGyns();

        #endregion

        #region ExerciseList

        IList<ExerciseList> GetExerciseList(int ExerciseListId);

        bool DeleteExerciseList(Guid UniqueId);

        bool SaveExerciseList(ExerciseList entity);

        #endregion
    }
}
