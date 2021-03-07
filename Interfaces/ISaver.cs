using CheckOrSaveBusiness.Models;

namespace CheckOrSaveBusiness.Interfaces
{
    public interface ISaver
    {
        void Init(string config);
        Result Save();
    }
}
