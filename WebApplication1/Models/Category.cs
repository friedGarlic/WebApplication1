using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        public DateTime DateTime { set; get; } = DateTime.Now;
    }
}
