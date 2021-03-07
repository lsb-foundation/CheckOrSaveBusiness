using System;

namespace CheckOrSaveBusiness.Models
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class SaverNameAttribute : Attribute
    {
        public string Name { get; }
        public SaverNameAttribute(string name)
        {
            Name = name;
        }
    }
}
