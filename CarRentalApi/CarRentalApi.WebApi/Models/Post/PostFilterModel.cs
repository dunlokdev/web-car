using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Globalization;

namespace CarRentalApi.WebApi.Models.Post
{
    public class PostFilterModel
    {
        [DisplayName("Từ khoá")]
        public string Keyword { get; set; }

        [DisplayName("Tác giả")]
        public int? AuthorId { get; set; }

        [DisplayName("Năm")]
        public int? Year { get; set; }

        [DisplayName("Tháng")]
        public int? Month { get; set; }

        public IEnumerable<SelectListItem> AuthorList { get; set; }
        public IEnumerable<SelectListItem> MonthList { get; set; }

        public PostFilterModel()
        {
            MonthList = Enumerable.Range(1, 12)
                .Select(x => new SelectListItem()
                {
                    Value = x.ToString(),
                    Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x)
                }).ToList();
        }

    }
}
