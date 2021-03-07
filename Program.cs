using static System.Console;
using CheckOrSaveBusiness.Chains;

namespace CheckOrSaveBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            string config = "ROUTE:FOLLOW;MATERIAL:FOLLOW,SOLDER;FAILED:TEST;NONEXECUTE:TEST;";

            CheckerChain checkChain = CheckerChain.CreateChainFromConfig(config);
            checkChain.Check();

            WriteLine("------------");

            SaverChain saverChain = SaverChain.CreateSaveChainFromConfig(config);
            saverChain.Save();

            ReadKey();
        }
    }
}
