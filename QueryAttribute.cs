using System;
using System.Collections.Generic;
using System.Text;

namespace Modsi.QueryAttribute
{
    [AttributeUsage(AttributeTargets.All)]
    public class QueryAttribute : Attribute
    {
        public string Name;
        public string NullValue;
        public bool Required;

        public QueryAttribute(string Name, bool Required, string NullValue = null)
        {
            this.NullValue = NullValue;
            this.Required = Required;
            this.Name = Name;
        }
    }
}
