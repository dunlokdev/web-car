using CarRentalApi.Core.Entities;
using CarRentalApi.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApi.Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly CarDbContext _context;

        public DataSeeder(CarDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();

            if (_context.Cars.Any())
                return;

            var models = AddModels();
            var cars = AddCars(models);
            var galeries = AddGaleries(cars);
        }

        private IList<Car> AddCars(IList<Model> models)
        {
            var cars = new List<Car>()
            {
                new()
                {
                    Name = "718 Cayman",
                    UrlSlug = "718-cayman",
                    Price = 3620000000,
                    Discount = 20,
                    Thumbnail = "/assets/images/thumbnails/galeries/img-1.png",
                    Description = "4,9 giây (4,7 giây với Gói Sport Chrono)",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Model = models[0]
                },
                new()
                {
                    Name = "718 Cayman Style Edition",
                    UrlSlug = "718-cayman-style-edition",
                    Price = 4180000000,
                    Discount = 0,
                    Thumbnail = "/assets/images/thumbnails/galeries/img-1.png",
                    Description = "4,9 giây (4,7 giây với Gói Sport Chrono)",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Model = models[0]
                },
                new()
                {
                    Name = "718 Cayman T",
                    UrlSlug = "718-cayman-t",
                    Price = 4090000000,
                    Discount = 15,
                    Thumbnail = "/assets/images/thumbnails/galeries/img-1.png",
                    Description = "4,9 giây (4,7 giây với Gói Sport Chrono)",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Model = models[0]
                },
                new()
                {
                    Name = "718 Boxster",
                    UrlSlug = "718-boxster",
                    Price = 3740000000,
                    Discount = 10,
                    Thumbnail = "/assets/images/thumbnails/galeries/img-1.png",
                    Description = "4,9 giây (4,7 giây với Gói Sport Chrono)",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Model = models[0]
                },
                new()
                {
                    Name = "911 Carrera",
                    UrlSlug = "911-carrera",
                    Price = 7130000000,
                    Discount = 20,
                    Thumbnail = "/assets/images/thumbnails/galeries/img-2.png",
                    Description = "4,2 giây (Tăng tốc từ 0 - 100 km/giờ)",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Model = models[1]
                },
                new()
                {
                    Name = "911 Carrera T",
                    UrlSlug = "911-carrera-t",
                    Price = 8230000000,
                    Discount = 10,
                    Thumbnail = "/assets/images/thumbnails/galeries/img-2.png",
                    Description = "4,2 giây (Tăng tốc từ 0 - 100 km/giờ)",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Model = models[1]
                },
                new()
                {
                    Name = "Taycan",
                    UrlSlug = "taycan",
                    Price = 4170000000,
                    Discount = 10,
                    Thumbnail = "/assets/images/thumbnails/galeries/img-3.png",
                    Description = "Taycan mang hiệu suất trứ danh không gì thay thế được. Với công nghệ truyền động tiên tiến nhất, công suất đỉnh cao luôn sẵn sàng: hai động cơ đồng bộ sử dụng nam châm vĩnh cửu (PSMs) sản sinh công suất lên đến 560kW (761 PS) trên Taycan Turbo S giúp mẫu xe tăng tốc từ 0-100 km/giờ chỉ trong 2,8 giây khi kết hợp với Launch Control.",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Model = models[2]
                },

            };

            _context.AddRange(cars);
            _context.SaveChanges();

            return cars;
        }

        private IList<Galery> AddGaleries(IList<Car> cars)
        {
            var galeries = new List<Galery>()
            {
                new()
                {
                    Thumbnail = "/assets/images/thumbnails/galeries/img-1.png",
                    Car = cars[0]
                },
                new()
                {
                    Thumbnail = "/assets/images/thumbnails/galeries/img-2.png",
                    Car = cars[1]
                },
                new()
                {
                    Thumbnail = "/assets/images/thumbnails/galeries/img-3.png",
                    Car = cars[0]
                },
                new()
                {
                    Thumbnail = "/assets/images/thumbnails/galeries/img-4.png",
                    Car = cars[1]
                },

            };
            _context.AddRange(galeries);
            _context.SaveChanges();

            return galeries;

        }

        private IList<Model> AddModels()
        {
            var models = new List<Model>()
            {
                 new() {
                    Name = "718",
                    UrlSlug = "718",
                 },
                 new() {
                    Name = "911",
                    UrlSlug = "911",
                 },
                 new() {
                    Name = "Taycan",
                    UrlSlug = "taycan",
                 },
                 new() {
                    Name = "Panamera",
                    UrlSlug = "panamera",
                 },
                 new() {
                    Name = "Macan",
                    UrlSlug = "macan",
                 },
            };

            _context.AddRange(models);
            _context.SaveChanges();

            return models;
        }
    }
}
