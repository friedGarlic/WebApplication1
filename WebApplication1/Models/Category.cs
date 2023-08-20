using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        [Required]
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime DateTime { set; get; } = DateTime.Now;
    }
}
