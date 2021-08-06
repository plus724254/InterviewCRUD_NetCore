using AutoMapper;

namespace InterviewCRUD_NetCore.Tools.AutoMappers
{
    public static class AutoMap
    {
        public static IMapper Mapper { get; set; }

        public static void RegisterMappings()
        {
            var mapperConfiguration = new MapperConfiguration(
                config =>
                {
                    config.AddProfile<CommonProfile>();
                });

            Mapper = mapperConfiguration.CreateMapper();
        }
        
    }
}