using CarRentalApi.Core.DTO;
using CarRentalApi.Core.Entities;
using CarRentalApi.Services.Repository;
using CarRentalApi.WebApi.Models.Cars;
using MapsterMapper;
using Mapster;
using SlugGenerator;
using CarRentalApi.Core.Collections;
using CarRentalApi.WebApi.Models;
using CarRentalApi.WebApi.Models.Car;
using System.Net;
using Microsoft.Extensions.Hosting;
using CarRentalApi.Services.Media;

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

            routeGroupBuilder.MapPost("/", AddCar)
                              .WithName("AddCar")
                              .Accepts<CarEditModel>("multipart/form-data")
                              .Produces(401)
                              .Produces<ApiResponse<CarDto>>();
            routeGroupBuilder.MapDelete("/{id:int}", DeleteCar)
                            .WithName("DeleteCar")
                            .Produces<ApiResponse<string>>();

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

        private static async Task<IResult> AddCar(
              HttpContext context,
              IMapper mapper,
              ICarRepository repository,
              IMediaManager mediaManager)
        {

            var model = await CarEditModel.BindAsync(context);
            var slug = model.Name.GenerateSlug();
            if (await repository.IsCarlugExistedAsync(model.Id, slug))
            {
                return Results.Ok(ApiResponse.Fail(HttpStatusCode.Conflict, $"Slug '{slug}' đã được sử dụng cho xe khác rồi"));
            }

            var car = model.Id > 0 ? await repository.GetCarByIdAsync(model.Id, true) : null;

            if (car == null)
            {
                car = new Car()
                {
                    CreatedAt = DateTime.Now,
                };
            }

            //- ID
            //- ModelID
            //- Name
            //- Price (\*)
            //- Discount
            //- Thumbnail
            //- ShortDescripton
            //- Description
            //- UrlSlug
            //- IsActived
            //- Wattage: Công xuất (\*)
            //- Torque: Mô men xoắn (\*)
            //- SpeedUp: Tăng tốc từ 0 - 100km (0 - 62 dặm) (\*)
            //- MaxSpeed: Tốc độ tối đa (\*)
            //- Consume: Lượng tiêu thụ
            //- Emissions: Lượng khí thải
            //- Evaluate: Đánh giá
            //- CreateAt
            //- UpdateAt

            car.ModelId = model.ModelId;
            car.Name = model.Name;
            car.Price = model.Price;
            car.Discount = model.Discount;
            car.UrlSlug = slug;
            car.ShortDescripton = model.ShortDescripton;
            car.Description = model.Description;
            car.IsActived = model.IsActived;
            car.Wattage = model.Wattage;
            car.Torque = model.Torque;
            car.SpeedUp = model.SpeedUp;
            car.MaxSpeed = model.MaxSpeed;
            car.Consume = model.Consume;
            car.Emission = model.Emission;
            car.Evaluate = model.Evaluate;

            car.UpdatedAt = DateTime.Now;

            if (model.ImageFile?.Length > 0)
            {
                string hostname = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}/";
                var uploadedPath = await mediaManager.SaveFileAsync(
                    model.ImageFile.OpenReadStream(),
                    model.ImageFile.FileName,
                    model.ImageFile.ContentType);

                if (!string.IsNullOrWhiteSpace(uploadedPath))
                {
                    car.Thumbnail = hostname + uploadedPath;
                }
            }
            await repository.CreateOrUpdateCarAsync(car);

            return Results.Ok(ApiResponse.Success(mapper.Map<CarDto>(car), HttpStatusCode.Created));
        }

        private static async Task<IResult> DeleteCar(int id, ICarRepository blogRepository)
        {
            return await blogRepository.DeleteCarByIdAsync(id)
                    ? Results.Ok(ApiResponse.Success($"Xóa thành công xe có Id = {id}"))
                    : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy xe có Id = {id}"));
        }

    }
}
