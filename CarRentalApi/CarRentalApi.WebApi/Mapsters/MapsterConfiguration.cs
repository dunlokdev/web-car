using CarRentalApi.Core.DTO;
using CarRentalApi.Core.Entities;
using CarRentalApi.WebApi.Models.Car;
using CarRentalApi.WebApi.Models.Cars;
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
                .Map(dst => dst.CarCount, src => src.CarList.Count());
        }
    }
}
