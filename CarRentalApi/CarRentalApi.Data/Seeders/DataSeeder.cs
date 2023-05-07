using Azure;
using CarRentalApi.Core.Entities;
using CarRentalApi.Data.Contexts;
using Microsoft.EntityFrameworkCore;
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
            var author = AddAuthors();
            var posts = AddPosts(author);
        }

        private IList<Post> AddPosts(IList<Author> authors)
        {
            var posts = new List<Post>() {
                new() {
                    Title = "His mother had always taught him",
                    ShortDescription = "His mother had always taught him not to ever think of himself as better than others.",
                    Description = "His mother had always taught him not to ever think of himself as better than others. He'd tried to live by this motto. He never looked down on those who were less fortunate or who had less money than him. But the stupidity of the group of people he was talking to made him change his mind.",
                    Meta = "post-01",
                    UrlSlug = "his-mother-had-always-taught-him",
                    Published = true,
                    PostedDate = new DateTime(2023, 2, 22, 1, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 2,
                    Author = authors[0],
                },
                new() {
                    Title = "He was an expert but not in a discipline",
                    ShortDescription = "He was an expert but not in a discipline that anyone could fully appreciate.",
                    Description = "He was an expert but not in a discipline that anyone could fully appreciate. He knew how to hold the cone just right so that the soft server ice-cream fell into it at the precise angle to form a perfect cone each and every time. It had taken years to perfect and he could now do it without even putting any thought behind it.",
                    Meta = "post-02",
                    UrlSlug = "he-was-an-expert-but-not-in-a-discipline",
                    Published = true,
                    PostedDate = new DateTime(2022, 12, 1, 7, 6, 0),
                    ModifiedDate = null,
                    ViewCount = 2,
                    Author = authors[2],
                },
                new() {
                    Title = "Dave watched as the forest burned up on the hill",
                    ShortDescription = "Dave watched as the forest burned up on the hill.",
                    Description = "Dave watched as the forest burned up on the hill, only a few miles from her house. The car had been hastily packed and Marta was inside trying to round up the last of the pets. Dave went through his mental list of the most important papers and documents that they couldn't leave behind. He scolded himself for not having prepared these better in advance and hoped that he had remembered everything that was needed. He continued to wait for Marta to appear with the pets, but she still was nowhere to be seen.",
                    Meta = "post-03",
                    UrlSlug = "dave-watched-as-the-forest-burned-up-on-the-hill",
                    Published = true,
                    PostedDate = new DateTime(2023, 1, 26, 6, 1, 0),
                    ModifiedDate = null,
                    ViewCount = 5,
                    Author = authors[3],
                },
                new() {
                    Title = "All he wanted was a candy bar.",
                    ShortDescription = "All he wanted was a candy bar.",
                    Description = "All he wanted was a candy bar. It didn't seem like a difficult request to comprehend, but the clerk remained frozen and didn't seem to want to honor the request. It might have had something to do with the gun pointed at his face.",
                    Meta = "post-04",
                    UrlSlug = "all-he-wanted-was-a-candy-bar",
                    Published = true,
                    PostedDate = new DateTime(2022, 11, 1, 6, 32, 0),
                    ModifiedDate = null,
                    ViewCount = 1,
                    Author = authors[3],
                },
                new() {
                    Title = "Hopes and dreams were dashed that day",
                    ShortDescription = "Hopes and dreams were dashed that day.",
                    Description = "Hopes and dreams were dashed that day. It should have been expected, but it still came as a shock. The warning signs had been ignored in favor of the possibility, however remote, that it could actually happen. That possibility had grown from hope to an undeniable belief it must be destiny. That was until it wasn't and the hopes and dreams came crashing down.",
                    Meta = "post-05",
                    UrlSlug = "hopes-and-dreams-were-dashed-that-day",
                    Published = true,
                    PostedDate = new DateTime(2022, 10, 7, 7, 53, 0),
                    ModifiedDate = null,
                    ViewCount = 2,
                    Author = authors[1],
                },
                new() {
                    Title = "Dave wasn't exactly sure how he had ended up in this predicament",
                    ShortDescription = "Dave wasn't exactly sure how he had ended up in this predicament.",
                    Description = "Dave wasn't exactly sure how he had ended up in this predicament. He ran through all the events that had lead to this current situation and it still didn't make sense. He wanted to spend some time to try and make sense of it all, but he had higher priorities at the moment. The first was how to get out of his current situation of being naked in a tree with snow falling all around and no way for him to get down.",
                    Meta = "post-06",
                    UrlSlug = "dave-wasnt-exactly-sure-how-he-had-ended-up-in-this-predicament",
                    Published = true,
                    PostedDate = new DateTime(2022, 4, 30, 8, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 3,
                    Author = authors[4],
                },
                new() {
                    Title = "This is important to remember",
                    ShortDescription = "This is important to remember.",
                    Description = "This is important to remember. Love isn't like pie. You don't need to divide it among all your friends and loved ones. No matter how much love you give, you can always give more. It doesn't run out, so don't try to hold back giving it as if it may one day run out. Give it freely and as much as you want.",
                    Meta = "post-07",
                    UrlSlug = "this-is-important-to-remember",
                    Published = true,
                    PostedDate = new DateTime(2022, 12, 1, 3, 8, 0),
                    ModifiedDate = null,
                    ViewCount = 8,
                    Author = authors[4],
                },
                new() {
                    Title = "One can cook on and with an open fire",
                    ShortDescription = "One can cook on and with an open fire.",
                    Description = "One can cook on and with an open fire. These are some of the ways to cook with fire outside. Cooking meat using a spit is a great way to evenly cook meat. In order to keep meat from burning, it's best to slowly rotate it.",
                    Meta = "post-08",
                    UrlSlug = "one-can-cook-on-and-with-an-open-fire",
                    Published = true,
                    PostedDate = new DateTime(2023, 2, 22, 2, 12, 0),
                    ModifiedDate = null,
                    ViewCount = 9,
                    Author = authors[1],
                },
                new() {
                    Title = "There are different types of secrets",
                    ShortDescription = "There are different types of secrets.",
                    Description = "There are different types of secrets. She had held onto plenty of them during her life, but this one was different. She found herself holding onto the worst type. It was the type of secret that could gnaw away at your insides if you didn't tell someone about it, but it could end up getting you killed if you did.",
                    Meta = "post-09",
                    UrlSlug = "there-are-different-types-of-secrets",
                    Published = true,
                    PostedDate = new DateTime(2022, 11, 8, 12, 2, 0),
                    ModifiedDate = null,
                    ViewCount = 2,
                    Author = authors[3],
                },
                new() {
                    Title = "They rushed out the door",
                    ShortDescription = "They rushed out the door, grabbing anything and everything they could think of they might need.",
                    Description = "They rushed out the door, grabbing anything and everything they could think of they might need. There was no time to double-check to make sure they weren't leaving something important behind. Everything was thrown into the car and they sped off. Thirty minutes later they were safe and that was when it dawned on them that they had forgotten the most important thing of all.",
                    Meta = "post-10",
                    UrlSlug = "they-rushed-out-the-door",
                    Published = true,
                    PostedDate = new DateTime(2022, 6, 7, 8, 9, 0),
                    ModifiedDate = null,
                    ViewCount = 4,
                    Author = authors[2],
                }
            };

            _context.Posts.AddRange(posts);
            _context.SaveChanges();

            return posts;
        }

        private IList<Author> AddAuthors()
        {
            var authors = new List<Author>() {
                new() {
                    FullName = "Jason Mouth",
                    UrlSlug = "json-mouth",
                    Email = "json@gmail.com",
                    JoinedDate = new DateTime(2022, 10, 21)
                },
                new() {
                    FullName = "Jessica Wonder",
                    UrlSlug = "jessica-wonder",
                    Email = "jessica665@motip.com",
                    JoinedDate = new DateTime(2020, 4, 19)
                },
                new() {
                    FullName = "Leanne Graham",
                    UrlSlug = "leanne-graham",
                    Email = "leanne@gmail.com",
                    JoinedDate = new DateTime(2022, 12, 1)
                },
                new() {
                    FullName = "Ervin Howell",
                    UrlSlug = "ervin-howell",
                    Email = "ervin@gmail.com",
                    JoinedDate = new DateTime(2023, 1, 22)
                },
                new() {
                    FullName = "Clementine Bauch",
                    UrlSlug = "clementine-bauch",
                    Email = "clementine@gmail.com",
                    JoinedDate = new DateTime(2022, 11, 23)
                },
                new() {
                    FullName = "Patricia Lebsack",
                    UrlSlug = "patricia-lebsack",
                    Email = "patricia@gmail.com",
                    JoinedDate = new DateTime(2021, 7, 8)
                },
                new() {
                    FullName = "Chelsey Dietrich",
                    UrlSlug = "chelsey-dietrich",
                    Email = "chelsey@gmail.com",
                    JoinedDate = new DateTime(2022, 3, 14)
                }
            };

            _context.Authors.AddRange(authors);
            _context.SaveChanges();

            return authors;
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
                    Thumbnail = "https://localhost:7044/uploads/pictures/thumbnails/car-1.png",
                    ShortDescripton = "4,9 giây (4,7 giây với Gói Sport Chrono)",
                    Description = "Giá tiêu chuẩn bao gồm thuế nhập khẩu, thuế tiêu thụ đặc biệt và thuế giá trị gia tăng. Đối với dòng xe Panamera, Cayenne, Macan và Taycan giá tiêu chuẩn bao gồm thêm gói dịch vụ 4 năm bảo dưỡng. Bảng giá, thông số kỹ thuật và hình ảnh có thể thay đổi theo từng thời điểm mà không báo trước.",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Wattage = 300,
                    Torque = 380,
                    SpeedUp = 4.9,
                    MaxSpeed = 275,
                    Evaluate = 276,
                    Model = models[0]
                },
                new()
                {
                    Name = "718 Cayman Style Edition",
                    UrlSlug = "718-cayman-style-edition",
                    Price = 4180000000,
                    Discount = 0,
                    Thumbnail = "https://localhost:7044/uploads/pictures/thumbnails/car-2.png",
                    ShortDescripton = "4,9 giây (4,7 giây với Gói Sport Chrono)",
                    Description = "Giá tiêu chuẩn bao gồm thuế nhập khẩu, thuế tiêu thụ đặc biệt và thuế giá trị gia tăng. Đối với dòng xe Panamera, Cayenne, Macan và Taycan giá tiêu chuẩn bao gồm thêm gói dịch vụ 4 năm bảo dưỡng. Bảng giá, thông số kỹ thuật và hình ảnh có thể thay đổi theo từng thời điểm mà không báo trước.",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Wattage = 300,
                    Torque = 380 ,
                    SpeedUp = 4.9,
                    MaxSpeed = 275 ,
                    Consume = 8.1,
                    Emission = 185,
                    Evaluate = 300,
                    Model = models[0]
                },
                new()
                {
                    Name = "718 Cayman T",
                    UrlSlug = "718-cayman-t",
                    Price = 4090000000,
                    Discount = 15,
                    Thumbnail = "https://localhost:7044/uploads/pictures/thumbnails/car-3.png",
                    ShortDescripton = "4,9 giây (4,7 giây với Gói Sport Chrono)",
                    Description = "Giá tiêu chuẩn bao gồm thuế nhập khẩu, thuế tiêu thụ đặc biệt và thuế giá trị gia tăng. Đối với dòng xe Panamera, Cayenne, Macan và Taycan giá tiêu chuẩn bao gồm thêm gói dịch vụ 4 năm bảo dưỡng. Bảng giá, thông số kỹ thuật và hình ảnh có thể thay đổi theo từng thời điểm mà không báo trước.",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Wattage = 300,
                    Torque = 380,
                    SpeedUp = 4.9,
                    MaxSpeed = 275,
                    Evaluate = 276,
                    Model = models[0]
                },
                new()
                {
                    Name = "718 Cayman S",
                    UrlSlug = "718-cayman-S",
                    Price = 4510000000,
                    Discount = 15,
                    Thumbnail = "https://localhost:7044/uploads/pictures/thumbnails/car-5.png",
                    ShortDescripton = "4,9 giây (4,7 giây với Gói Sport Chrono)",
                    Description = "Giá tiêu chuẩn bao gồm thuế nhập khẩu, thuế tiêu thụ đặc biệt và thuế giá trị gia tăng. Đối với dòng xe Panamera, Cayenne, Macan và Taycan giá tiêu chuẩn bao gồm thêm gói dịch vụ 4 năm bảo dưỡng. Bảng giá, thông số kỹ thuật và hình ảnh có thể thay đổi theo từng thời điểm mà không báo trước.",
                    CreatedAt = new DateTime(2023, 4, 27),
                    Wattage = 300,
                    Torque = 380,
                    SpeedUp = 4.9,
                    MaxSpeed = 275,
                    Evaluate = 276,
                    Model = models[0]
                },
                new()
                {
                    Name = "718 Boxster",
                    UrlSlug = "718-boxster",
                    Price = 3740000000,
                    Discount = 10,
                    Thumbnail = "https://localhost:7044/uploads/pictures/thumbnails/car-4.png",
                    ShortDescripton = "4,9 giây (4,7 giây với Gói Sport Chrono)",
                    Description = "Giá tiêu chuẩn bao gồm thuế nhập khẩu, thuế tiêu thụ đặc biệt và thuế giá trị gia tăng. Đối với dòng xe Panamera, Cayenne, Macan và Taycan giá tiêu chuẩn bao gồm thêm gói dịch vụ 4 năm bảo dưỡng. Bảng giá, thông số kỹ thuật và hình ảnh có thể thay đổi theo từng thời điểm mà không báo trước.",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Wattage = 300,
                    Torque = 380,
                    SpeedUp = 4.9,
                    MaxSpeed = 275,
                    Evaluate = 276,
                    Model = models[0]
                },
                new()
                {
                    Name = "718 Boxster Style Edition",
                    UrlSlug = "718-boxster-style-edition",
                    Price = 4320000000,
                    Discount = 10,
                    Thumbnail = "https://localhost:7044/uploads/pictures/thumbnails/car-1.png",
                    ShortDescripton = "4,9 giây (4,7 giây với Gói Sport Chrono)",
                    Description = "Giá tiêu chuẩn bao gồm thuế nhập khẩu, thuế tiêu thụ đặc biệt và thuế giá trị gia tăng. Đối với dòng xe Panamera, Cayenne, Macan và Taycan giá tiêu chuẩn bao gồm thêm gói dịch vụ 4 năm bảo dưỡng. Bảng giá, thông số kỹ thuật và hình ảnh có thể thay đổi theo từng thời điểm mà không báo trước.",
                    CreatedAt = new DateTime(2023, 11, 1),
                    Wattage = 300,
                    Torque = 380,
                    SpeedUp = 4.9,
                    MaxSpeed = 275,
                    Evaluate = 276,
                    Model = models[0]
                },
                new()
                {
                    Name = "911 Carrera",
                    UrlSlug = "911-carrera",
                    Price = 7130000000,
                    Discount = 20,
                    Thumbnail = "https://localhost:7044/uploads/pictures/thumbnails/car-5.png",
                    ShortDescripton = "4,2 giây (Tăng tốc từ 0 - 100 km/giờ)",
                    Description = "Giá tiêu chuẩn bao gồm thuế nhập khẩu, thuế tiêu thụ đặc biệt và thuế giá trị gia tăng. Đối với dòng xe Panamera, Cayenne, Macan và Taycan giá tiêu chuẩn bao gồm thêm gói dịch vụ 4 năm bảo dưỡng. Bảng giá, thông số kỹ thuật và hình ảnh có thể thay đổi theo từng thời điểm mà không báo trước.",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Wattage = 283,
                    Torque = 450 ,
                    SpeedUp = 4.2,
                    MaxSpeed = 293,
                    Evaluate = 112,
                    Model = models[1]
                },
                new()
                {
                    Name = "911 Carrera T",
                    UrlSlug = "911-carrera-t",
                    Price = 8230000000,
                    Discount = 10,
                    Thumbnail = "https://localhost:7044/uploads/pictures/thumbnails/car-6.png",
                    ShortDescripton = "4,2 giây (Tăng tốc từ 0 - 100 km/giờ)",
                    Description = "Giá tiêu chuẩn bao gồm thuế nhập khẩu, thuế tiêu thụ đặc biệt và thuế giá trị gia tăng. Đối với dòng xe Panamera, Cayenne, Macan và Taycan giá tiêu chuẩn bao gồm thêm gói dịch vụ 4 năm bảo dưỡng. Bảng giá, thông số kỹ thuật và hình ảnh có thể thay đổi theo từng thời điểm mà không báo trước.",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Wattage = 285,
                    Torque = 450 ,
                    SpeedUp = 4,
                    MaxSpeed = 291,
                    Consume = 9.5,
                    Emission = 217,
                    Evaluate = 112,
                    Model = models[1]
                },
                new()
                {
                    Name = "911 Carrera Cabriolet",
                    UrlSlug = "911-carrera-cabriolet",
                    Price = 8010000000,
                    Discount = 25,
                    Thumbnail = "https://localhost:7044/uploads/pictures/thumbnails/car-3.png",
                    ShortDescripton = "4,2 giây (Tăng tốc từ 0 - 100 km/giờ)",
                    Description = "Giá tiêu chuẩn bao gồm thuế nhập khẩu, thuế tiêu thụ đặc biệt và thuế giá trị gia tăng. Đối với dòng xe Panamera, Cayenne, Macan và Taycan giá tiêu chuẩn bao gồm thêm gói dịch vụ 4 năm bảo dưỡng. Bảng giá, thông số kỹ thuật và hình ảnh có thể thay đổi theo từng thời điểm mà không báo trước.",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Wattage = 285,
                    Torque = 450 ,
                    SpeedUp = 4,
                    MaxSpeed = 291,
                    Consume = 9.5,
                    Emission = 217,
                    Evaluate = 112,
                    Model = models[1]
                },
                new()
                {
                    Name = "Taycan",
                    UrlSlug = "taycan",
                    Price = 4170000000,
                    Discount = 10,
                    Thumbnail = "https://localhost:7044/uploads/pictures/thumbnails/car-7.png",
                    ShortDescripton = "5,4 giây tăng tốc từ 0 - 100 km/giờ",
                    Description = "Taycan mang hiệu suất trứ danh không gì thay thế được. Với công nghệ truyền động tiên tiến nhất, công suất đỉnh cao luôn sẵn sàng: hai động cơ đồng bộ sử dụng nam châm vĩnh cửu (PSMs) sản sinh công suất lên đến 560kW (761 PS) trên Taycan Turbo S giúp mẫu xe tăng tốc từ 0-100 km/giờ chỉ trong 2,8 giây khi kết hợp với Launch Control.",
                    CreatedAt = new DateTime(2023, 10, 21),
                    Wattage = 408,
                    Torque = 357,
                    SpeedUp = 5.4,
                    MaxSpeed = 230,
                    Evaluate = 150,
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
                    Thumbnail = "https://localhost:7044/uploads/pictures/galeries/718-1.png",
                    Car = cars[0]
                },
                new()
                {
                    Thumbnail = "https://localhost:7044/uploads/pictures/galeries/718-2.png",
                    Car = cars[0]
                },
                new()
                {
                    Thumbnail = "https://localhost:7044/uploads/pictures/galeries/718-3.png",
                    Car = cars[0]
                },
                new()
                {
                    Thumbnail = "https://localhost:7044/uploads/pictures/galeries/718-4.png",
                    Car = cars[0]
                },
                new()
                {
                    Thumbnail = "https://localhost:7044/uploads/pictures/galeries/718-5.png",
                    Car = cars[0]
                },
                new()
                {
                    Thumbnail = "https://localhost:7044/uploads/pictures/galeries/718-6.png",
                    Car = cars[0]
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
                    Thumbnail = "https://localhost:7044/uploads/pictures/models/718.png"
                 },
                 new() {
                    Name = "911",
                    UrlSlug = "911",
                    Thumbnail = "https://localhost:7044/uploads/pictures/models/911.png"

                 },
                 new() {
                    Name = "Taycan",
                    UrlSlug = "taycan",
                    Thumbnail = "https://localhost:7044/uploads/pictures/models/taycan.png"
                 },
                 new() {
                    Name = "Panamera",
                    UrlSlug = "panamera",
                    Thumbnail = "https://localhost:7044/uploads/pictures/models/panamera.png"
                 },
                 new() {
                    Name = "Macan",
                    UrlSlug = "macan",
                    Thumbnail = "https://localhost:7044/uploads/pictures/models/macan.png"
                 },
                 new() {
                    Name = "Cayenne",
                    UrlSlug = "cayenne",
                    Thumbnail = "https://localhost:7044/uploads/pictures/models/cayenne.png"
                 },
            };

            _context.AddRange(models);
            _context.SaveChanges();

            return models;
        }
    }
}
