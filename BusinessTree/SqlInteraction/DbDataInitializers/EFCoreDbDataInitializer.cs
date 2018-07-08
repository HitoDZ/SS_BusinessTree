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
            for(int i = 0; i < majorLevelsAmount; i++)
            {
                for(int j = 0; j < nestingPow; j++)
                {

                }
            }
        }
    }
}
