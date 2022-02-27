using Arx.ElpeChargeGo.Core.Constants;
using backend.Data;
using backend.Models;
using backend.Models.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet("get-products")]
        public async Task<APIResult<List<Warehouse>>> GetProducts()
        {
            

            //_appDbContext.Cars.Add(s);
            //await _appDbContext.SaveChangesAsync();
            //var result = await _appDbContext.Cars.Where(d=>d.Licenced==true).FirstOrDefaultAsync();
            //if (result!= null)
            //{
            //    //return new APIResult<Car>(warehousee);
            //    return new APIResult<Car>(ProjectErrorCodes.NotExisting);

            //}
            return new APIResult<List<Warehouse>>(ProjectErrorCodes.NotExisting);
        }
    }
}
