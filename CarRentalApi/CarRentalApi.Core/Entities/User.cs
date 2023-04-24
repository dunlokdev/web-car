using CarRentalApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApi.Core.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
