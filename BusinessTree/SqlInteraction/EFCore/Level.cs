using System;
using System.Collections.Generic;

namespace SqlInteraction
{
    public partial class Level
    {
        public Level()
        {
            InverseParent = new HashSet<Level>();
            Properties = new HashSet<Property>();
            PropertyValues = new HashSet<PropertyValue>();
        }

        public int LevelId { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public Level Parent { get; set; }
        public ICollection<Level> InverseParent { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<PropertyValue> PropertyValues { get; set; }
    }
}
