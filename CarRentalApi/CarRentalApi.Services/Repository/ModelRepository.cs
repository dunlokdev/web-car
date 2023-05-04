using CarRentalApi.Core.DTO;
using CarRentalApi.Core.Entities;
using CarRentalApi.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApi.Services.Repository
{
    public class ModelRepository : IModelRepository
    {
        private readonly CarDbContext _context;

        public ModelRepository(CarDbContext context)
        {
            _context = context;
        }

        public async Task<Model> CreateOrUpdateModelAsync(Model model, CancellationToken cancellationToken = default)
        {
            if (model.Id > 0)
                _context.Update(model);
            else
                _context.Add(model);

            await _context.SaveChangesAsync(cancellationToken);

            return model;
        }

        public async Task<bool> DeleteModelByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Model>()
                            .Where(t => t.Id == id).ExecuteDeleteAsync(cancellationToken) > 0;        }

        public async Task<Model> GetModelByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Model>()
                .Include(x => x.CarList)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);        }

       
        public async Task<IList<ModelDto>> GetModelListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Model>()
                .OrderBy(x => x.Name)
                .Select(x => new ModelDto()
                {
                    Id  = x.Id,
                    Name = x.Name,
                    UrlSlug = x.UrlSlug,
                    Thumbnail = x.Thumbnail,
                    CarCount = x.CarList.Count(x => x.IsActived)
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> IsModelSlugExistedAsync(int id, string slug, CancellationToken cancellationToken = default)
        {
             return await _context.Set<Model>()
                .AnyAsync(x => x.Id != id && x.UrlSlug == slug, cancellationToken);
        }
    }
}
