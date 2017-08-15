using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Gyn.BusinessEntities;

namespace Tcc.Core.Providers
{
    public class GynProviderBase : ProviderBase
    {
        #region Gyns

        public virtual IList<Tcc.Gyn.BusinessEntities.Gyn> GetGyns()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ExerciseList

        public virtual IList<ExerciseList> GetExerciseList()
        {
            throw new NotImplementedException();
        }

        public virtual int DeleteExerciseList(Guid UniqueId)
        {
            throw new NotImplementedException();
        }

        public virtual int InsertExerciseList(ExerciseList entity)
        {
            throw new NotImplementedException();
        }

        public virtual int UpdateExerciseList(ExerciseList entity)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Exercise

        public virtual IList<Exercise> GetExerciseByExerciseListId(int ExerciseListId)
        {
            throw new NotImplementedException();
        }

        public virtual int DeleteExercise(Guid UniqueId)
        {
            throw new NotImplementedException();
        }

        public virtual int InsertExercise(Exercise entity)
        {
            throw new NotImplementedException();
        }

        public virtual int UpdateExercise(Exercise entity)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
