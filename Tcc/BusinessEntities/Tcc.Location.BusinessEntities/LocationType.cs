using Tcc.Framework.BusinessEntities;


namespace Tcc.Location.BusinessEntities
{
    public class LocationType : BusinessEntityBase<LocationType>
    {
        public string Name { get; set; }

        public LocationType()
        {

        }
    }
}