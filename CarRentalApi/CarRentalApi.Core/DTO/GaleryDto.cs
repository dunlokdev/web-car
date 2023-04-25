using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApi.Core.DTO
{
    public class GaleryDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Thumbnail { get; set; }
    }
}
