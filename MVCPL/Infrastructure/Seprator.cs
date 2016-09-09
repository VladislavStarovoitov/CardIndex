using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Separator
    {
        public static IEnumerable<string> ToTagArray(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return new string[0];
            }
            var stringArray = source.Split(',');
            for (int i = 0; i < stringArray.Length; i++)
            {
                stringArray[i] = stringArray[i].Trim();
            }
            return stringArray.Where(sA => !sA.Any(s => !char.IsLetter(s)) && !sA.Equals(string.Empty));
        }
    }
}
