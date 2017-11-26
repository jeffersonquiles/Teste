using Tcc.Core.BusinessRulesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Tcc.Common;
using Tcc.Core.BusinessEntities;

namespace Tcc.Web.Host.Controllers
{
    public class CoreController : ApiControllerBase
    {

        #region Constructor
         
        private ICoreBusinessRules CoreBusinessRules { get; set; }

        public CoreController(ICoreBusinessRules coreBusinessRules)
        {
            CoreBusinessRules = coreBusinessRules;
        }

        #endregion

        #region BodyPart

        [HttpPost]
        public IHttpActionResult GetBodyParts()
        {
            return ApiResult<IList<BodyPart>>(() =>
            {
                return CoreBusinessRules.GetBodyParts();
            });
        }

        #endregion

        #region Category

        [HttpPost]
        public IHttpActionResult GetCategories()
        {
            return ApiResult<IList<Category>>(() =>
            {
                return CoreBusinessRules.GetCategories();
            });
        }

        #endregion

        #region ClassificationType

        [HttpPost]
        public IHttpActionResult GetClassificationTypes()
        {
            return ApiResult<IList<ClassificationType>>(() =>
            {
                return CoreBusinessRules.GetClassificationTypes();
            });
        }

        #endregion

        #region Level

        [HttpPost]
        public IHttpActionResult GetLevels()
        {
            return ApiResult<IList<Level>>(() =>
            {
                return CoreBusinessRules.GetLevels();
            });
        }

        #endregion

        #region PhoneNumberType

        [HttpPost]
        public IHttpActionResult GetPhoneNumberTypes()
        {
            return ApiResult<IList<PhoneNumberType>>(() =>
            {
                return CoreBusinessRules.GetPhoneNumberTypes();
            });
        }

        #endregion

        #region PhoneProvider

        [HttpPost]
        public IHttpActionResult GetPhoneProviders()
        {
            return ApiResult<IList<PhoneProvider>>(() =>
            {
                return CoreBusinessRules.GetPhoneProviders();
            });
        }

        #endregion

        #region FreeTrainingType 

        [HttpPost]

        public IHttpActionResult GetFreeTrainingTypes()
        {
            return ApiResult<IList<FreeTrainingType>>(() =>
           {
               return CoreBusinessRules.GetFreeTrainingTypes();
           });
        }

        #endregion

        #region FreeTraining 

        [HttpPost]
        public IHttpActionResult GetFreeTraining([FromBody] Int32 FreeTrainingTypeId)
        {
            return ApiResult<IList<FreeTraining>>(() =>
            {
                return CoreBusinessRules.GetFreeTraining(FreeTrainingTypeId);
            });
        }

        #endregion

        #region WeekDay
        [HttpPost]
        public IHttpActionResult GetWeekDays()
        {
            return ApiResult<IList<WeekDay>>(() =>
           {
               return CoreBusinessRules.GetWeekDays();
           });
        }

        #endregion

        #region Class
        [HttpPost]
        public IHttpActionResult SaveClass (Class entity)
        {
            return ApiResult<bool>(() =>
            {
                return CoreBusinessRules.SaveClass(entity);
            });
        }

        [HttpPost]
        public IHttpActionResult GetClasses()
        {
            return ApiResult<IList<Class>>(() =>
            {
                return CoreBusinessRules.GetClasses();
            });
        }

        [HttpPost]
        public IHttpActionResult DeleteClass ([FromBody] Guid UniqueId)
        {
            return ApiResult<bool>(() =>
            {
                return CoreBusinessRules.DeleteClass(UniqueId);
            });
        }

        #endregion

        #region TeacherDetail
        [HttpPost]
        public IHttpActionResult GetTeachersToDetail()
        {
            return ApiResult<IList<Teacher>>(() =>
            {
                return CoreBusinessRules.GetTeachersToDetail();
            });
        }

        [HttpPost]
        public IHttpActionResult SaveTeacherDetail(TeacherDetail entity)
        {
            return ApiResult<bool>(() =>
            {
                return CoreBusinessRules.SaveTeacherDetail(entity);
            });
        }

        [HttpPost]
        public IHttpActionResult DeleteTeacherDetail([FromBody] Guid UniqueId)
        {
            return ApiResult<bool>(() =>
            {
                return CoreBusinessRules.DeleteTeacherDetail(UniqueId);
            });
        }

        #endregion

        #region Test

        [HttpPost]
        public IHttpActionResult Test()
        {
            IList<Tcc.Person.BusinessEntities.Person> lstPerson = new List<Person.BusinessEntities.Person>();

            Person.BusinessEntities.Person Laurent = new Person.BusinessEntities.Person();
            Person.BusinessEntities.Person Jefferson = new Person.BusinessEntities.Person();

            Laurent.Name = "Laurent";
            Laurent.CreateDate = DateTime.Now;

            Jefferson.Name = "Jefferson";
            Jefferson.CreateDate = DateTime.Now;

            lstPerson.Add(Laurent);
            lstPerson.Add(Jefferson);

            return ApiResult<IList<Person.BusinessEntities.Person>>(() =>
            {
                return lstPerson;
            });
        }

        #endregion

    }
}