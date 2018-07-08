using System;
using SqlInteraction.DbDataInitializers;
using SqlInteraction;

namespace TestInsertingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            SS2018Context context = new SS2018Context();
            var levels = context.Levels;
            foreach(var level in levels)
            {
                
                foreach(var parent in level.InverseParent)
                {
                    Console.WriteLine(level.Name + " " + parent?.Name);
                }
            }
        }
    }
}
