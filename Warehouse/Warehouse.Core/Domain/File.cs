using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Core.Domain
{
    public class File
    {
        [Key]
        public Guid Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? ItemId { get; set; }
    }
}
