﻿using CarRentalApi.Core.DTO;
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
        Task<bool> IsModelSlugExistedAsync(int id, string slug, CancellationToken cancellationToken = default);
        Task<Model> CreateOrUpdateModelAsync(Model model, CancellationToken cancellationToken = default);
        Task<bool> DeleteModelByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
