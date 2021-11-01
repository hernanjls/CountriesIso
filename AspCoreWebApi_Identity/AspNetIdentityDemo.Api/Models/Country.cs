using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetIdentityDemo.Api.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string NumericCode { get; set; }
        public int SubRegionsCount { get; set; }

    }
}
