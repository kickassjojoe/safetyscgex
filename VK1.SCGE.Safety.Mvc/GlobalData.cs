using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models;

namespace VK1.SCGE.Safety.Mvc {
    public static class GlobalData {
        public static string LoginUserName { get; set; }
        public static string UserName { get; set; }
        //public static IEnumerable<InvestigateCard> InvestigateCards { get; set; }

        public static DateTime DayMontYearToYearMonthDay(string value) {
            var day = value.Substring(0, 2);
            var month = value.Substring(3, 2);
            var year = value.Substring(6, 4);
            var fulldate = $"{year}-{month}-{day}";

            return Convert.ToDateTime(fulldate);
        }

        public static string[] SeparateWord(string words, int length) {
            
            if (String.IsNullOrWhiteSpace(words)) return null;

            var arr = Math.Ceiling(words.Length / (double)length);
            var start = 0;
            var totalLength = words.Length;

            string[] result = new string[(int)arr];

            for (int i = 0; i < result.Length; i++) {
                if (words.Length <= length) {
                    result[0] = words;
                    return result;
                }

                if (totalLength <= length) length = totalLength;

                var letter = words.Substring(start, length);

                result[i] = letter;

                totalLength -= length;
                start += length;
            }
            return result;
        }
    }
}
