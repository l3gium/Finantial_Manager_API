using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Finantial_Manager_API.Models
{
    public enum BudgetPeriod
    {
        Weekly,
        Monthly,
        Yearly
    }

    public enum BudgetStatus
    {
        Active,
        Paused,
        Exceeded,
        Completed
    }

    public class BudgetCategory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid BudgetId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? CategoryLimit { get; set; } // Limite específico para esta categoria dentro do orçamento (opcional)

        [JsonIgnore]
        public Budget Budget { get; set; } = null;
        
        public Category Category { get; set; } = null;
    }

    public class Budget
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal LimitAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SpentAmount { get; set; } = 0;

        [NotMapped]
        public decimal RemainingAmount => LimitAmount - SpentAmount;

        [NotMapped]
        public decimal SpentPorcentage => LimitAmount > 0
            ? Math.Round((SpentAmount / LimitAmount) * 100, 2)
            : 0;

        [NotMapped]
        public bool IsExceeded => SpentAmount > LimitAmount;

        [Required]
        public BudgetPeriod Period { get; set; } = BudgetPeriod.Monthly;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public bool RollsOver { get; set; } = false; // Se true, o orçamento não utilizado no período atual é adicionado ao próximo período

        [Range(0, 100)]
        public int AlertThresholdPercenage { get; set; } = 80; // Percentual para disparar alerta de gasto próximo do limite

        public BudgetStatus Status { get; set; } = BudgetStatus.Active;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; } = null;

        [JsonIgnore]
        public ICollection<BudgetCategory> BudgetCategories { get; set; } = new List<BudgetCategory>();
    }
}
