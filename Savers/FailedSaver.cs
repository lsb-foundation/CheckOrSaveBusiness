using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Models;
using static System.Console;

namespace CheckOrSaveBusiness.Savers
{
    public class FailedSaver : ISaver
    {
        public void Init(string config)
        {
            WriteLine($"{nameof(FailedSaver)} initialized: {config}.");
        }

        public Result Save()
        {
            WriteLine("FAILED save failed.");
            return Result.Error("FAILED save failed.");
        }
    }
}
