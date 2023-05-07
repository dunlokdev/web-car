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
    public interface IAuthorRepository
    {
        Task<Author> GetAuthorBySlugAsync(
        string slug,
        CancellationToken cancellationToken = default);

        Task<Author> GetCachedAuthorBySlugAsync(
            string slug, CancellationToken cancellationToken = default);

        Task<Author> GetAuthorByIdAsync(int authorId);

        Task<Author> GetCachedAuthorByIdAsync(int authorId);

        Task<IList<AuthorDto>> GetAuthorsAsync(
            CancellationToken cancellationToken = default);

        Task<IPagedList<AuthorDto>> GetPagedAuthorsAsync(
            IPagingParams pagingParams,
            string name = null,
            CancellationToken cancellationToken = default);

        Task<IPagedList<T>> GetPagedAuthorsAsync<T>(
            Func<IQueryable<Author>, IQueryable<T>> mapper,
            IPagingParams pagingParams,
            string name = null,
            CancellationToken cancellationToken = default);

        Task<bool> AddOrUpdateAsync(
            Author author,
            CancellationToken cancellationToken = default);

        Task<bool> DeleteAuthorAsync(
            int authorId,
            CancellationToken cancellationToken = default);

        Task<bool> IsAuthorSlugExistedAsync(
            int authorId, string slug,
            CancellationToken cancellationToken = default);

        Task<bool> SetImageUrlAsync(
            int authorId, string imageUrl,
            CancellationToken cancellationToken = default);

        Task<List<AuthorDto>> GetAuthorsHasMostPost(int numberOfAuthors, CancellationToken cancellationToken = default);
    }
}
