using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetIdentityDemo.Api.Models
{
    public class SubRegion
    {

        public int SubRegionID { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }

        public int CountryID { get; set; }

    }
}
