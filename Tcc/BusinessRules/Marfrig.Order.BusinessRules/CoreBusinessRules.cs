using Tcc.Core.BusinessRulesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Core.Providers;
using System.Runtime.CompilerServices;
using Tcc.Core.BusinessEntities;

namespace Tcc.Core.BusinessRules
{
    public class CoreBusinessRules : ICoreBusinessRules
    {

        #region Constructor 

        public CoreProviderBase SqlCoreProvider { get; set; }


        public CoreBusinessRules(CoreProviderBase sqlCoreProvider)
        {
            SqlCoreProvider = sqlCoreProvider;
        }

        #endregion

        #region BodyPart

        public IList<BodyPart> GetBodyParts()
        {
            return SqlCoreProvider.GetBodyParts();
        }
        #endregion

        #region Category

        public IList<Category> GetCategories()
        {
            return SqlCoreProvider.GetCategories();
        }

        #endregion

        #region ClassificationType

        public IList<ClassificationType> GetClassificationTypes()
        {
            return SqlCoreProvider.GetClassificationTypes();
        }

        #endregion

        #region Level

        public IList<Level> GetLevels()
        {
            return SqlCoreProvider.GetLevels();
        }

        #endregion

        #region PhoneNumberType

        public IList<PhoneNumberType> GetPhoneNumberTypes()
        {
            return SqlCoreProvider.GetPhoneNumberTypes();
        }

        #endregion

        #region PhoneProvider

        public IList<PhoneProvider> GetPhoneProviders()
        {
            return SqlCoreProvider.GetPhoneProviders();
        }

        #endregion

        #region FreeTrainingTypes 

        public IList<FreeTrainingType> GetFreeTrainingTypes()
        {
            return SqlCoreProvider.GetFreeTrainingTypes();
        }

        #endregion

        #region FreeTraining 

        public IList<FreeTraining> GetFreeTraining(int FreeTrainingTypeId)
        {
            IList<FreeTraining> LstFreeTraining = SqlCoreProvider.GetFreeTraining(FreeTrainingTypeId);

            foreach (var item in LstFreeTraining)
            {
                item.ExerciseFreeTraining = SqlCoreProvider.GetExerciseFreeTraining(item.Id);
            }

            return LstFreeTraining;
        }

        #endregion

        #region WeekDay

        public IList<WeekDay> GetWeekDays()
        {
            return SqlCoreProvider.GetWeekDays();
        }

        #endregion

        #region Class

        public bool SaveClass(Class entity)
        {

            entity.UpdateDate = DateTime.Now;
            entity.UpdateByPersonId = 2;
            entity.IsDeleted = false;
            entity.CreateDate = entity.UpdateDate;
            entity.CreateByPersonId = entity.UpdateByPersonId;


            if (entity.Id > 0)
            {
                SqlCoreProvider.UpdateClass(entity);
                SqlCoreProvider.DeleteClassPeriod(entity.Id);
                foreach(var item in entity.ClassPeriod)
                {
                    item.ClassId = entity.Id;
                    item.CreateByPersonId = 2;
                    item.UpdateByPersonId = 2;
                    item.CreateDate = DateTime.Now;
                    item.UpdateDate = item.CreateDate;
                    item.IsDeleted = false;
                    item.UniqueId = Guid.NewGuid();
                    SqlCoreProvider.InsertClassPeriod(item);
                }
            }
            else
            {
                entity.UniqueId = Guid.NewGuid();
                var result = SqlCoreProvider.InsertClass(entity);
                foreach(var item in entity.ClassPeriod)
                {
                    item.CreateByPersonId = 2;
                    item.UpdateByPersonId = 2;
                    item.CreateDate = DateTime.Now;
                    item.UpdateDate = item.CreateDate;
                    item.IsDeleted = false;
                    item.UniqueId = Guid.NewGuid();
                    item.ClassId = result;
                    SqlCoreProvider.InsertClassPeriod(item);
                }

            }
            return true;

        }

        public IList<Class> GetClasses()
        {
            var result = SqlCoreProvider.GetClasses();

            foreach (var item in result)
            {
                item.ClassPeriod = SqlCoreProvider.GetClassPeriod(item.Id);
            }

            return result;
        }

        public bool DeleteClass (Guid UniqueId)
        {
            SqlCoreProvider.DeleteClass(UniqueId);
            return true;
        }

        #endregion

        #region TeacherDetail

        public IList<Teacher> GetTeachersToDetail()
        {
            var result = SqlCoreProvider.GetTeachersToDetail();

            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    item.TeacherDetail = SqlCoreProvider.GetTeacherDetails(item.Id);
                    item.ActiveClasses = SqlCoreProvider.GetClassesByTeacherId(item.Id);

                    if (item.TeacherDetail != null)
                    {
                        item.TeacherDetail.Qualifications = SqlCoreProvider.GetQualifications(item.TeacherDetail.Id);
                    }

                    if (item.ActiveClasses != null)
                    {
                        foreach (var y in item.ActiveClasses)
                        {
                            y.ClassPeriod = SqlCoreProvider.GetClassPeriod(y.Id);
                        }
                    }
                }
            }


            return result;

        }


        public bool SaveTeacherDetail(TeacherDetail entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.UpdateByPersonId = 2;
            entity.IsDeleted = false;


            if (entity.Id > 0)
            {
                SqlCoreProvider.UpdateTeacherDetail(entity);
                SqlCoreProvider.DeleteQualification(entity.Id);
                foreach (var item in entity.Qualifications)
                {
                    item.TeacherDetailId = entity.Id;
                    item.CreateByPersonId = 2;
                    item.UpdateByPersonId = 2;
                    item.CreateDate = DateTime.Now;
                    item.UpdateDate = item.CreateDate;
                    item.IsDeleted = false;
                    item.UniqueId = Guid.NewGuid();
                    SqlCoreProvider.InsertQualification(item);
                }
            }
            else
            {
                entity.UniqueId = Guid.NewGuid();
                entity.CreateDate = DateTime.Now;
                entity.CreateByPersonId = 2;
                var result = SqlCoreProvider.InsertTeacherDetail(entity);
                foreach (var item in entity.Qualifications)
                {
                    item.CreateByPersonId = 2;
                    item.UpdateByPersonId = 2;
                    item.CreateDate = DateTime.Now;
                    item.UpdateDate = DateTime.Now;
                    item.IsDeleted = false;
                    item.UniqueId = Guid.NewGuid();
                    item.TeacherDetailId = result;
                    SqlCoreProvider.InsertQualification(item);
                }

            }
            return true;
        }

        public bool DeleteTeacherDetail(Guid UniqueId)
        {
            SqlCoreProvider.DeleteTeacherDetail(UniqueId);
            return true;
        }



        #endregion

    }
}
