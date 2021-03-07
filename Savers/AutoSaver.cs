using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Models;
using static System.Console;

namespace CheckOrSaveBusiness.Savers
{
    [SaverName("AUTO")]
    public class AutoSaver : ISaver
    {
        public void Init(string config)
        {
            WriteLine($"{nameof(AutoSaver)} initialized: {config}.");
        }

        public Result Save()
        {
            WriteLine("AUTO save successfully.");
            return Result.Success();
        }
    }
}
