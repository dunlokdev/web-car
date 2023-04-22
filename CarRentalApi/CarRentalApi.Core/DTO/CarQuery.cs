using CarRentalApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApi.Core.DTO
{
    public class CarQuery
    {
        public string Keyword { get; set; }
        public int ModelId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ModelSlug { get; set; }
        public string UrlSlug { get; set; }
        public bool IsActived { get; set; }

    }
}
