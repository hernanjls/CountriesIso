using System;
using System.Collections.Generic;
using System.Text;

namespace CountryAppISO3166.Models
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
