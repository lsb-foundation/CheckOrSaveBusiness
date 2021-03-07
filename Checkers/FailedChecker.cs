using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Models;
using static System.Console;

namespace CheckOrSaveBusiness.Checkers
{
    public class FailedChecker : IChecker
    {
        public Result Check()
        {
            WriteLine("FAILED check failed.");
            return Result.Error("FAILED check failed.");
        }

        public void Init(string config)
        {
            WriteLine($"{nameof(FailedChecker)} initialized: {config}.");
        }
    }
}
