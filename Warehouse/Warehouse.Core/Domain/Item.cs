using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Warehouse.Core.Domain
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }


        public IEnumerable<Location> Location = new List<Location>();
        public Dimension Dimension { get; set; }
        public IEnumerable<File> File { get; set; } = new List<File>();
        public User User { get; set; }
    }
}
