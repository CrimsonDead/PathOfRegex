using PathOfRegexDB.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PathOfRegexDB.Models
{
    public class Affix
    {
        [Key]
        public Guid Id { get; set; }

        [Required, NotNull]
        public required string Name { get; set; }

        [Required, NotNull]
        public required string Description { get; set; }

        [Required, NotNull]
        public AffixType AffixType { get; set; }

        [Required, NotNull]
        [ForeignKey("ItemTypeMaster")]
        public required ItemTypeMaster ItemType { get; set; }

        public string? Alias { get; set; }
    }
}
