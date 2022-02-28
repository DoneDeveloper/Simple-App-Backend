using Arx.ElpeChargeGo.Core.Constants;
using Arx.ElpeChargeGo.Core.Models.DTO;
using Arx.ElpeChargeGo.Core.Utils;
using backend.Data;
using backend.Models;
using backend.Models.Responses;
using backend.Utils.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public class ProductService
    {
        private readonly AppDbContext _appDbContext;
        public ProductService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public async Task<InternalDataTransfer<List<WarehouseResponse>>> FeedDatabase()
        {
            try
            {
                using (StreamReader r = new StreamReader("Constants/FeedDatabase/warehouses.json"))
                {
                    string json = await r.ReadToEndAsync();
                    JArray array = JArray.Parse(json);
                    List<WarehouseResponse> data = array.ToObject<List<WarehouseResponse>>();

                    if (data == null || data.Count() == 0)
                    {
                        return new InternalDataTransfer<List<WarehouseResponse>>(false, "Target file to fetch data is empty");
                    }

                    foreach (var item in data)
                    {
                        Models.Database.Location loc = new Models.Database.Location
                        {
                            lat = item.location.lat,
                            @long = item.location.@long,
                            name = item.cars.location
                        };

                        List<Car> cars = item.cars.vehicles;
                        foreach (var car in cars)
                            await _appDbContext.Cars.AddAsync(car);

                        Warehouse warehouse = new Warehouse
                        {
                            Id = item._id,
                            Name = item.name,
                            Cars = cars,
                            Location = loc
                        };

                        await _appDbContext.Warehouses.AddAsync(warehouse);
                        await _appDbContext.Locations.AddAsync(loc);
                    }
                    await _appDbContext.SaveChangesAsync();

                    return new InternalDataTransfer<List<WarehouseResponse>>(data);
                }
            }
            catch (Exception e)
            {
                return new InternalDataTransfer<List<WarehouseResponse>>(e);
            }



        }

        public InternalDataTransfer<List<WarehouseResponse>> convertDataToResponse(List<Warehouse> list)
        {
            List<WarehouseResponse> finalResponse = new List<WarehouseResponse>();
            foreach (var warehouse in list)
            {
                var record = warehouse.MapTo<Warehouse, WarehouseResponse>();
                finalResponse.Add(record);
            }

            if (finalResponse != null && finalResponse.Count > 0)
                return new InternalDataTransfer<List<WarehouseResponse>>(finalResponse);

            return new InternalDataTransfer<List<WarehouseResponse>>(false, "Could not map database data to response model");

        }
    }
}
