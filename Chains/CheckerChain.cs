using CheckOrSaveBusiness.Factories;
using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Models;

namespace CheckOrSaveBusiness.Chains
{
    public class CheckerChain
    {
        protected CheckerChain next;
        private readonly IChecker _checker;

        public CheckerChain(string checkerName, string config)
        {
            _checker = CheckerFactory.GetChecker(checkerName);
            _checker.Init(config);
        }

        public void SetNext(CheckerChain next)
        {
            this.next = next;
        }

        public Result Check()
        {
            Result result = _checker.Check();
            if (result.IsSuccess && next != null)
            {
                result = next.Check();
            }
            return result;
        }

        public static CheckerChain CreateChainFromConfig(string config)
        {
            CheckerChain chain = null;
            CheckerChain next = null;
            foreach (string configItems in config.Split(';'))
            {
                string[] configItemKeyParams = configItems.Split(':');
                if (configItemKeyParams.Length == 2)
                {
                    CheckerChain newChain = new CheckerChain(configItemKeyParams[0], configItemKeyParams[1]);
                    if (chain == null)
                    {
                        chain = newChain;
                        next = chain;
                    }
                    else
                    {
                        next.SetNext(newChain);
                        next = newChain;
                    }
                }
            }
            return chain;
        }
    }
}
