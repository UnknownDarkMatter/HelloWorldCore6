using System.ComponentModel.DataAnnotations;

namespace HelloWorldCore6.Entities
{
    public class MessageEntities
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
    }
}