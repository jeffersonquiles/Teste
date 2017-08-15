using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Core.Providers;
using Tcc.Gyn.BusinessEntities;
using Tcc.SQLServer.Providers;

namespace Tcc.SqlServer.Providers
{
    public class GynSqlProvider : GynProviderBase
    {

        #region Constructor 

        private TccContext TccContext;

        public GynSqlProvider(TccContext tccContext)
        {
            TccContext = tccContext;
        }

        #endregion

        #region Gyns

        public override IList<Tcc.Gyn.BusinessEntities.Gyn> GetGyns()
        {
            return TccContext.Tcc.DB.Sql(@"select * from Gyn").QueryMany<Tcc.Gyn.BusinessEntities.Gyn>();
        }

        #endregion

        #region ExerciseList

        public override IList<ExerciseList> GetExerciseList()
        {
            return TccContext.Tcc.DB.Sql(@"select * from ExerciseList where GynId = @0").QueryMany<ExerciseList>();
        }

        public override int DeleteExerciseList(Guid UniqueId)
        {
            return TccContext.Tcc.DB.Sql(@"update ExerciseList set IsDeleted = 0 and UpdateByPersonId = @1 and UpdateDate = @2").Execute();
        }

        public override int InsertExerciseList(ExerciseList entity)
        {
            return TccContext.Tcc.DB.Insert<ExerciseList>("ExerciseList", entity)
                                                        .AutoMap(x => x.Id)
                                                        .ExecuteReturnLastId<int>();
        }

        public override int UpdateExerciseList(ExerciseList entity)
        {
            TccContext.Tcc.DB.Update<ExerciseList>("ExerciseList", entity)
                                                  .AutoMap(x => x.Id)
                                                  .Where(x => x.Id)
                                                  .Execute();
            return entity.Id;
        }


        #endregion

        #region Exercise

        public override IList<Exercise> GetExerciseByExerciseListId(int ExerciseListId)
        {
            return TccContext.Tcc.DB.Sql(@"select * from Exercise where ExerciseListId = @0 and IsDeleted = 0", ExerciseListId).QueryMany<Exercise>();
        }

        public override int DeleteExercise(Guid UniqueId)
        {
            return TccContext.Tcc.DB.Sql(@"update Exercise set IsDeleted = 0 and UpdateByPersonId = @1 and UpdateDate = @2").Execute();
        }

        public override int InsertExercise(Exercise entity)
        {
            return TccContext.Tcc.DB.Insert<Exercise>("Exercise", entity)
                                             .AutoMap(x => x.Id)
                                             .ExecuteReturnLastId<int>();
        }

        public override int UpdateExercise(Exercise entity)
        {
            TccContext.Tcc.DB.Update<Exercise>("Exercise", entity)
                                                  .AutoMap(x => x.Id)
                                                  .Where(x => x.Id)
                                                  .Execute();
            return entity.Id;
        }


        #endregion

    }
}
