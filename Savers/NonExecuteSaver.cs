using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Models;
using static System.Console;

namespace CheckOrSaveBusiness.Savers
{
    public class NonExecuteSaver : ISaver
    {
        public void Init(string config)
        {
            WriteLine($"{nameof(NonExecuteSaver)} initialized: {config}.");
        }

        public Result Save()
        {
            WriteLine("NONEXECUTE save successfully.");
            return Result.Success();
        }
    }
}
