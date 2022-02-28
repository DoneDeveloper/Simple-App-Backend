using AutoMapper;
using backend.Models;
using backend.Models.Responses;
using System;

namespace backend.Models.AutoMap
{
    public static class MappingLayers
    {
        public static IMapperConfigurationExpression BuildMappingLayers(this IMapperConfigurationExpression map, object externalData = null)
        {
            if (externalData == null)
            {
                externalData = new { };
            }

            map.CreateMap<Warehouse, WarehouseResponse>()
                .ForMember(dest => dest._id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.cars, opts => opts.MapFrom(src => new Cars
                {
                    location = src.Location.name,
                    vehicles = src.Cars
                }))
                .ForMember(dest => dest.location, opts => opts.MapFrom(src => new Location {
                    lat = src.Location.@long,
                    @long = src.Location.@long
                }))

                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            return map;
        }

        public static MapperConfiguration GetPreBuildMapLayerConfig(object externalData = null) => new MapperConfiguration(main => main.BuildMappingLayers(externalData));
    }
}
