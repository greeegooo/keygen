using Keygen.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keygen.API.Dto
{
    public class GenerateKeyResponse
    {
        public string Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
