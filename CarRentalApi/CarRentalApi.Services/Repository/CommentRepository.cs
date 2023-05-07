using CarRentalApi.Core.Contracts;
using CarRentalApi.Core.DTO;
using CarRentalApi.Core.Entities;
using CarRentalApi.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApi.Services.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CarDbContext _context;

        public CommentRepository(CarDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateCommentAsync(Comment comment, CancellationToken cancellationToken = default)
        {
            await _context.Comments.AddAsync(comment, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
			return comment;
        }

        public Task<bool> DeleteCommentAsync(int commentId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetCachedCommentByIdAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetCommentByIdAsync(int commentId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<CommentDto>> GetCommentsAsync(CancellationToken cancellationToken = default)
        {
                return await _context.Set<Comment>()
				.OrderBy(s => s.PostedDate)
				.Select(s => new CommentDto()
				{
					Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    PostedDate = s.PostedDate,
                    IsApproved = s.IsApproved,
                    CarId = s.CarId,
				})
				.ToListAsync(cancellationToken);
        }

        public Task<IPagedList<CommentDto>> GetPagedCommentsAsync(IPagingParams pagingParams, string content = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IPagedList<Comment>> GetPagedCommentsByPostIdAsync(int postId, IPagingParams pagingParams, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCommentAsync(Comment comment, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
