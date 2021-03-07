using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Models;
using static System.Console;

namespace CheckOrSaveBusiness.Checkers
{
    [CheckerName("AUTO")]
    public class AutoChecker : IChecker
    {
        public Result Check()
        {
            WriteLine("AUTO check successfully.");
            return Result.Success();
        }

        public void Init(string config)
        {
            WriteLine($"{nameof(AutoChecker)} initialized: {config}.");
        }
    }
}
