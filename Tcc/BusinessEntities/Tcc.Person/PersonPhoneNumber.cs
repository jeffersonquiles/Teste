using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Common;
using Tcc.Core.BusinessEntities;

namespace Tcc.Person.BusinessEntities
{
    [HasSelfValidation]
    public class PersonPhoneNumber : BusinessEntityBase<PersonPhoneNumber>
    {
        public int PersonId { get; set; }
        public int PhoneProviderId { get; set; }
        public int PhoneNumberTypeId { get; set; }
        public int LocationId { get; set; }
        public string Number { get; set; }
        public bool IsMain { get; set; }
        public string Description { get; set; }
        public PhoneProvider PhoneProvider { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
        public Tcc.Location.BusinessEntities.Location Location { get; set; }

        public PersonPhoneNumber()
        {

        }

        #region Validation
        [SelfValidation]
        public void Validate(ValidationResults results)
        {
            if (PersonId <= 0)
            {
                results.AddResult(new ValidationResult("Selecione a pessoa.", null, "PersonId", "PersonPhoneNumber", null));
            }
            if (PhoneProviderId <= 0)
            {
                results.AddResult(new ValidationResult("Selecione a operadora.", null, "PhoneProviderId", "PersonPhoneNumber", null));
            }
            if (PhoneNumberTypeId <= 0)
            {
                results.AddResult(new ValidationResult("Selecione o tipo de telefone.", null, "PhoneNumberTypeId", "PersonPhoneNumber", null));
            }
            if (LocationId <= 0)
            {
                results.AddResult(new ValidationResult("Selecione o endereço.", null, "LocationId", "PersonPhoneNumber", null));
            }
            if (string.IsNullOrEmpty(Number))
            {
                results.AddResult(new ValidationResult("Informe o número do telefone.", null, "Number", "PersonPhoneNumber", null));
            }

        }
        #endregion
    }
}
