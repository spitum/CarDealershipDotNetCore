using CarDealership.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
    public interface IModelRepository : IGenericRepository<Model>
    {
        IEnumerable<Model> GetModelsByMake(int id);
    }
}
