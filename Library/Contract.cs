using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Booking
{
    public class Contract
    {
        
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        [DataType(DataType.Text)]
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string FullName { get; set; }
        [BsonElement("phone")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Số điện thoại không chính xác")]
        public string PhoneNumber { get; set; }
        [BsonElement("email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email không chính xác")]
        public string Email { get; set; }
        public Contract()
        {
        }
    }
}
