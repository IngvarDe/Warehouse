using System;
using System.Collections.Generic;


namespace Warehouse.Core.Dtos
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public IEnumerable<LocationDto> Location { get; set; }
        public DimensionDto Dimension { get; set; }

        public IEnumerable<FileDto> File { get; set; } = new List<FileDto>();
    }
}
