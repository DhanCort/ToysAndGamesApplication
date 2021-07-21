using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToysAndGames.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0,100)]
        public int AgeRestriction { get; set; }
        public string Company { get; set; }
        [Column(TypeName ="decimal(19,4)")]
        public decimal Price { get; set; }
        public int ProductTypeId { get; set; }

        //Navigation Properties
        public ProductType ProductType { get; set; }

    }
}
