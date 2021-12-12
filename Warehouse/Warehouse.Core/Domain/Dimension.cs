using System;
using System.ComponentModel.DataAnnotations;


namespace Warehouse.Core.Domain
{
    public class Dimension
    {
        [Key]
        public Guid Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}
