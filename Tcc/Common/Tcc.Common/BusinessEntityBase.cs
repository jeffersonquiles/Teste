using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Common
{
    public abstract class BusinessEntityBase
    {
        public virtual bool IsNullOrEmptyOrEqualZero(object obj)
        {
            bool result = false;

            if (obj is int)
            {
                result = String.IsNullOrEmpty(Convert.ToString(obj)) || (int)obj == 0;
            }
            else if (obj is double)
            {
                result = String.IsNullOrEmpty(Convert.ToString(obj)) || (double)obj == 0;
            }
            else if (obj is decimal)
            {
                result = String.IsNullOrEmpty(Convert.ToString(obj)) || (decimal)obj == 0;
            }
            else if (obj is string)
            {
                result = String.IsNullOrEmpty((String)obj);
            }
            else if (obj is DateTime)
            {
                result = Convert.ToDateTime(obj) == DateTime.MinValue;
            }
            else
            {
                if (obj == null)
                    result = true;
            }
            return result;
        }

        //public ValidationResult formatMessage(string tag, string key, string message)
        //{
        //    return new ValidationResult(
        //        message: message,
        //        target: this,
        //        key: key,
        //        tag: tag,
        //        validator: null
        //    );
        //}

        //public ValidationResults GetErrors<TValidation>()
        //{
        //    Validator<TValidation> validator = ValidationFactory.CreateValidator<TValidation>();
        //    return validator.Validate(this);
        //}

        //public string GetMessageErrors<TValidation>()
        //{
        //    Validator<TValidation> validator = ValidationFactory.CreateValidator<TValidation>();
        //    ValidationResults results = validator.Validate(this);
        //    if (!results.IsValid)
        //    {
        //        StringBuilder builder = new StringBuilder();
        //        foreach (ValidationResult result in results)
        //        {
        //            builder.AppendLine(
        //                string.Format(
        //                    CultureInfo.CurrentCulture,
        //                    "{0}: {1}",
        //                    result.Tag,
        //                    result.Message));
        //        }

        //        return builder.ToString();
        //    }

        //    return string.Empty;
        //}
    }

    public abstract class BusinessEntityBase<T>  : BusinessEntityBase
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CreateByPersonId { get; set; }
        public int UpdateByPersonId { get; set; }
        public bool IsDeleted { get; set; }
    }

}
