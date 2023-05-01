using CarRentalApi.Core.DTO;
using CarRentalApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApi.Services.Repository
{
    public interface IModelRepository
    {
        Task<IList<ModelDto>> GetModelListAsync(CancellationToken cancellationToken = default);
        Task<Model> GetModelByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
