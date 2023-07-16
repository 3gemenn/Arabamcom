using Arabamcom.Core.DTOs;
using Arabamcom.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabamcom.Core.Services
{
    public interface IService
    {
        Task<AdvertAllDto> All(int categoryId, decimal price, string gear, string fuel, int page, PriceEnum priceShorting, YearEnum yearShorting, KmEnum kmShorting);
        Task<AdvertGetDto> Get(int id);
    }
}
