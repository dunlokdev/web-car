using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApi.WebApi.Models.Cars
{
    public class CarEditModel
    {
        public int Id { get; set; } = 0;

        [DisplayName("Tên xe")]
        [Required(ErrorMessage = "Tên xe không được bỏ trống")]
        [MaxLength(250, ErrorMessage = "Tên xe tối đa 250 ký tự")]
        public string Name { get; set; }

        [DisplayName("Dòng xe")]
        [Required(ErrorMessage = "Dòng xe không được để trống")]
        public int ModelId { get; set; }

        [DisplayName("Giá bán")]
        [Required(ErrorMessage = "Giá bán không được để trống")]
        public double Price { get; set; }

        [DisplayName("Discount")]
        public int Discount { get; set; }

        [DisplayName("Hình ảnh hiện tại")]
        public string Thumbnail { get; set; } = "";

        [DisplayName("Chọn hình ảnh")]
        public IFormFile ImageFile { get; set; }

        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Mô tả không được để trống")]
        [MaxLength(2000, ErrorMessage = "Mô tả tối đa 2000 ký tự")]
        public string ShortDescripton { get; set; }

        [DisplayName("Chi tiết")]
        [Required(ErrorMessage = "Chi tiết không được để trống")]
        [MaxLength(5000, ErrorMessage = "Chi tiết tối đa 5000 ký tự")]
        public string Description { get; set; }

        [DisplayName("Hiển thị")]
        public bool IsActived { get; set; } = true;


        [DisplayName("Công xuất")]
        [Required(ErrorMessage = "Giá trị công xuất không được để trống")]
        public int Wattage { get; set; }

        [DisplayName("Mô men xoắn")]
        [Required(ErrorMessage = "Giá trị mô men xoắn không được để trống")]
        public int Torque { get; set; }

        [DisplayName("Tăng tốc từ 0 đến 100km/h")]
        [Required(ErrorMessage = "Giá trị tăng tốc không được để trống")]
        public double SpeedUp { get; set; }

        [DisplayName("Tốc độ tối đa")]
        [Required(ErrorMessage = "Giá trị tốc độ tối đa không được để trống")]
        public int MaxSpeed { get; set; } = 0;

        [DisplayName("Lượng nhiên liệu tiêu thụ")]
        public double Consume { get; set; } = 0;

        [DisplayName("Lượng khí thải")]
        public int Emission { get; set; } = 0;

        [DisplayName("Đánh giá")]
        public int Evaluate { get; set; } = 0;

        public static async ValueTask<CarEditModel> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();

            var model = new CarEditModel();
            //- ID
            //- ModelID
            //- Name
            //- Price (\*)
            //- Discount
            //- Thumbnail
            //- ShortDescripton
            //- Description
            //- UrlSlug
            //- IsActived
            //- Wattage: Công xuất (\*)
            //- Torque: Mô men xoắn (\*)
            //- SpeedUp: Tăng tốc từ 0 - 100km (0 - 62 dặm) (\*)
            //- MaxSpeed: Tốc độ tối đa (\*)
            //- Consume: Lượng tiêu thụ
            //- Emissions: Lượng khí thải
            //- Evaluate: Đánh giá

            if (form.Files["imageFile"] != null)
            {
                model.ImageFile = form.Files["imageFile"];
            }

            model.Id = int.Parse(form["id"]);
            model.ModelId = int.Parse(form["modelId"]);
            model.Name = form["name"];
            model.Price = double.Parse(form["price"]);
            model.Discount = int.Parse(form["discount"]);
            model.ShortDescripton = form["shortDescripton"];
            model.Description = form["description"];
            model.IsActived = form["isActived"] != "false";
            model.Wattage = int.Parse(form["wattage"]);
            model.Torque = int.Parse(form["torque"]);
            model.SpeedUp = double.Parse(form["speedUp"]);
            model.MaxSpeed = int.Parse(form["maxSpeed"]);
            model.Consume = double.Parse(form["consume"]);
            model.Emission = int.Parse(form["emission"]);
            model.Evaluate = int.Parse(form["evaluate"]);

            return model;
        }
    }
}
