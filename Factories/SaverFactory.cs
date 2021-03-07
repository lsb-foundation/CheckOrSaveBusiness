using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Models;
using CheckOrSaveBusiness.Savers;

namespace CheckOrSaveBusiness.Factories
{
    public class SaverFactory
    {
        private static readonly Dictionary<string, Type> _savers = new Dictionary<string, Type>();
        static SaverFactory()
        {
            Register();
            RegisterAutomatically();
        }

        public static ISaver GetSaver(string saverName)
        {
            if (_savers.ContainsKey(saverName))
                return Activator.CreateInstance(_savers[saverName]) as ISaver;
            throw new Exception($"Saver {saverName} not found.");
        }

        private static void Register<TSaver>(string saverName) where TSaver : ISaver, new()
        {
            _savers.Add(saverName, typeof(TSaver));
        }

        private static void RegisterAutomatically()
        {
            foreach (Type type in Assembly.GetEntryAssembly().GetTypes())
            {
                if (!type.IsClass) continue;
                if (type.GetInterfaces().Any(t => t == typeof(ISaver)))
                {
                    if (type.GetCustomAttribute<SaverNameAttribute>() is SaverNameAttribute attribute)
                    {
                        if (!_savers.ContainsKey(attribute.Name))
                        {
                            _savers.Add(attribute.Name, type);
                        }
                    }
                }
            }
        }

        private static void Register()
        {
            Register<RouteSaver>("ROUTE");
            Register<MaterialSaver>("MATERIAL");
            Register<FailedSaver>("FAILED");
            Register<NonExecuteSaver>("NONEXECUTE");
        }
    }
}
