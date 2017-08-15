using Tcc.Gyn.BusinessRulesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Tcc.Common;
using Tcc.Gyn.BusinessEntities;

namespace Tcc.Web.Host.Controllers
{
    public class GynController : ApiControllerBase
    {
        #region Constructor 

        private IGynBusinessRules GynBusinessRules { get; set; }

        public GynController(IGynBusinessRules gynBusinessRules)
        {
            GynBusinessRules = gynBusinessRules;
        }

        #endregion

        #region Gyns

        [HttpPost]
        public IHttpActionResult GetGyns()
        {
            return ApiResult<IList<Tcc.Gyn.BusinessEntities.Gyn>>(() =>
            {
                return GynBusinessRules.GetGyns();
            });
        }

        #endregion

        #region ExerciseList

        [HttpPost]
        public IHttpActionResult GetExerciseList([FromBody] int ExerciseListId)
        {
            return ApiResult<IList<ExerciseList>>(() =>
            {
                return GynBusinessRules.GetExerciseList(ExerciseListId);
            });
        }

        public IHttpActionResult DeleteExerciseList([FromBody] Guid UniqueId)
        {
            return ApiResult<bool>(() =>
            {
                return GynBusinessRules.DeleteExerciseList(UniqueId);
            });
        }

        public IHttpActionResult SaveExerciseList(ExerciseList entity)
        {
            return ApiResult<bool>(() =>
            {
                return GynBusinessRules.SaveExerciseList(entity);
            });
        }


        #endregion

    }
}