using CarRentalApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApi.Core.Entities
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public string Thumbnail { get; set; }
        public string ShortDescripton { get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
        public bool IsActived { get; set; }
        public int Wattage { get; set; }
        public int Torque { get; set; }
        public double SpeedUp { get; set; }
        public int MaxSpeed { get; set; }
        public double Consume { get; set; }
        public int Emission { get; set; }
        public int Evaluate { get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public IList<Galery> Galery { get; set; }
        public Model Model { get; set; }
        public IList<OrderDetails> OrderDetails { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
