using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Models;
using static System.Console;

namespace CheckOrSaveBusiness.Checkers
{
    public class MaterialChecker : IChecker
    {
        public Result Check()
        {
            WriteLine($"MATERIAL check successfully.");
            return Result.Success();
        }

        public void Init(string config)
        {
            WriteLine($"{nameof(MaterialChecker)} initialized: {config}.");
        }
    }
}
