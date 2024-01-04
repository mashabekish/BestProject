using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs
{
    public record ImageDto
    {
        // ImageDto contains image representation as Base64 string.
        // Will be converted to byte array for Item model.
        public int Id { get; set; }
        public string FileName { get; set; }
        public string DataBase64 { get; set; }
    }
}
