using CarRentalApi.Core.DTO;
using CarRentalApi.Core.Entities;
using CarRentalApi.Services.Repository;
using CarRentalApi.WebApi.Models.Cars;
using MapsterMapper;
using Mapster;
using CarRentalApi.Core.Collections;
using CarRentalApi.WebApi.Models;
using CarRentalApi.WebApi.Models.Car;
using System.Net;

namespace CarRentalApi.WebApi.Endpoints
{
    public static class CarEndpoint
    {
        public static WebApplication MapCarEndpoints(this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/cars");

            routeGroupBuilder.MapGet("/", GetCarsPagination)
                           .WithName("GetCarsPagination")
                           .Produces<ApiResponse<PaginationResult<CarDto>>>();

            routeGroupBuilder.MapGet("{id:int}", GetCarById)
                           .WithName("GetCarById")
                           .Produces<ApiResponse<CarDto>>();

            routeGroupBuilder.MapGet("/galeries/{id:int}", GetGaleriesByCarId)
                           .WithName("GetGaleriesByCarId")
                           .Produces<ApiResponse<IList<GaleryDto>>>();

            routeGroupBuilder.MapGet("/slug/{slug:regex(^[a-z0-9_-]+$)}", GetCarBySlug)
                           .WithName("GetCarBySlug")
                           .Produces<ApiResponse<CarDto>>();

            return app;
        }

        private static async Task<IResult> GetCarById(
            int id,
            IMapper mapper,
            ICarRepository repository)
        {
            var car = await repository.GetCarByIdAsync(id, true);

            return car != null
                ? Results.Ok(ApiResponse.Success(mapper.Map<CarDto>(car)))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy xe có mã số = {id}"));
        }

        private static async Task<IResult> GetGaleriesByCarId(int id, ICarRepository repository)
        {
            var galeries = await repository.GetGaleriesByCarId(id);
            return Results.Ok(ApiResponse.Success(galeries));
        }

        private static async Task<IResult> GetCarBySlug(
           string slug,
           IMapper mapper,
           ICarRepository repository)
        {
            var car = await repository.GetCarBySlugAsync(slug, true);

            return car != null
                ? Results.Ok(ApiResponse.Success(mapper.Map<CarDto>(car)))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy xe có slug = {slug}"));
        }

        private static async Task<IResult> GetCarsPagination(
            [AsParameters] CarFilterModel filter,
            [AsParameters] PagingModel paging,
            ICarRepository repository,
            IMapper mapper)
        {
            if (filter.IsActived == null)
            {
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
