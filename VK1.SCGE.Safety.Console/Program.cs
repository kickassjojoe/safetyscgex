using System;

namespace VK1.SCGE.Safety.Console {
    class Program {
        static void Main(string[] args) {
            string words = "asdfjsfjdslkajrioaslkfjals;fdjakldfja;lfjb";
            var length = 4;
            var result = SeparateWord(words, length);
            for (int i = 0; i < result.Length; i++) {
                System.Console.WriteLine(result[i]);
            }
        }

        private static string[] SeparateWord(string words, int length) {
            var arr = Math.Ceiling(words.Length / 4.0);
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
