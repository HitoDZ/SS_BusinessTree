using System;
using System.Collections.Generic;
using System.Text;

namespace SqlInteraction
{
    public static class DataGenerator
    {
        private static Random random = new Random();
        private static char[] symbols= "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

        public static Int32 GenerateNumber(Int32 maxValue = Int32.MaxValue)
        {
            return random.Next(maxValue);
        }

        public static string GenerateString()
        {
            StringBuilder builder = new StringBuilder();

            int length = random.Next(5, 15);

            for (int j = 0; j < length; j++)
            {
                int index = random.Next(0, symbols.Length - 1);

                builder.Append(symbols[index]);
            }

            return builder.ToString();
        }
    }
}
