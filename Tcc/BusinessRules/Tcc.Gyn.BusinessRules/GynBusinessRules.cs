using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Core.Providers;
using Tcc.Gyn.BusinessEntities;
using Tcc.Gyn.BusinessRulesInterfaces;

namespace Tcc.Gyn.BusinessRules
{
    public class GynBusinessRules : IGynBusinessRules
    {
        #region Constructor 

        public GynProviderBase SqlGynProvider { get; set; }

        public GynBusinessRules(GynProviderBase sqlGynProvider)
        {
            SqlGynProvider = sqlGynProvider;
        }

        #endregion

        #region Gyns

        public IList<Tcc.Gyn.BusinessEntities.Gyn> GetGyns()
        {
            return SqlGynProvider.GetGyns();
        }

        #endregion

        #region ExerciseList

        public IList<ExerciseList> GetExerciseList(int ExerciseListId)
        {
            IList<ExerciseList> lstExerciseList = new List<ExerciseList>();

            lstExerciseList = SqlGynProvider.GetExerciseList();
            foreach(var entity in lstExerciseList)
            {
                entity.Exercises = SqlGynProvider.GetExerciseByExerciseListId(entity.Id);
            }
            return lstExerciseList;
        }

        public bool DeleteExerciseList(Guid UniqueId)
        {
            SqlGynProvider.DeleteExerciseList(UniqueId);
            return true;
        }

        public bool SaveExerciseList(ExerciseList entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.UpdateByPersonId = 1;
            entity.IsDeleted = false;

            if (entity.Id > 0)
            {
                SqlGynProvider.DeleteExerciseList(entity.UniqueId);

                foreach(var item in entity.Exercises)
                {
                    item.ExerciseListId = entity.Id;
                    item.UpdateDate = entity.UpdateDate;
                    item.CreateDate = item.UpdateDate;
                    item.UpdateByPersonId = entity.UpdateByPersonId;
                    item.IsDeleted = entity.IsDeleted;
                    item.UniqueId = Guid.NewGuid();
                    item.CreateByPersonId = item.UpdateByPersonId;
                    SqlGynProvider.InsertExercise(item);
                }

                SqlGynProvider.UpdateExerciseList(entity);
            } else
            {
                entity.CreateDate = entity.UpdateDate;
                entity.CreateByPersonId = entity.UpdateByPersonId;
                entity.UniqueId = Guid.NewGuid();
                entity.Id = SqlGynProvider.InsertExerciseList(entity);
                foreach (var item in entity.Exercises)
                {
                    item.UpdateDate = entity.UpdateDate;
                    item.CreateDate = item.UpdateDate;
                    item.UpdateByPersonId = entity.UpdateByPersonId;
                    item.IsDeleted = entity.IsDeleted;
                    item.UniqueId = Guid.NewGuid();
                    item.CreateByPersonId = item.UpdateByPersonId;
                    item.ExerciseListId = entity.Id;
                    SqlGynProvider.InsertExercise(item);
                }
            }
            return true;
        }

        #endregion
    }
}
