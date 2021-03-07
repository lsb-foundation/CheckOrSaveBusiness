using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Models;
using static System.Console;

namespace CheckOrSaveBusiness.Savers
{
    public class MaterialSaver : ISaver
    {
        public void Init(string config)
        {
            WriteLine($"{nameof(MaterialSaver)} initialized: {config}.");
        }

        public Result Save()
        {
            WriteLine("MATERIAL save successfully.");
            return Result.Success();
        }
    }
}
