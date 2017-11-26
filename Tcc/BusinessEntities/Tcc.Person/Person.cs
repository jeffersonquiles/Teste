using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Common;

namespace Tcc.Person.BusinessEntities
{
    //[HasSelfValidation]
    public class Person : BusinessEntityBase<Person>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Entity { get; set; }
        public string Facebook { get; set; }
        public bool Gender { get; set; }
        public DateTime? BirthDay { get; set; }


        public Person()
        {

        }

        //#region Validation
        //[SelfValidation]
        //public void Validate(ValidationResults results)
        //{
        //    if (string.IsNullOrEmpty(Name))
        //    {
        //        results.AddResult(new ValidationResult("Informe o nome.", null, "Name", "Person", null));
        //    }
        //    if (string.IsNullOrEmpty(Gender))
        //    {
        //        results.AddResult(new ValidationResult("Informe o sexo.", null, "Gender", "Person", null));
        //    }
        //    if (string.IsNullOrEmpty(Email))
        //    {
        //        results.AddResult(new ValidationResult("Informe o email.", null, "Gender", "Person", null));
        //    }
        //    if (BirtyDay == null)
        //    {
        //        results.AddResult(new ValidationResult("Informe a data de nascimento.", null, "BirtyDay", "Person", null));
        //    }

        //}
        //#endregion
    }
}
