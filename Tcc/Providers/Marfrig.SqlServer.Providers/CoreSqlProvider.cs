using Tcc.Core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.SQLServer.Providers;
using Tcc.Core.BusinessEntities;

namespace Tcc.SqlServer.Providers
{
    public class CoreSqlProvider : CoreProviderBase
    {

        #region Constructor 

        private TccContext TccContext;

        public CoreSqlProvider(TccContext tccContext)
        {
            TccContext = tccContext;
        }

        #endregion

        #region BodyPart

        public override IList<BodyPart> GetBodyParts()
        {
            return TccContext.Tcc.DB.Sql(@"select * from BodyPart").QueryMany<BodyPart>();
        }

        #endregion

        #region Category

        public override IList<Category> GetCategories()
        {
            return TccContext.Tcc.DB.Sql(@"select * from Category").QueryMany<Category>();
        }

        #endregion

        #region ClassificationType

        public override IList<ClassificationType> GetClassificationTypes()
        {
            return TccContext.Tcc.DB.Sql(@"select * from ClassificationType").QueryMany<ClassificationType>();
        }

        #endregion

        #region Level

        public override IList<Level> GetLevels()
        {
            return TccContext.Tcc.DB.Sql(@"select * from Level").QueryMany<Level>();
        }

        #endregion

        #region PhoneNumberType

        public override IList<PhoneNumberType> GetPhoneNumberTypes()
        {
            return TccContext.Tcc.DB.Sql(@"select * from PhoneNumberType").QueryMany<PhoneNumberType>();
        }

        #endregion

        #region PhoneProvider

        public override IList<PhoneProvider> GetPhoneProviders()
        {
            return TccContext.Tcc.DB.Sql(@"select * from PhoneProvider").QueryMany<PhoneProvider>();
        }

        #endregion

        #region FreeTrainingTypes 

        public override IList<FreeTrainingType> GetFreeTrainingTypes()
        {
            return TccContext.Tcc.DB.Sql(@"select * from FreeTrainingType").QueryMany<FreeTrainingType>();
        }

        #endregion

        #region FreeTraining 

        public override IList<FreeTraining> GetFreeTraining(Int32 FreeTrainingTypeId)
        {
            return TccContext.Tcc.DB.Sql(@"select * from FreeTraining where FreeTrainingTypeId = @0", FreeTrainingTypeId).QueryMany<FreeTraining>();
        }

        #endregion

        #region ExerciseFreeTraining

        public override IList<ExerciseFreeTraining> GetExerciseFreeTraining(Int32 FreeTrainingId)
        {
            return TccContext.Tcc.DB.Sql(@"select * from ExerciseFreeTraining where FreeTrainingId = @0", FreeTrainingId).QueryMany<ExerciseFreeTraining>();
        }
        #endregion

        #region WeekDay

        public override IList<WeekDay> GetWeekDays()
        {
            return TccContext.Tcc.DB.Sql(@"select * from WeekDay").QueryMany<WeekDay>();
        }

        #endregion

        #region Class

        public override int UpdateClass(Class entity)
        {


            return TccContext.Tcc.DB.Update("Class")
                .Column("Name", entity.Name)
                .Column("TeacharId", entity.TeacharId)
                .Column("UpdateByPersonId", entity.UpdateByPersonId)
                .Column("UpdateDate", DateTime.Now)
                .Where("Id", entity.Id).
                Execute();
         }

        public override int InsertClass(Class entity)
        {
            return TccContext.Tcc.DB.Insert("Class")
                                            .Column("Name", entity.Name)
                                            .Column("TeacharId", entity.TeacharId)
                                            .Column("UpdateDate", entity.UpdateDate)
                                            .Column("CreateDate", entity.CreateDate)
                                            .Column("IsDeleted", entity.IsDeleted)
                                            .Column("CreateByPersonId", entity.CreateByPersonId)
                                            .Column("UpdateByPersonId", entity.UpdateByPersonId)
                                            .Column("UniqueId", entity.UniqueId)
                                            .ExecuteReturnLastId<int>();
        }

        public override IList<Class> GetClasses()
        {
            return TccContext.Tcc.DB.Sql(@"select Class.*, 
                                         Person.Name as 'TeacherName'

                                        from Class Class

                                        inner join Person Person
                                        on Person.Id = Class.TeacharId

                                        where Class.IsDeleted = 0").QueryMany<Class>();
        }

        public override int DeleteClass(Guid UniqueId)
        {
            return TccContext.Tcc.DB.Sql(@"update Class set IsDeleted = 1 where UniqueId = @0", UniqueId).Execute();
        }

        public override IList<Class> GetClassesByTeacherId(int TeacherId)
        {
            return TccContext.Tcc.DB.Sql(@"select Class.*, 
                                        Person.Name as 'TeacherName'

                                        from Class Class

                                        inner join Person Person
                                        on Person.Id = Class.TeacharId

                                        where Class.IsDeleted = 0
                                        and Class.TeacharId = @0", TeacherId).QueryMany<Class>();
        }

        #endregion

        #region ClassPeriod

        public override int InsertClassPeriod(ClassPeriod entity)
        {
            return TccContext.Tcc.DB.Insert<ClassPeriod>("ClassPeriod", entity)
                                           .AutoMap(x => x.Id)
                                           .ExecuteReturnLastId<int>();
        }

        public override int DeleteClassPeriod(int ClassId)
        {
            return TccContext.Tcc.DB.Sql(@"delete from ClassPeriod where ClassId = @0", ClassId).Execute();
        }

        public override IList<ClassPeriod> GetClassPeriod (int ClassId)
        {
            
            var lst = TccContext.Tcc.DB.Sql(@"select * from ClassPeriod where ClassId = @0 and IsDeleted = 0", ClassId).QueryMany<ClassPeriod>();
            return lst;
        }

        #endregion

        #region TeacherDetail


        public override IList<Teacher> GetTeachersToDetail()
        {
            return TccContext.Tcc.DB.Sql(@" select 
                                    Person.Id as 'Id',
                                    Person.Name as 'Name'

                                    from Person Person

                                    inner join PersonClassification PersonClassification
                                    on PersonClassification.PersonId = Person.Id
                                    and PersonClassification.ClassificationTypeId = 2
            ").QueryMany<Teacher>();
        }

        public override TeacherDetail GetTeacherDetails(int TeacherId)
        {
            return TccContext.Tcc.DB.Sql(@"select * from TeacherDetail where IsDeleted = 0 and TeacherId = @0", TeacherId).QuerySingle<TeacherDetail>();
        }

        public override int InsertTeacherDetail(TeacherDetail entity)
        {
            return TccContext.Tcc.DB.Insert("TeacherDetail")
                                            .Column("TeacherId", entity.TeacherId)
                                            .Column("Resume", entity.Resume)
                                            .Column("UpdateDate", entity.UpdateDate)
                                            .Column("CreateDate", entity.CreateDate)
                                            .Column("IsDeleted", entity.IsDeleted)
                                            .Column("CreateByPersonId", entity.CreateByPersonId)
                                            .Column("UpdateByPersonId", entity.UpdateByPersonId)
                                            .Column("UniqueId", entity.UniqueId)
                                            .ExecuteReturnLastId<int>();
        }

        public override int UpdateTeacherDetail(TeacherDetail entity)
        {
            return TccContext.Tcc.DB.Update("TeacherDetail")
                .Column("Resume", entity.Resume)
                .Column("UpdateByPersonId", entity.UpdateByPersonId)
                .Column("UpdateDate", DateTime.Now)
                .Where("Id", entity.Id).
                Execute();
        }

        public override int DeleteTeacherDetail(Guid UniqueId)
        {
            return TccContext.Tcc.DB.Sql(@"update TeacherDetail set IsDeleted = 1 where UniqueId = @0", UniqueId).Execute();
        }

        #endregion

        #region Qualification

        public override int InsertQualification(Qualifications entity)
        {
            return TccContext.Tcc.DB.Insert<Qualifications>("Qualifications", entity)
                               .AutoMap(x => x.Id)
                               .ExecuteReturnLastId<int>();
        }

        public override int DeleteQualification(int TeacherDetailId)
        {
            return TccContext.Tcc.DB.Sql(@"delete from Qualifications where TeacherDetailId = @0", TeacherDetailId).Execute();
        }

        public override IList<Qualifications> GetQualifications(int TeacherDetailId)
        {
            var lst = TccContext.Tcc.DB.Sql(@"select * from Qualifications where TeacherDetailId = @0 and IsDeleted = 0", TeacherDetailId).QueryMany<Qualifications>();
            return lst;
        }


        #endregion

    }
}