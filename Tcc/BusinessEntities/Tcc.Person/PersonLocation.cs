using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcc.Location.BusinessEntities;

namespace Tcc.Person.BusinessEntities
{
    public class PersonLocation
    {
        public int PersonId { get; set; }
        public int LocationId { get; set; }
        public Person Person { get; set; }
        public Tcc.Location.BusinessEntities.Location Location { get; set; }

        public PersonLocation()
        {

        }
    }
}
