using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Separator
    {
        public static string[] ToTagArray(this string source)
        {
            var stringArray = source.Split(',');
            for (int i = 0; i < stringArray.Length; i++)
            {
                stringArray[i] = stringArray[i].Trim();
            }
            return stringArray;
        }
    }
}
