using CarDealership.Data.Data;
using CarDealership.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Repositories
{
    public class ModelRepository : GenericRepository<Model>,IModelRepository
    {
        public ModelRepository(AppDBContext context) : base(context)
        {

        }

        public IEnumerable<Model> GetModelsByMake(int id)
        {
            var models = _context.Models.Where(m => m.MakeId == id);

            return models;
        }
    }
}
