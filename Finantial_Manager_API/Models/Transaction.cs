using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System.Text.Json.Serialization;

namespace Finantial_Manager_API.Models
{
    public enum TransactionType
    {
        Income,
        Expense
    }

    public enum PaymentMethod
    {
        Cash,
        CreditCard,
        DebitCard,
        BankTransfer,
        Pix,
        Other
    }

    public enum RecurringInterval
    {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    public class Transaction
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required, MaxLength(255)]
        public string Descriptionn { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Notes { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Pix;

        public bool IsRecurring { get; set; } = false;

        public RecurringInterval RecurringInterval { get; set; }

        public bool IsConfirmed { get; set; } = true;

        public Guid UserId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public Guid? AttachmentId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

        public Category Category { get; set; } = null;

        public Attachment? Atacchment { get; set; }
    }
}
