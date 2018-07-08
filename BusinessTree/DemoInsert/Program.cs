using SqlInteraction;
using System;
using SqlInteraction.DbDataInitializers;

namespace DemoInsert
{
    class Program
    {
        static void Main(string[] args)
        {
            SS2018Context context = new SS2018Context();
            EFCoreDbDataInitializer initializer = new EFCoreDbDataInitializer(context);

            initializer.InsertLevels(1,2,2);

            var levels = context.Levels;
            foreach (var level in levels)
            {
                Console.WriteLine(level.Name + " " + level.Parent?.Name);
            }
        }
    }
}
