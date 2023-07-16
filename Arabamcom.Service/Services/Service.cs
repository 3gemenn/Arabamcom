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
        public async Task<AdvertAllDto> All(int categoryId, decimal price, string gear, string fuel, int page, PriceEnum priceShorting, YearEnum yearShorting, KmEnum kmShorting)
        {
            //if (priceShorting == 0)
            //{
            //    var query1 = "SELECT  categoryId , price , gear , fuel , page FROM ArabamcomDb ORDER BY price";
            //}
            //else
            //{
            //    var query2 = "SELECT  categoryId , price , gear , fuel , page FROM ArabamcomDb ORDER BY price DESC ";
            //}
            //if (yearShorting == 0) 
            //{
            //    var query3 = "SELECT  categoryId , price , gear , fuel , page FROM ArabamcomDb ORDER BY year";
            //}
            //else
            //{
            //    var query4 = "SELECT  categoryId , price , gear , fuel , page FROM ArabamcomDb ORDER BY year DESC";
            //}
            //if( kmShorting == 0)
            //{
            //    var query5 = "SELECT  categoryId , price , gear , fuel , page FROM ArabamcomDb ORDER BY km ";
            //}
            //else
            //{
            //    var query6 = "SELECT  categoryId , price , gear , fuel , page FROM ArabamcomDb ORDER BY km DESC";
            //}

            //throw new NotImplementedException();
            var query = "SELECT * FROM Adverts";
            using (var connection = _context.CreateConnection())
            {
                var companies =  connection.QueryAsync<AdvertAllDto>(query).Result.FirstOrDefault();
                return companies;
            }
        }

        public Task<AdvertGetDto> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
