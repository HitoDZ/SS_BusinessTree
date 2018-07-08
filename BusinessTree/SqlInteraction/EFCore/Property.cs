using System;
using System.Collections.Generic;

namespace SqlInteraction
{
    public partial class Property
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public int LevelId { get; set; }

        public Level Level { get; set; }
        public PropertyValue PropertyValue { get; set; }
    }
}
