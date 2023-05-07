using CarRentalApi.WebApi.Models.Comment;
using FluentValidation;

namespace CarRentalApi.WebApi.Validation
{
    public class CommentValidator : AbstractValidator<CommentEditModel>
    {
        public CommentValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage("Nội dung bình luận không được để trống")
                .MaximumLength(200)
                .WithMessage("Nội dung bình luận dài tối đa 200 ký tự");
        }
    }
}
