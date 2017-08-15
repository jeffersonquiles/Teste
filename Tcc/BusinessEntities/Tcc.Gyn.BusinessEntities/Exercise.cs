using Tcc.Framework.BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Core.BusinessEntities;

namespace Tcc.Gyn.BusinessEntities
{
    [HasSelfValidation]
    public class Exercise: BusinessEntityBase<Exercise>
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int LevelId { get; set; }
        public int ExerciseListId { get; set; }
        public string VideoUrl { get; set; }
        public int BodyPartId { get; set; }
        public int Series { get; set; }
        public int Repeats { get; set; }
        public TimeSpan RestTime { get; set; } 
        public Category Category { get; set; }
        public Level Level { get; set; }
        public BodyPart BodyPart { get; set; }


        public Exercise()
        {

        }

        #region Validation
        [SelfValidation]
        public void Validate(ValidationResults results)
        {
            if (string.IsNullOrEmpty(Name))
            {
                results.AddResult(new ValidationResult("Informe o nome do exercício.", null, "Name", "Exercise", null));
            }
            if (CategoryId <= 0)
            {
                results.AddResult(new ValidationResult("Selecione a categoria do exercício.", null, "CategoryId", "Exercise", null));
            }
            if (LevelId <= 0)
            {
                results.AddResult(new ValidationResult("Selecione o level do exercício.", null, "LevelId", "Exercise", null));
            }
            if (BodyPartId <= 0)
            {
                results.AddResult(new ValidationResult("Selecione a parte do corpo.", null, "BodyPartId", "Exercise", null));
            }
            if (Repeats <= 0)
            {
                results.AddResult(new ValidationResult("Informe a quantidade de repetições.", null, "Repeats", "Exercise", null));
            }
            if (Series <= 0)
            {
                results.AddResult(new ValidationResult("Informe a quantidade de séries.", null, "Series", "Exercise", null));
            }
            

        }
        #endregion
    }
}
