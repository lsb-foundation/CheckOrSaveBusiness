using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CheckOrSaveBusiness.Checkers;
using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Models;

namespace CheckOrSaveBusiness.Factories
{
    public class CheckerFactory
    {
        private readonly static Dictionary<string, Type> _checkers = new Dictionary<string, Type>();
        static CheckerFactory()
        {
            Register();
            RegisterAutomatically();
        }

        public static IChecker GetChecker(string checkerName)
        {
            if (_checkers.ContainsKey(checkerName))
                return Activator.CreateInstance(_checkers[checkerName]) as IChecker;
            throw new Exception($"Checker {checkerName} not found.");
        }

        private static void Register<TChecker>(string checkerName) where TChecker : IChecker, new()
        {
            _checkers.Add(checkerName, typeof(TChecker));
        }

        private static void RegisterAutomatically()
        {
            foreach (Type type in Assembly.GetEntryAssembly().GetTypes())
            {
                if (!type.IsClass) continue;
                if (type.GetInterfaces().Any(t => t == typeof(IChecker)))
                {
                    if (type.GetCustomAttribute<CheckerNameAttribute>() is CheckerNameAttribute attribute)
                    {
                        if (!_checkers.ContainsKey(attribute.Name))
                        {
                            _checkers.Add(attribute.Name, type);
                        }
                    }
                }
            }
        }

        private static void Register()
        {
            Register<RouteChecker>("ROUTE");
            Register<MaterialChecker>("MATERIAL");
            Register<FailedChecker>("FAILED");
            Register<NonExecuteChecker>("NONEXECUTE");
        }
    }
}
