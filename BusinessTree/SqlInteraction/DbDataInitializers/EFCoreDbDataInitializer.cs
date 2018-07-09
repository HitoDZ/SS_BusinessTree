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

        public void InsertProperties(int minPropAmount,int maxPropAmount)
        {
            var levels = dbContext.Levels;
            Property property;
            foreach(var level in levels)
            {
                int propertiesCount = DataGenerator.GenerateNumber(minPropAmount, maxPropAmount);

                for(int i = 0; i < propertiesCount; i++)
                {
                    property = new Property();
                    property.Name = DataGenerator.GenerateString(DataGeneratingType.Word);
                    property.Level = level;
                    dbContext.Properties.Add(property);
                }
            }
            dbContext.SaveChanges();
        }

        public void InsertPropertyValues(int propertyValuesCount)
        {
            var levels = dbContext.Levels;

            foreach (var level in levels)
            {
                var properties = level.Properties;

                foreach(var property in properties)
                {
                    PropertyValue propertyValue;
                    PropertyValue parent;
                    for(int i = 0; i < propertyValuesCount; i++)
                    {
                        propertyValue = new PropertyValue();
                        propertyValue.Value = DataGenerator.GenerateString(DataGeneratingType.NumberOrRandomSet);
                        propertyValue.Level = level;
                        propertyValue.PropertyValueNavigation = property;
                        if (i != 0 || level.Parent==null)
                        {
                            propertyValue.ParentPropertyValue = propertyValue;
                        }
                    }
                }

                for (int i = 0; i < propertiesCount; i++)
                {
                    property = new Property();
                    property.Name = DataGenerator.GenerateString(DataGeneratingType.Word);
                    property.Level = level;
                }
            }
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
