using LBS_API.Model;
using System.Collections;
using System.Collections.Generic;

namespace LBS_API.Repository
{
    public interface ILoadRepository
    {
        void InsertLoad(Load load);
        void UpdateLoad(Load load);
        void DeleteLoad(int loadId);
        Load GetLoadById(int id);
        IEnumerable<Load> GetLoads();
    }
}
