using CarRentalApi.Core.DTO;
using CarRentalApi.Core.Entities;
using CarRentalApi.WebApi.Models.Car;
using CarRentalApi.WebApi.Models.Cars;
using CarRentalApi.WebApi.Models.Post;
using Mapster;

namespace TatBlog.WebApi.Mapsters
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Mapping Car Model
            config.NewConfig<CarFilterModel, CarQuery>();
            config.NewConfig<Car, CarDto>()
                .Map(dst => dst.Model, src => src.Model.Name);

            config.NewConfig<Model, ModelDto>()
                .Map(dst => dst.CarCount, src => src.CarList == null ? 0 : src.CarList.Count());

            config.NewConfig<PostFilterModel, PostQuery>()
                .Map(dest => dest.KeyWord, src => src.Keyword);
            config.NewConfig<Post, PostDto>()
                .Map(dest => dest.Author, src => src.Author.FullName);
        }
    }
}
