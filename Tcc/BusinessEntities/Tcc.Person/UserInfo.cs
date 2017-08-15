using Tcc.Framework.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Person.BusinessEntities
{
    [HasSelfValidation]
    public class UserInfo : BusinessEntityBase<UserInfo>
    {
        public int PersonId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Username { get; set; }
        public Person Person { get; set; }

        public UserInfo()
        {

        }

        #region Validation
        [SelfValidation]
        public void Validate(ValidationResults results)
        {
            if(PersonId <= 0)
            {
                results.AddResult(new ValidationResult("Selecione a pessoa.", null, "PersonId", "UserInfo", null));
            }
            if (string.IsNullOrEmpty(Password))
            {
                results.AddResult(new ValidationResult("Informe a senha.", null, "Password", "UserInfo", null));
            }
            if (string.IsNullOrEmpty(ConfirmPassword))
            {
                results.AddResult(new ValidationResult("Informe a senha.", null, "ConfirmPassword", "UserInfo", null));
            } else if (ConfirmPassword != Password)
            {
                results.AddResult(new ValidationResult("As senhas não conferem.", null, "ConfirmPassword", "UserInfo", null));
            }
            if (string.IsNullOrEmpty(Username))
            {
                results.AddResult(new ValidationResult("Informe o login.", null, "Username", "UserInfo", null));
            }


        }
        #endregion
    }
}
