using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Models;
using static System.Console;

namespace CheckOrSaveBusiness.Checkers
{
    public class NonExecuteChecker : IChecker
    {
        public Result Check()
        {
            WriteLine("NONEXECUTE check successfully.");
            return Result.Success();
        }

        public void Init(string config)
        {
            WriteLine($"{nameof(NonExecuteChecker)} initialized: {config}.");
        }
    }
}
