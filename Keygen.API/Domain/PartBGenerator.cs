using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keygen.API.Domain
{
    public static class PartBGenerator
    {
        public static async Task<string> Generate(Id id)
        {
            var firstLetterAsciiCode = (int)Encoding.ASCII.GetBytes(id.Head)[0];
            var seed = (firstLetterAsciiCode + id.Tail) * 1234;

            var newHead = char.ConvertFromUtf32(firstLetterAsciiCode + 1);
            if (!char.IsLetter(newHead[0]))
                newHead = char.ConvertFromUtf32(firstLetterAsciiCode + 1 - 26);

            var newTail = seed.ToString().Substring(0, 3);

            return await Task.Run(() => newHead + newTail);
        }
    }
}
