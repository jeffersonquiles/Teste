

namespace Tcc.Location.BusinessEntities
{
    public class City 
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