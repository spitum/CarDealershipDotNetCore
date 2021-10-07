using CarDealership.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.UI.Interfaces
{
    public interface IStateDataService
    {
        Task<IEnumerable<State>> GetStates();
    }
}
