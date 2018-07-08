using System;
using System.Collections.Generic;

namespace SqlInteraction
{
    public partial class PropertyValue
    {
        public PropertyValue()
        {
            InverseParentPropertyValue = new HashSet<PropertyValue>();
        }

        public int PropertyValueId { get; set; }
        public string Value { get; set; }
        public int PropertyId { get; set; }
        public int? ParentPropertyValueId { get; set; }
        public int LevelId { get; set; }

        public Level Level { get; set; }
        public PropertyValue ParentPropertyValue { get; set; }
        public Property PropertyValueNavigation { get; set; }
        public ICollection<PropertyValue> InverseParentPropertyValue { get; set; }
    }
}
