using System.Text;
using System.Threading.Tasks;

namespace Keygen.API.Domain
{
    public static class PartAGenerator
    {
        public static async Task<string> Generate(Id id)
        {
            var firstLetterAsciiCode = (int)Encoding.ASCII.GetBytes(id.Head)[0];
            var seed = firstLetterAsciiCode * id.Tail;

            var newHead = char.ConvertFromUtf32(firstLetterAsciiCode + 3);
            if(!char.IsLetter(newHead[0]))
                newHead = char.ConvertFromUtf32(firstLetterAsciiCode + 3 - 26);

            var newTail = seed.ToString().Substring(0, 3);

            return await Task.Run(() => newHead + newTail);
        }
    }
}
