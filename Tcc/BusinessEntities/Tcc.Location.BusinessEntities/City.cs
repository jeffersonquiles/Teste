using Tcc.Framework.BusinessEntities;


namespace Tcc.Location.BusinessEntities
{
    public class City : BusinessEntityBase<City>
    {
        public int StateProvinceId { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public StateProvince StateProvince { get; set; }

        public City()
        {

        }
    }
}