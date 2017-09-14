using Tcc.Framework.Patterns.TranslateEntity;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tcc.Framework.BusinessEntities
{
    [Serializable]
    public abstract class BusinessEntityBase : IDataErrorInfo
    {

        protected HybridDictionary extendedProperties;
        /* Expõe o Hibrid Dictionary ao inves de criar um indexer na classe
         * pois indexer não é serializavel via WCF.
         * */
        public virtual HybridDictionary ExtendedProperties
        {
            get
            {
                if (this.extendedProperties == null)
                    this.extendedProperties = new HybridDictionary();

                return this.extendedProperties;
            }
        }

        /// <summary>
        /// Verifica se é nulo, em branco ou igual a zero.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Formata a mensagem
        /// </summary>
        /// <param name="tag">Tag do objeto de validação</param>
        /// <param name="key">Key do objeto validado</param>
        /// <param name="message">Mensagem do erro</param>
        /// <returns></returns>
        public ValidationResult formatMessage(string tag, string key, string message)
        {
            return new ValidationResult(
                message: message,
                target: this,
                key: key,
                tag: tag,
                validator: null
            );
        }

        public ValidationResults GetErrors<TValidation>()
        {
            Validator<TValidation> validator = ValidationFactory.CreateValidator<TValidation>();
            return validator.Validate(this);
        }

        public string GetMessageErrors<TValidation>()
        {
            Validator<TValidation> validator = ValidationFactory.CreateValidator<TValidation>();
            ValidationResults results = validator.Validate(this);
            if (!results.IsValid)
            {
                StringBuilder builder = new StringBuilder();
                foreach (ValidationResult result in results)
                {
                    builder.AppendLine(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            "{0}: {1}",
                            result.Tag,
                            result.Message));
                }

                return builder.ToString();
            }

            return string.Empty;
        }

        #region IDataErrorInfo Members

        /// <summary>
        /// Retorna os problemas de validação do objeto
        /// </summary>
        [EntityTranslator(false)]
        public abstract string Error
        {
            get;
        }

        /// <summary>
        /// Verificação da mensagem de validação para uma determinada propriedade
        /// </summary>
        /// <param name="columnName">Nome da propriedade</param>
        /// <returns>Retorna vazio quando não há problemas, caso contrário retorna a descrição do problema de validação</returns>
        [EntityTranslator(false)]
        public abstract string this[string propertyName]
        {
            get;
        }

        #endregion
    }

    [Serializable]
    public abstract class BusinessEntityBase<T> : BusinessEntityBase
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CreateByPersonId { get; set; }
        public int UpdateByPersonId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual void CopyTo(BusinessEntityBase<T> businessEntity)
        {
            StringCollection stringCollection = new StringCollection();

            DictionaryEntry[] dictoryArray = new DictionaryEntry[this.ExtendedProperties.Count];



            this.ExtendedProperties.CopyTo(dictoryArray, 0);

            foreach (DictionaryEntry dic in dictoryArray)
            {
                if (businessEntity.ExtendedProperties.Contains(dic.Key))
                {
                    businessEntity.ExtendedProperties.Remove(dic.Key);
                }

                businessEntity.ExtendedProperties.Add(dic.Key, dic.Value);

                stringCollection.Add(Convert.ToString(dic.Key));
            }

        }


        public virtual T ToDerived<T>() where T : new()
        {
            T tDerived = new T();
            foreach (PropertyInfo propBase in this.GetType().GetProperties())
            {
                try
                {
                    PropertyInfo propDerived = typeof(T).GetProperty(propBase.Name);
                    propDerived.SetValue(tDerived, propBase.GetValue(this, null), null);
                }
                catch (Exception)
                {
                }
            }
            return tDerived;
        }



        #region IDataErrorInfo Members

        /// <summary>
        /// Retorna os problemas de validação do objeto
        /// </summary>
        [EntityTranslator(false)]
        public override string Error
        {
            get
            {
                Validator<T> validator = ValidationFactory.CreateValidator<T>();
                ValidationResults results = validator.Validate(this);
                if (!results.IsValid)
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (ValidationResult result in results)
                    {
                        builder.AppendLine(
                            string.Format(
                                CultureInfo.CurrentCulture,
                                "{0}: {1}",
                                result.Tag,
                                result.Message));
                    }

                    return builder.ToString();
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Verificação da mensagem de validação para uma determinada propriedade
        /// </summary>
        /// <param name="columnName">Nome da propriedade</param>
        /// <returns>Retorna vazio quando não há problemas, caso contrário retorna a descrição do problema de validação</returns>
        [EntityTranslator(false)]
        public override string this[string propertyName]
        {
            get
            {
                Validator<T> validator = ValidationFactory.CreateValidator<T>();
                ValidationResults results = validator.Validate(this);

                foreach (ValidationResult result in results)
                {
                    if (!String.IsNullOrEmpty(result.Key))
                    {
                        if (result.Key.Equals(propertyName))
                        {
                            return result.Message;
                        }
                    }
                }
                return string.Empty;
            }
        }

        #endregion
    }
}
