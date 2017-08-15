using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Exceptions
{
    public class CommonValidationException : System.Exception
    {
        public List<ValidationResult> validationResults { get; set; }

        public List<String> GetMessageValidations() {
            List<String> retorno = new List<string>();
            foreach(var validation in validationResults)
            {
                retorno.Add(validation.Message);
            }

            return retorno;
        }
        public CommonValidationException(string message) : base(message) { }
        public CommonValidationException() : base() { }

        public CommonValidationException(List<ValidationResult> results)
            : base()
        {
            validationResults = results;
        }
    }
}
