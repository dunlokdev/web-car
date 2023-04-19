using CarRentalApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApi.Core.Entities
{
    public class OrderDetails : IEntity
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }
        public int CarId { get; set; }
        public double Price { get; set; }
        public int Number { get; set; }
        public double TotalMoney { get; set; }
        public Order Order { get; set; }
        public Car Car { get; set; }
    }
}
