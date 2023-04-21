using CarRentalApi.Core.DTO;
using CarRentalApi.Core.Entities;
using CarRentalApi.Services.Cars;
using CarRentalApi.WebApi.Models.Cars;
using MapsterMapper;
using Mapster;
using CarRentalApi.Core.Collections;
using CarRentalApi.WebApi.Models;
using CarRentalApi.WebApi.Models.Car;

namespace CarRentalApi.WebApi.Endpoints
{
    public static class CarEndpoint
    {
        public static WebApplication MapCarEndpoints(this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/cars");

            routeGroupBuilder.MapGet("/", GetCarsPagination)
                .WithName("GetCarsPagination")
                .Produces<ApiResponse<CarDto>>();

            return app;
        }

        private static async Task<IResult> GetCarsPagination(
            [AsParameters] CarFilterModel filter,
            [AsParameters] PagingModel paging,
            ICarRepository repository,
            IMapper mapper)
        {
            if (filter.IsActived == null) { 
                filter.IsActived = true;
            }

            // Tạo điều kiện truy vấn
            var query = mapper.Map<CarQuery>(filter);

            // Mặc định nếu không truyền tham số PageSize & PageNumber thì đã handler rồi :D
            var carList = await repository.GetPagedCarsQueryAsync<CarDto>(
                    carList => carList.ProjectToType<CarDto>(),
                    query,
                    paging
                );

            var paginationResult = new PaginationResult<CarDto>(carList);

            return Results.Ok(ApiResponse.Success(paginationResult));
        }
    }
}
