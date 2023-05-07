using CarRentalApi.Core.Collections;
using CarRentalApi.Core.DTO;
using CarRentalApi.Core.Entities;
using CarRentalApi.Services.Repository;
using CarRentalApi.WebApi.Models;
using CarRentalApi.WebApi.Models.Car;
using CarRentalApi.WebApi.Models.Comment;
using CarRentalApi.WebApi.Models.Model;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarRentalApi.WebApi.Endpoints
{
    public static class CommentEndpoint
    {
        public static WebApplication MapCommentEndpoints(
            this WebApplication app)
        {
            var routeGroupBuilder = app.MapGroup("/api/comments");

            routeGroupBuilder.MapGet("/", GetComments)
                .WithName("GetComments")
                .Produces<ApiResponse<CommentDto>>();

            routeGroupBuilder.MapPost("/", AddComment)
                .WithName("AddNewComment")
                .Produces(401)
                .Produces<ApiResponse<CommentDto>>();

            return app;
        }

        private static async Task<IResult> AddComment(
            CommentEditModel model,
            [FromServices] ICommentRepository commentRepository,
            [FromServices] IMapper mapper)
        {

            var comment = mapper.Map<Comment>(model);
            comment.PostedDate = DateTime.Now;
            await commentRepository.CreateCommentAsync(comment);

            return Results.Ok(ApiResponse.Success(
                mapper.Map<CommentDto>(comment),
                HttpStatusCode.Created));
        }

        private static async Task<IResult> GetComments(
            [FromServices] ICommentRepository repository)
        {
            var commentsList = await repository.GetCommentsAsync();

            return Results.Ok(ApiResponse.Success(commentsList));
        }


    }
}
