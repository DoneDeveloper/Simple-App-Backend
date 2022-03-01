using Arx.ElpeChargeGo.Core.Constants;
using backend.Data;
using backend.Models;
using backend.Models.Database;
using backend.Models.Responses;
using backend.Services;
using backend.Utils.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        private readonly ProductService _productService;

        public ProductController(
            AppDbContext appDbContext,
            ProductService productService
            )
        {
            _appDbContext = appDbContext;
            _productService = productService;
        }


        [HttpGet("get-products")]
        public async Task<APIResult<List<WarehouseResponse>>> GetProducts()
        {
            //Code to initialy feed the database by the mock json file
            //var res = await _productService.FeedDatabase();
            //if (res.Status == false)
            //{
            //    return new APIResult<List<Warehouse>>(ProjectErrorCodes.InternalError, res.Error.Description);
            //}


            //Get data from database
            var result = await _appDbContext.Warehouses.Include(d=>d.Cars).Include(d=> d.Location).ToListAsync();
            if (result== null || result.Count()==0)
                return new APIResult<List<WarehouseResponse>>(ProjectErrorCodes.NotExisting);


            //Map data to responsemodel
            var data =  _productService.convertDataToResponse(result);

            if (data.Status)
                return new APIResult<List<WarehouseResponse>>(data.Data);
            

            return new APIResult<List<WarehouseResponse>>(ProjectErrorCodes.NotExisting,data.Error.Description);
        }

        [HttpGet("get-car/{carId}")]
        public async Task<APIResult<FullDescriptionCarResponse>> GetCar([FromRoute] int carId)
        {
            var theCar = await _appDbContext.Cars.Where(d => d._id == carId).FirstOrDefaultAsync();

            if (theCar == null)
                return new APIResult<FullDescriptionCarResponse>(ProjectErrorCodes.NotExisting, "Could not find car in the database");

            var warehouse = await _appDbContext.Warehouses.Include(d => d.Location).Include(d => d.Cars).Where(d=>d.Cars.Contains(theCar)).FirstOrDefaultAsync();

            if (theCar == null)
                return new APIResult<FullDescriptionCarResponse>(ProjectErrorCodes.NotExisting, "Could not find car's warehouse in the database");

            FullDescriptionCarResponse responseCar = new FullDescriptionCarResponse(){
                car = theCar,
                warehouseId = warehouse.Id,
                warehouseLocationLat = warehouse.Location.lat,
                warehouseLocationLong = warehouse.Location.@long,
                warehouseLocationName = warehouse.Location.name,
                warehouseName = warehouse.Name
            };



            return new APIResult<FullDescriptionCarResponse>(responseCar);
        }
    }
}
