using System;
using System.Collections.Generic;
using System.Text;

namespace SqlInteraction
{
    public enum DataGeneratingType
    {
        RandomSet,
        Word,
        NumberOrRandomSet
    }
    public static class DataGenerator
    {
        private static Random random = new Random();
        private static char[] symbols = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
        private static Lazy<List<string>> words = new Lazy<List<string>>(() =>
        {
            return new List<string>()
            {
                "car",
                "department",
                "bid",
                "branch",
                "driver",
                "worker",
                "road",
                "core",
                "dependency",
                "level",
                "random",
                "generator",
                "business",
                "object",
                "scale",
                "lightbulb",
                "card",
                "bank",
                "street",
                "city",
                "country",
                "house",
                "bridge",
                "wall"
            };
        });

        public static Int32 GenerateNumber(Int32 maxValue = Int32.MaxValue)
        {
            return random.Next(maxValue);
        }

        public static string GenerateString(DataGeneratingType type)
        {
            switch (type)
            {
                case DataGeneratingType.RandomSet:
                    return generateRandom();
                case DataGeneratingType.Word:
                    return generateWord();
                case DataGeneratingType.NumberOrRandomSet:
                    return generateNumOrRandSet();
                default:
                    return generateRandom();
            }
            
        }

        private static string generateNumOrRandSet()
        {
            if (random.Next() % 2 == 1)
            {
                return GenerateNumber().ToString();
            }
            else
            {
                return generateRandom();
            }
        }

        private static string generateWord()
        {
            int index = random.Next(0, words.Value.Count - 1);
            return words.Value[index];
        }

        private static string generateRandom()
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
