using System;
using System.Collections.Generic;
using System.Text;

namespace SqlInteraction.DbDataInitializers
{
    public class EFCoreDbDataInitializer
    {
        private SS2018Context dbContext;
        public EFCoreDbDataInitializer(SS2018Context context)
        {
            dbContext = context;
        }

        public void InsertLevels(int majorLevelsAmount, int childLevelsAmount,int nestingPow)
        {
            Level parent;
            for (int i = 0; i < majorLevelsAmount; i++)
            {
                parent = initializeLevel();
                dbContext.Levels.Add(parent);
                recursivelyInitialize(parent, childLevelsAmount, --nestingPow);
            }
            dbContext.SaveChanges();
        }

        private void recursivelyInitialize(Level parent,int levelsAmount, int nestingPow)
        {
            Level current;
            for (int i = 0; i < levelsAmount; i++)
            {
                current = initializeLevel();
                current.Parent = parent;
                dbContext.Levels.Add(current);
                if (nestingPow != 0)
                {
                    int currNestingPow = nestingPow - 1;
                    recursivelyInitialize(current, levelsAmount, currNestingPow);
                }
            }
        }

        private Level initializeLevel()
        {
            Level level = new Level();
            level.Name = DataGenerator.GenerateString(DataGeneratingType.Word);
            //level.LevelId = DataGenerator.GenerateNumber();
            return level;
        }
    }
}
