using CarRentalApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApi.Core.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Status { get; set; }
        public double TotalMoney { get; set; }
        public User User { get; set; } = null;
        public IList<OrderDetails> OrderDetails { get; set; }
    }
}
