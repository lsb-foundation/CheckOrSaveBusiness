using System;

namespace CheckOrSaveBusiness.Models
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class CheckerNameAttribute : Attribute
    {
        public string Name { get; }
        public CheckerNameAttribute(string name)
        {
            Name = name;
        }
    }
}
