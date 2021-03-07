using CheckOrSaveBusiness.Interfaces;
using CheckOrSaveBusiness.Factories;
using CheckOrSaveBusiness.Models;

namespace CheckOrSaveBusiness.Chains
{
    public class SaverChain
    {
        protected SaverChain next;
        private readonly ISaver _saver;

        public SaverChain(string saverName, string config)
        {
            _saver = SaverFactory.GetSaver(saverName);
            _saver.Init(config);
        }

        public void SetNext(SaverChain next)
        {
            this.next = next;
        }

        public Result Save()
        {
            Result result = _saver.Save();
            if ( result.IsSuccess && next != null)
            {
                result = next.Save();
            }
            return result;
        }

        public static SaverChain CreateSaveChainFromConfig(string config)
        {
            SaverChain chain = null;
            SaverChain next = null;
            foreach (string configItems in config.Split(';'))
            {
                string[] configItemKeyParams = configItems.Split(':');
                if (configItemKeyParams.Length == 2)
                {
                    SaverChain newChain = new SaverChain(configItemKeyParams[0], configItemKeyParams[1]);
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
