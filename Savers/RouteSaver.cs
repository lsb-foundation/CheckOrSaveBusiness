using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Models;
using static System.Console;

namespace CheckOrSaveBusiness.Savers
{
    public class RouteSaver : ISaver
    {
        public void Init(string config)
        {
            WriteLine($"{nameof(RouteSaver)} initialized: {config}.");
        }

        public Result Save()
        {
            WriteLine("ROUTE save successfully.");
            return Result.Success();
        }
    }
}
