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
    public interface IPostRepository
    {
        Task<IPagedList<T>> GetPagedPostsByQueryAsync<T>(Func<IQueryable<Post>, IQueryable<T>> mapper, PostQuery query, IPagingParams pagingParams, CancellationToken cancellationToken = default);
        Task<Post> GetPostBySlugAsync(string slug, bool includeDetails = false, CancellationToken cancellationToken = default);

    }
}
