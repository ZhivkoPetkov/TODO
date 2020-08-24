using System.ComponentModel.DataAnnotations;

namespace TODO.Domains
{
    public class Item
    {
        public Item()
        {
            isFinished = false;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public bool isFinished { get; set; }
    }
}
