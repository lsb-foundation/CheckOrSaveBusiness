using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Models;
using static System.Console;

namespace CheckOrSaveBusiness.Checkers
{
    public class RouteChecker : IChecker
    {
        public void Init(string config)
        {
            WriteLine($"{nameof(RouteChecker)} initialized: {config}.");
        }

        public Result Check()
        {
            WriteLine("ROUTE check successfully.");
            return Result.Success();
        }
    }
}
