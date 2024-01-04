using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public Flags Flag { get; set; }
        public bool IsResolved { get; set; } = false;
        public Location Location { get; set; }
        public int? ImageId { get; set; }
        public ImageDto? Image { get; set; }
    }
}
