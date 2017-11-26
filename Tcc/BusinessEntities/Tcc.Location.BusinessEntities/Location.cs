
using System;
using Tcc.Common;

namespace Tcc.Location.BusinessEntities
{

    public class Location : BusinessEntityBase<Location>
    {
        public int LocationTypeId { get; set; }
        public int StateProvinceId { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string ZipCode { get; set; }
        public string AddressName { get; set; }
        public string Neighborhood { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string ReferencePoint { get; set; }
        public string AdditionalInformation { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public LocationType LocationType { get; set; }
        public StateProvince StateProvince { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }
       
        public Location()
        {

        }
    }


        //#region Validation
        //[SelfValidation]
        //public void Validate(ValidationResults results)
        //{
        //    if (LocationTypeId <= 0)
        //    {
        //        results.AddResult(new ValidationResult("Selecione o tipo de localização.", null, "LocationTypeId", "Location", null));
        //    }
        //    if (StateProvinceId <= 0)
        //    {
        //        results.AddResult(new ValidationResult("Selecione o estado.", null, "StateProvinceId", "Location", null));
        //    }
        //    if (CityId <= 0)
        //    {
        //        results.AddResult(new ValidationResult("Selecione a cidade.", null, "CityId", "Location", null));
        //    }
        //    if (string.IsNullOrEmpty(AddressName))
        //    {
        //        results.AddResult(new ValidationResult("Informe o endereço.", null, "AddressName", "Location", null));
        //    }
        //    if (this.Number <= 0)
        //    {
        //        results.AddResult(new ValidationResult("Informe o número da residência.", null, "Number", "Location", null));
        //    }

        //}
}