using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keygen.API.Domain
{
    public class Id
    {
        public string value { get; private set; }

        public Id(string value)
        {
            this.value = value;
        }

        public string Head
        {
            get
            {
                return value.Substring(0, 1);
            }
        }

        public int Tail
        {
            get
            {
                return int.Parse(value.Substring(1, 3));
            }
        }
    }
}
