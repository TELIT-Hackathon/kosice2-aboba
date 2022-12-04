using System.ComponentModel.DataAnnotations;

namespace HackThon.Models
{
    public class House
    {
        [Key]
        public int HouseId { get; set; }
        public int HouseSquare { get; set; }
        public string HouseRentType { get; set; }
        public int HouseRoomCount { get; set; }
        public bool HouseAnimalsAgree { get; set; }
        public string HouseName { get; set; }
        public float HousePrice { get; set; }
        public float HouseRentPrice { get; set; }
        public string HouseImg { get; set; }
        public string HouseStreet { get; set; }
        public string HouseNumber { get; set; }
        public string HouseType { get; set; }   
        public string HouseArea { get; set; }
    }
}
