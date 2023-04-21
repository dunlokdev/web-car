using CarRentalApi.Core.Entities;

namespace CarRentalApi.WebApi.Models.Car
{
    public class CarDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
        public bool IsActived { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Model Model { get; set; }
    }
}
