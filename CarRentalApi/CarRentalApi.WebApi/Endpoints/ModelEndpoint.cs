using CarRentalApi.Core.Collections;
using CarRentalApi.Core.DTO;
using CarRentalApi.Services.Repository;
using CarRentalApi.WebApi.Models;
using CarRentalApi.WebApi.Models.Car;
using MapsterMapper;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CarRentalApi.Core.Entities;
using CarRentalApi.Services.Media;
using CarRentalApi.WebApi.Models.Cars;
using SlugGenerator;
using CarRentalApi.WebApi.Models.Model;

namespace CarRentalApi.WebApi.Endpoints
{
    public static class ModelEndpoint
    {
        public static WebApplication MapModelEndpoints(this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/model");

            routeGroupBuilder.MapGet("/", GetModels)
                           .WithName("GetModels")
                           .Produces<ApiResponse<IList<ModelDto>>>();

            routeGroupBuilder.MapGet("{id:int}", GetModelById)
               .WithName("GetModelById")
               .Produces<ApiResponse<ModelDto>>();

            routeGroupBuilder.MapGet("/{slug:regex(^[a-z0-9_-]+$)}/cars", GetCarsByModelSlug)
                           .WithName("GetCarsByModelSlug")
                           .Produces<ApiResponse<PaginationResult<CarDto>>>();

            routeGroupBuilder.MapPost("/", AddModel)
                              .WithName("AddModel")
                              .Accepts<ModelEdit>("multipart/form-data")
                              .Produces(401)
                              .Produces<ApiResponse<CarDto>>();
            routeGroupBuilder.MapDelete("/{id:int}", DeleteModel)
                            .WithName("DeleteModel")
                            .Produces<ApiResponse<string>>();

            return app;
        }

        private static async Task<IResult> GetModelById(
            int id,
            IMapper mapper,
            IModelRepository repository)
        {
            var model = await repository.GetModelByIdAsync(id);

            return model != null
                ? Results.Ok(ApiResponse.Success(mapper.Map<ModelDto>(model)))
                : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy dòng có mã số = {id}"));
        }

        private static async Task<IResult> GetModels(
            IModelRepository repository,
            IMapper mapper)
        {
            var modelList = await repository.GetModelListAsync();

            return Results.Ok(ApiResponse.Success(modelList));
        }

        private static async Task<IResult> GetCarsByModelSlug(
           [FromRoute] string slug,
           [AsParameters] PagingModel pagingModel,
           ICarRepository repository)
        {
            var query = new CarQuery()
            {
                ModelSlug = slug,
                IsActived = true
            };
            
            var cars = await repository.GetPagedCarsQueryAsync(
                cars => cars.ProjectToType<CarDto>(),
                query,
                pagingModel);
            var paginationResult = new PaginationResult<CarDto>(cars);

            return Results.Ok(ApiResponse.Success(paginationResult));
        }

        private static async Task<IResult> AddModel(
             HttpContext context,
             IMapper mapper,
             IModelRepository repository,
             IMediaManager mediaManager)
        {

            var newModel = await ModelEdit.BindAsync(context);
            var slug = newModel.Name.GenerateSlug();
            if (await repository.IsModelSlugExistedAsync(newModel.Id, slug))
            {
                return Results.Ok(ApiResponse.Fail(HttpStatusCode.Conflict, $"Slug '{slug}' đã được sử dụng cho dòng xe khác rồi"));
            }

            var model = newModel.Id > 0 ? await repository.GetModelByIdAsync(newModel.Id) : new Model();

            model.Name = newModel.Name;
            model.UrlSlug = slug;

            if (newModel.ImageFile?.Length > 0)
            {
                string hostname = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}/";
                var uploadedPath = await mediaManager.SaveFileAsync(
                    newModel.ImageFile.OpenReadStream(),
                    newModel.ImageFile.FileName,
                    newModel.ImageFile.ContentType);

                if (!string.IsNullOrWhiteSpace(uploadedPath))
                {
                    model.Thumbnail = hostname + uploadedPath;
                }
            }
            await repository.CreateOrUpdateModelAsync(model);

            return Results.Ok(ApiResponse.Success(mapper.Map<ModelDto>(model), HttpStatusCode.Created));
        }

        private static async Task<IResult> DeleteModel(int id, IModelRepository repository)
        {
            return await repository.DeleteModelByIdAsync(id)
                    ? Results.Ok(ApiResponse.Success($"Xóa thành công"))
                    : Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy dòng xe có Id = {id}"));
        }

    }
}
