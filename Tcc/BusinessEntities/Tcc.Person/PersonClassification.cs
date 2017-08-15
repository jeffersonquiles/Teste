using Tcc.Framework.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Core.BusinessEntities;

namespace Tcc.Person.BusinessEntities
{
    [HasSelfValidation]
    public class PersonClassification: BusinessEntityBase<PersonClassification>
    {
        public int PersonId { get; set; }
        public int ClassificationTypeId { get; set; }
        public Person Person { get; set; }
        public ClassificationType ClassificationType { get; set; }

        public PersonClassification()
        {

        }

        #region Validation
        [SelfValidation]
        public void Validate(ValidationResults results)
        {
            if (PersonId <= 0)
            {
                results.AddResult(new ValidationResult("Selecione a pessoa.", null, "PersonId", "PersonClassification", null));
            }
            if (ClassificationTypeId <= 0)
            {
                results.AddResult(new ValidationResult("Selecione a classificação.", null, "PersonId", "ClassificationTypeId", null));
            }

        }
        #endregion
    }
}
