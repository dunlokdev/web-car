using Microsoft.OpenApi.Attributes;
using System.ComponentModel;

namespace CarRentalApi.WebApi.Models.Cars
{
    public class CarFilterModel
    {
        [DisplayName("Từ khoá")]
        public string Keyword { get; set; } = "";

        [DisplayName("Mẫu xe")]
        public int? ModelId { get; set; }

        [DisplayName("Tên xe")]
        public string Name { get; set; } = "";

        [DisplayName("Giá xe")]
        public double? Price { get; set; }

        [DisplayName("Mô tả")]
        public string Description { get; set; } = "";

        [DisplayName("Actived")]
        public bool? IsActived { get; set; }
    }
}
