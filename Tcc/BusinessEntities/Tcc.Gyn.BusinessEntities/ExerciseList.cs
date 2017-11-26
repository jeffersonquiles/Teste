
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Common;
using Tcc.Person.BusinessEntities;

namespace Tcc.Gyn.BusinessEntities
{

    public class ExerciseList: BusinessEntityBase <ExerciseList>
    {
        public int PersonId { get; set; }
        public int GynId { get; set; }
        public int CoachId { get; set; }
        public IList<Exercise> Exercises { get; set; }
        public Tcc.Person.BusinessEntities.Person Person { get; set; }
        public Gyn Gyn { get; set; }
        public Tcc.Person.BusinessEntities.Person Coach { get; set; }


        public ExerciseList()
        {

        }

        //#region Validation
        //[SelfValidation]
        //public void Validate(ValidationResults results)
        //{
        //    if (PersonId <= 0)
        //    {
        //        results.AddResult(new ValidationResult("Selecione a pessoa.", null, "PersonId", "ExerciseList", null));
        //    }
        //    if (GynId <= 0)
        //    {
        //        results.AddResult(new ValidationResult("Selecione a acadêmia.", null, "GynId", "ExerciseList", null));
        //    }
        //    if(CoachId <= 0)
        //    {
        //        results.AddResult(new ValidationResult("Selecione o professor.", null, "CoachId", "ExerciseList", null));
        //    }

        //}
        //#endregion
    }
}
