using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keygen.API.Domain
{
    public class Key
    {
        public string PartA { get; set; }
        public string PartB { get; set; }
        public string PartC { get; set; }

        public override string ToString()
        {
            return PartA + PartB + PartC;
        }
    }
}
