using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Libraries.Text {
    public static class StringExtension {

        public static IEnumerable<int> AllIndexesOf(this string str, string searchstring) {
            int minIndex = str.IndexOf(searchstring);
            while (minIndex != -1) {
                yield return minIndex;
                minIndex = str.IndexOf(searchstring, minIndex + searchstring.Length);
            }
        }

    }
}
