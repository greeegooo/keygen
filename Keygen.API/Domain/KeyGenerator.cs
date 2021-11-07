using Keygen.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keygen.API.Domain
{
    public static class KeyGenerator
    {
        public static string Generate(GenerateKeyRequest request)
        {
            string value = request.Id;

            Validate(value);

            var id = new Id(value);

            var a = PartAGenerator.Generate(id);
            var b = PartBGenerator.Generate(id);
            var c = PartCGenerator.Generate(id);

            Task.WaitAll(a, b, c);

            var key = new Key
            {
                PartA = a.Result,
                PartB = b.Result,
                PartC = c.Result
            };

            return key.ToString();
        }

        private static void Validate(string id)
        {
            var isNullOrEmpty = string.IsNullOrEmpty(id);

            if (isNullOrEmpty)
                throw new Exception("ID is required.");

            var lengthIsNot4 = id.Length != 4;
            var headIsNotLetter = !id.Substring(0, 1).All(char.IsLetter);
            var tailAreNotDigits = !id.Substring(1, 3).All(char.IsDigit);

            if(lengthIsNot4 || headIsNotLetter || tailAreNotDigits)
                throw new Exception("ID does not complain one or more of the following: Length equals 4. First char a letter. Last chars digits.");
        }
    }
}
