﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApi.Core.DTO
{
    public class PostQuery
    {
        public int? AuthorId { get; set; }
        public string TitleSlug { get; set; }
        public string AuthorSlug { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public bool PublishedOnly { get; set; } = true;
        public bool NotPublished { get; set; } = false;
        public string KeyWord { get; set; }
    }
}
