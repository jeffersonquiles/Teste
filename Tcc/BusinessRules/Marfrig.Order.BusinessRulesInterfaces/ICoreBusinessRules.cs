using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Core.BusinessEntities;

namespace Tcc.Core.BusinessRulesInterfaces
{
    public interface ICoreBusinessRules
    {

        #region BodyPart

        IList<BodyPart> GetBodyParts();

        #endregion

        #region Category

        IList<Category> GetCategories();

        #endregion

        #region ClassificationType

        IList<ClassificationType> GetClassificationTypes();

        #endregion

        #region Level

        IList<Level> GetLevels();

        #endregion

        #region PhoneNumberType

        IList<PhoneNumberType> GetPhoneNumberTypes();

        #endregion

        #region PhoneProvider

        IList<PhoneProvider> GetPhoneProviders();

        #endregion

        #region FreeTrainingTypes 

        IList<FreeTrainingType> GetFreeTrainingTypes();

        #endregion

        #region FreeTraining 

        IList<FreeTraining> GetFreeTraining(Int32 FreeTrainingTypeId);

        #endregion

        #region WeekDay

        IList<WeekDay> GetWeekDays();

        #endregion

        #region Class

        bool SaveClass(Class entity);
        IList<Class> GetClasses();
        bool DeleteClass(Guid UniqueId);
        #endregion

        #region TeacherDetail

        IList<Teacher> GetTeachersToDetail();
        bool SaveTeacherDetail(TeacherDetail entity);
        bool DeleteTeacherDetail(Guid UniqueId);
        
        #endregion
    }
}
