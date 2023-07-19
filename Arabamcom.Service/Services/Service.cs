using Arabamcom.Core.DTOs;
using Arabamcom.Core.Enums;
using Arabamcom.Core.Models;
using Arabamcom.Core.Services;
using Arabamcom.Repository.DbContext;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabamcom.Service.Services
{
    public class Service : IService
    {
        private readonly ConnectionHelper _context;
        public Service(ConnectionHelper context)
        {
            _context = context;
        }
        public async Task<List<AdvertAllDto>> All(int categoryId, decimal priceMin, decimal priceMax, GearEnum gearFiltering, FuelEnum fuelFiltering, AllSorting allSorting)
        {
            try
            {
                string query = "";

                query = "SELECT * FROM Adverts$";
                using (var connection = _context.CreateConnection())
                {
                    var companies = connection.QueryAsync<AdvertAllDto>(query).Result;
                    if (categoryId != 0)
                    {
                        companies = companies.Where(x => x.CategoryId == categoryId).ToList();
                    }
                    if (priceMin != 0 && priceMax != 0)
                    {
                        companies = companies.Where(x => x.Price >= priceMin && x.Price <= priceMax).ToList();
                    }
                    else if (priceMin != 0)
                    {
                        companies = companies.Where(x => x.Price >= priceMin).ToList();
                    }
                    else if (priceMax != 0)
                    {
                        companies = companies.Where(x => x.Price <= priceMax).ToList();
                    }
                    if (gearFiltering.ToString() != "Tümü")
                    {
                        companies = companies.Where(x => x.Gear == gearFiltering.ToString()).ToList();
                    }
                    if (fuelFiltering.ToString() != "Tümü")
                    {
                        companies = companies.Where(x => x.Gear == fuelFiltering.ToString()).ToList();
                    }
                    if (allSorting.ToString() != "Gelişmiş")
                    {
                        if (allSorting.ToString() == "Km_Azdan_Coka")
                        {
                            companies = companies.OrderBy(x => x.Km);
                        }
                        if (allSorting.ToString() == "Km_Coktan_Aza")
                        {
                            companies = companies.OrderByDescending(x => x.Km);
                        }
                        if (allSorting.ToString() == "Ucuzdan_Pahaliya")
                        {
                            companies = companies.OrderBy(x => x.Price);
                        }
                        if (allSorting.ToString() == "Pahalidan_Ucuza")
                        {
                            companies = companies.OrderByDescending(x => x.Price);
                        }
                        if (allSorting.ToString() == "Yeniden_Eskiye")
                        {
                            companies = companies.OrderBy(x => x.Year);
                        }
                        if (allSorting.ToString() == "Eskiden_Yeniye")
                        {
                            companies = companies.OrderByDescending(x => x.Year);
                        }

                    }

                    return companies.ToList();
                }

                //throw new NotImplementedException();

            }
            catch (Exception e)
            {

                throw;
            }
        }


        public async Task<AdvertGetDto> Get(int id)
        {
            try
            {
                var query = "SELECT * FROM Adverts WHERE id = '" + id + "'";
                using (var connection = _context.CreateConnection())
                {
                    var companies = connection.QueryAsync<AdvertGetDto>(query).Result.FirstOrDefault();
                    return companies;
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
