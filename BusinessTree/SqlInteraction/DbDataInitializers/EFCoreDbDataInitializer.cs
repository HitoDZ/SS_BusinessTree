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
                recursivelyInitialize(parent, childLevelsAmount, nestingPow);
            }
        }

        private void recursivelyInitialize(Level parent,int levelsAmount, int nestingPow)
        {
            for (int i = 0; i < levelsAmount; i++)
            {
                Level current = initializeLevel();
                current.Parent = parent;
                if (nestingPow != 0)
                {
                    recursivelyInitialize(current, levelsAmount, nestingPow--);
                }
            }
        }

        private Level initializeLevel()
        {
            Level level = new Level();
            level.Name = DataGenerator.GenerateString(DataGeneratingType.Word);
            return level;
        }
    }
}
