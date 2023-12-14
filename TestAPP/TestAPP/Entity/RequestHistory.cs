using System.ComponentModel.DataAnnotations;

namespace TestAPP.Entity
{
    public class RequestHistory
    {
        [Key]
        public int Id { get; set; }
        public string IPAddress { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string IPLocation { get; set; }
        public string Organization { get; set; }
        public string PostalCode { get; set; }
        public string TimeZone { get; set; }
        public string Info { get; set; }
        public DateTime TimeOfWriting { get; set; }
    }
}
