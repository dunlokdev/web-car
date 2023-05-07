using CarRentalApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApi.Core.Entities
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
        public bool IsApproved { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
