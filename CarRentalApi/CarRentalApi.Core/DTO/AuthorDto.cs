﻿
namespace CarRentalApi.Core.DTO
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UrlSlug { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public DateTime JoinedDate { get; set; }
        public int PostCount { get; set; }
    }
}
