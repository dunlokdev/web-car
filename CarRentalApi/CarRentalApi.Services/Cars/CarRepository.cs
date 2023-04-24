using CarRentalApi.Core.DTO;
using CarRentalApi.Core.Entities;
using CarRentalApi.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using CarRentalApi.Core.Contracts;
using CarRentalApi.Services.Extentions;

namespace CarRentalApi.Services.Cars
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDbContext _context;

        public CarRepository(CarDbContext context)
        {
            _context = context;
        }

        private IQueryable<Car> FilterCar(CarQuery condition)
        {
            IQueryable<Car> carList = _context.Set<Car>()
                  .Include(x => x.Model)
                  .Include(x => x.Galery)
                  .Include(x => x.OrderDetails);

            if (condition.IsActived)
            {
                carList = carList.Where(x => x.IsActived);
            }
            else
            {
                carList = carList.Where(x => !x.IsActived);
            }

            if (condition.ModelId > 0)
            {
                carList = carList.Where(x => x.ModelId == condition.ModelId);
            }

            if (!string.IsNullOrWhiteSpace(condition.UrlSlug))
            {
                carList = carList.Where(x => x.UrlSlug == condition.UrlSlug);
            }

            if (condition.Price > 0)
            {
                carList = carList.Where(x => x.Price == condition.Price);
            }

            if (!string.IsNullOrWhiteSpace(condition.Description))
            {
                carList = carList.Where(x => x.Description == condition.Description);
            }

            if (!string.IsNullOrWhiteSpace(condition.Keyword))
            {
                carList = carList.Where(x => x.Name.Contains(condition.Keyword) ||
                                         x.Description.Contains(condition.Description) ||
                                         x.Model.Name.Contains(condition.Keyword));
            }

            return carList;
        }

        public async Task<IPagedList<T>> GetPagedCarsQueryAsync<T>(
            Func<IQueryable<Car>,
                IQueryable<T>> mapper,
            CarQuery query,
            IPagingParams pagingParams,
            CancellationToken cancellationToken = default)
        {
            return await mapper(FilterCar(query).AsNoTracking()).ToPagedListAsync(pagingParams, cancellationToken);
        }

        public async Task<IPagedList<Car>> GetPagedCarsAsync(
        CarQuery condition,
        int pageNumber = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
        {
            return await FilterCar(condition).ToPagedListAsync(
                pageNumber, pageSize,
                nameof(Car.CreatedAt), "DESC",
                cancellationToken);
        }

        public async Task<Car> GetCarByIdAsync(int carId, bool isIncludeDetail = false, CancellationToken cancellationToken = default)
        {
            if (!isIncludeDetail)
            {
                return await _context.Set<Car>().FindAsync(carId);
            }

            return await _context.Set<Car>()
                .Include(x => x.Model)
                .Include(x => x.Galery)
                .Include(x => x.OrderDetails)
                .FirstOrDefaultAsync(x => x.Id == carId, cancellationToken);
        }

        public async Task<Car> GetCarBySlugAsync(string slug, bool isIncludeDetail, CancellationToken cancellationToken = default)
        {
            if (!isIncludeDetail)
            {
                return await _context.Set<Car>().FirstOrDefaultAsync(x => x.UrlSlug == slug, cancellationToken);
            }

            return await _context.Set<Car>()
                .Include(x => x.Model)
                .Include(x => x.Galery)
                .Include(x => x.OrderDetails)
                .FirstOrDefaultAsync(x => x.UrlSlug == slug, cancellationToken);
        }
    }
}
