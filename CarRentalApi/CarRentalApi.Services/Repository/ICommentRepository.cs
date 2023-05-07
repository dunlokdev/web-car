using CarRentalApi.Core.Contracts;
using CarRentalApi.Core.DTO;
using CarRentalApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApi.Services.Repository
{
    public interface ICommentRepository
    {
        Task<IList<CommentDto>> GetCommentsAsync(
            CancellationToken cancellationToken = default);

        Task<IPagedList<CommentDto>> GetPagedCommentsAsync(
            IPagingParams pagingParams,
            string content = null,
            CancellationToken cancellationToken = default);

        Task<Comment> GetCommentByIdAsync(
            int commentId,
            CancellationToken cancellationToken = default);

        Task<Comment> GetCachedCommentByIdAsync(int commentId);

        Task<IPagedList<Comment>> GetPagedCommentsByPostIdAsync(
            int postId,
            IPagingParams pagingParams,
            CancellationToken cancellationToken = default);

        Task<Comment> CreateCommentAsync(
            Comment comment,
            CancellationToken cancellationToken = default);

        Task<bool> UpdateCommentAsync(
            Comment comment,
            CancellationToken cancellationToken = default);

        Task<bool> DeleteCommentAsync(
            int commentId,
            CancellationToken cancellationToken = default);
    }
}
