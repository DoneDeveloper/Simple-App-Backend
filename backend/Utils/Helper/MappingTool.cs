using AutoMapper;
using backend.Models.AutoMap;

namespace backend.Utils.Helpers
{
    public static class MappingTool
    {
        public static TRes MapTo<TBase, TRes>(this TBase value, object externalData = null)
        {
            var mapConfig = MappingLayers.GetPreBuildMapLayerConfig(externalData);
            IMapper mapper;
            if (mapConfig.FindTypeMapFor<TBase, TRes>() != null)
            {
                mapper = new Mapper(mapConfig);
            }
            else
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<TBase, TRes>());
                mapper = config.CreateMapper();
            }
            return mapper.Map<TRes>(value);
        }

        public static (TRes FirstType, TResSecond SecondType) MapToMultiple<TBase, TRes, TResSecond>(this TBase value, object externalData = null)
        {
            var firstType = value.MapTo<TBase, TRes>(externalData);
            var secondType = value.MapTo<TBase, TResSecond>(externalData);
            return (firstType, secondType);
        }
    }
}
