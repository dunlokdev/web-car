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
    }
}
