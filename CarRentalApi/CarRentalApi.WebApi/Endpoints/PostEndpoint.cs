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
using CarRentalApi.Services.Media;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using CarRentalApi.WebApi.Models.Post;

namespace CarRentalApi.WebApi.Endpoints
{
    public static class PostEndpoint
    {
        public static WebApplication MapPostsEndpoints(this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/posts");

            routeGroupBuilder.MapGet("/", GetPosts)
               .WithName("GetPosts")
               .Produces<ApiResponse<PaginationResult<PostDto>>>();

            
            routeGroupBuilder.MapGet("/byslug/{slug:regex(^[a-z0-9_-]+$)}", GetPostDetailBySlug)
                .WithName("GetPostDetailBySlug")
                .Produces<ApiResponse<PostDetail>>();

            return app;
        }

        // Lấy thông tin chi tiết bài viết có tên định danh(slug) cho trước.
        private static async Task<IResult> GetPostDetailBySlug([FromRoute] string slug, IPostRepository repository, IMapper mapper)
        {
            var post = await repository.GetPostBySlugAsync(slug, true);

            return post == null
                ? Results.Ok(ApiResponse.Fail(HttpStatusCode.NotFound, $"Không tìm thấy bài viết nào có tồn tại slug '{slug}'"))
                : Results.Ok(ApiResponse.Success(mapper.Map<PostDetail>(post)));
        }

        // Lấy danh sách bài viết. Hỗ trợ tìm theo từ khóa, chuyên mục, tác giả, ngày đăng, … và phân trang kết quả.
        private static async Task<IResult> GetPosts(
            [AsParameters] PostFilterModel model,
            [AsParameters] PagingModel pagingModel,
            IPostRepository repository,
            IMapper mapper)
        {
            // Tạo điều kiện truy vấn
            var postQuery = mapper.Map<PostQuery>(model);

            var posts = await repository.GetPagedPostsByQueryAsync<PostDto>(
                posts => posts.ProjectToType<PostDto>(),
                postQuery,
                pagingModel);

            var paginationResult = new PaginationResult<PostDto>(posts);
            return Results.Ok(ApiResponse.Success(paginationResult));
        }
    }
}
