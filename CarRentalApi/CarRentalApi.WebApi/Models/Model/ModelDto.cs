using CarRentalApi.Core.Entities;
using CarRentalApi.WebApi.Models;

namespace CarRentalApi.WebApi.Models.Model
{
    public class ModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
    }
}
