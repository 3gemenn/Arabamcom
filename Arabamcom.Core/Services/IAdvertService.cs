using Arabamcom.Core.DTOs;
using Arabamcom.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabamcom.Core.Services
{
    public interface IAdvertService
    {
        Task<List<AdvertAllDto>> All(int categoryId, decimal priceMin, decimal priceMax, GearEnum gearFiltering, FuelEnum fuelFiltering, AllSorting allSorting);
        Task<AdvertGetDto> Get(int id);
    }
}
