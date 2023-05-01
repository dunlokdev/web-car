using CarRentalApi.Core.Entities;
using CarRentalApi.Core.Contracts;
using CarRentalApi.Core.DTO;

namespace CarRentalApi.Services.Repository
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

        Task<IList<GaleryDto>> GetGaleriesByCarId(int id, CancellationToken cancellationToken = default);
        Task<bool> IsCarlugExistedAsync(int id, string slug, CancellationToken cancellationToken = default);
        Task<Car> CreateOrUpdateCarAsync(Car car, CancellationToken cancellationToken= default);
        Task<bool> DeleteCarByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
