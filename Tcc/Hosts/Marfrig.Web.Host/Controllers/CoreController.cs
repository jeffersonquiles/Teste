﻿using Tcc.Core.BusinessRulesInterfaces;
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

    }
}