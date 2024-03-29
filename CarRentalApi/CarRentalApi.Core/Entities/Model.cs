﻿using CarRentalApi.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApi.Core.Entities
{
    public class Model : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Thumbnail { get; set; }
        public IList<Car> CarList { get; set; }
    }
}
