using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Finantial_Manager_API.Models
{
    public enum CategoryType
    {
        Income,
        Expense, 
        Both
    }

    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? Description { get; set; }

        [Required, MaxLength(50)]
        public string Icon { get; set; } = "tag";

        [Required, MaxLength(7)]
        [RegularExpression("^#[A-Fa-f0-9]{6}$", ErrorMessage = "Color must be a valid hex code (e.g. # FF5733)")]
        public string Color { get; set; } = "#000000";

        [Required]
        public CategoryType Type { get; set; }

        public bool IsDefault { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Referência à categoria pai das subcategorias (ex. Food -> Restaurants -> Groceries)
        public Guid? ParentCategoryId { get; set; }

        [JsonIgnore]
        public Category? ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; } = new List<Category>();

        public Guid? UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

        [JsonIgnore]
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
