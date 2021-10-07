using CarDealership.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.UI.Interfaces
{
    public interface ISpecialDataService
    {
        Task<IEnumerable<Special>> GetSpecial();

        Task AddSpecial(Special newSpecial);

        Task DeleteSpecial(int specialId);
    }
}
