using CarRentalApi.Core.Entities;
using CarRentalApi.Core.Contracts;
using CarRentalApi.Core.DTO;

namespace CarRentalApi.Services.Cars
{
    public interface ICarRepository
    {
        Task<IPagedList<T>> GetPagedCarsQueryAsync<T>(
            Func<IQueryable<Car>,
                IQueryable<T>> mapper,
            CarQuery query,
            IPagingParams pagingParams,
            CancellationToken cancellationToken = default);

        Task<IPagedList<Car>> GetPagedCarsAsync(
            CarQuery condition,
            int pageNumber = 1,
            int pageSize = 10,
            CancellationToken cancellationToken = default);

        Task<Car> GetCarByIdAsync(
            int carId,
            bool isIncludeDetail,
            CancellationToken cancellationToken = default);

        Task<Car> GetCarBySlugAsync(
            string slug ,
            bool isIncludeDetail,
            CancellationToken cancellationToken = default);
    }
}
