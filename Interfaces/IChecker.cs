using CheckOrSaveBusiness.Models;

namespace CheckOrSaveBusiness.Interfaces
{
    public interface IChecker
    {
        void Init(string config);
        Result Check();
    }
}
