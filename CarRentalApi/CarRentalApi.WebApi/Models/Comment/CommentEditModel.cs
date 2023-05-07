using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApi.WebApi.Models.Comment
{
    public class CommentEditModel
    {
        [DisplayName("Tên")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [DisplayName("Tên")]
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(250, ErrorMessage = "Tên xe tối đa 250 ký tự")]
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public int CarId { get; set; }
    }
}
