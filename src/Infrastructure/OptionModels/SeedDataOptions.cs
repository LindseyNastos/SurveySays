using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.OptionModels
{
    public class SeedDataOptions
    {
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string SampleUserEmail { get; set; }
        public string SampleUserPassword { get; set; }
    }
}
