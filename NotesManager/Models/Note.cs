using System.ComponentModel.DataAnnotations;

namespace NotesManager.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAd { get; set; } = DateTime.UtcNow;
    }
}
