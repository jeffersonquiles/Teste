using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Common;
using Tcc.Core.BusinessEntities;

namespace Tcc.Core.Providers
{
    public class CoreProviderBase : ProviderBase 
    {

        #region BodyPart

        public virtual IList<BodyPart> GetBodyParts()
        {
            throw new NotImplementedException(); 
        }

        #endregion

        #region Category

        public virtual IList<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ClassificationType

        public virtual IList<ClassificationType> GetClassificationTypes()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Level

        public virtual IList<Level> GetLevels()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PhoneNumberType

        public virtual IList<PhoneNumberType> GetPhoneNumberTypes()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PhoneProvider

        public virtual IList<PhoneProvider> GetPhoneProviders()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region FreeTrainingTypes 

        public virtual IList<FreeTrainingType> GetFreeTrainingTypes()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region FreeTraining 

        public virtual IList<FreeTraining> GetFreeTraining(Int32 FreeTrainingTypeId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ExerciseFreeTraining

        public virtual IList<ExerciseFreeTraining> GetExerciseFreeTraining(Int32 FreeTrainingId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region WeekDay

        public virtual IList<WeekDay> GetWeekDays()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Class

        public virtual int UpdateClass(Class entity)
        {
            throw new NotImplementedException();
        }

        public virtual int InsertClass(Class entity)
        {
            throw new NotImplementedException();
        }

        public virtual IList<Class> GetClasses()
        {
            throw new NotImplementedException();
        }

        public virtual int DeleteClass(Guid UniqueId)
        {
            throw new NotImplementedException();
        }

        public virtual IList<Class> GetClassesByTeacherId(int TeacherId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ClassPeriod

        public virtual int InsertClassPeriod(ClassPeriod entity)
        {
            throw new NotImplementedException();
        }

        public virtual int DeleteClassPeriod(int ClassId)
        {
            throw new NotImplementedException();
        }

        public virtual IList<ClassPeriod>  GetClassPeriod(int ClassId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TeacherDetail

        public virtual IList<Teacher> GetTeachersToDetail()
        {
            throw new NotImplementedException();
        }

        public virtual TeacherDetail GetTeacherDetails(int TeacherId)
        {
            throw new NotImplementedException();
        }

        public virtual int InsertTeacherDetail(TeacherDetail entity)
        {
            throw new NotImplementedException();
        }

        public virtual int UpdateTeacherDetail(TeacherDetail entity)
        {
            throw new NotImplementedException();
        }

        public virtual int DeleteTeacherDetail(Guid UniqueId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Qualification

        public virtual int InsertQualification(Qualifications entity)
        {
            throw new NotImplementedException();
        }

        public virtual int DeleteQualification(int TeacherDetailId)
        {
            throw new NotImplementedException();
        }

        public virtual IList<Qualifications> GetQualifications (int TeacherDetailId)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
