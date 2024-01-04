using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs
{
    public class ImageDto
    {
        // ImageDto contains image representation as Base64 string.
        // Will be converted to byte array for Item model.
        public int Id { get; set; }
        [MaxLength(255)]
        public string FileName { get; set; }
        public string DataBase64 { get; set; }
    }
}
