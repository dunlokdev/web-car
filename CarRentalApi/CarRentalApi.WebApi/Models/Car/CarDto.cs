using CarRentalApi.Core.Entities;
using CarRentalApi.WebApi.Models;

namespace CarRentalApi.WebApi.Models.Car
{
    public class CarDto
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public string Thumbnail { get; set; }
        public string ShortDescripton{ get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
        public bool IsActived { get; set; }
        public int Wattage { get; set; }
        public int Torque { get; set; }
        public double SpeedUp { get; set; }
        public int MaxSpeed { get; set; }
        public double Consume { get; set; }
        public int Emission { get; set; }
        public int Evaluate { get; set; }
        public string Model { get; set; }
    }
}
