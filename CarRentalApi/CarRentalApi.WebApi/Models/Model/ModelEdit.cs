using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApi.WebApi.Models.Model
{
    public class ModelEdit
    {
        public int Id { get; set; } = 0;

        [DisplayName("Tên dòng xe")]
        [Required(ErrorMessage = "Tên dòng xe không được bỏ trống")]
        [MaxLength(250, ErrorMessage = "Tên xe tối đa 250 ký tự")]
        public string Name { get; set; }

        [DisplayName("Hình ảnh hiện tại")]
        public string Thumbnail { get; set; } = "";

        [DisplayName("Chọn hình ảnh")]
        public IFormFile ImageFile { get; set; }

        public static async ValueTask<ModelEdit> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();

            var model = new ModelEdit();

            if (form.Files["imageFile"] != null)
            {
                model.ImageFile = form.Files["imageFile"];
            }
            model.Id = int.Parse(form["id"]);
            model.Name = form["name"];
            return model;
        }
    }
}
