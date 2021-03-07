using System;
using System.Collections.Generic;
using CheckOrSaveBusiness.Checkers;
using CheckOrSaveBusiness.Interfaces;

namespace CheckOrSaveBusiness.Factories
{
    public class CheckerFactory
    {
        private readonly static Dictionary<string, Type> _checkers = new Dictionary<string, Type>();
        static CheckerFactory()
        {
            Register();
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

        private static void Register()
        {
            Register<RouteChecker>("ROUTE");
            Register<MaterialChecker>("MATERIAL");
            Register<FailedChecker>("FAILED");
            Register<NonExecuteChecker>("NONEXECUTE");
        }
    }
}
