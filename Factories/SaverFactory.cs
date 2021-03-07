using System;
using System.Collections.Generic;
using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Savers;

namespace CheckOrSaveBusiness.Factories
{
    public class SaverFactory
    {
        private static readonly Dictionary<string, Type> _savers = new Dictionary<string, Type>();
        static SaverFactory()
        {
            Register();
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

        private static void Register()
        {
            Register<RouteSaver>("ROUTE");
            Register<MaterialSaver>("MATERIAL");
            Register<FailedSaver>("FAILED");
            Register<NonExecuteSaver>("NONEXECUTE");
        }
    }
}
