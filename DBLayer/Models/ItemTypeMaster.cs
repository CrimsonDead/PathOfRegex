using System.ComponentModel.DataAnnotations;

namespace PathOfRegexDB.Models
{
    public class ItemTypeMaster
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
