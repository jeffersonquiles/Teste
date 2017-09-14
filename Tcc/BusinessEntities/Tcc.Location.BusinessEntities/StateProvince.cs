using Tcc.Framework.BusinessEntities;


namespace Tcc.Location.BusinessEntities
{
    public class StateProvince 
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Region { get; set; }
        public Country Country { get; set; }

        public StateProvince()
        {

        }
    }
}
