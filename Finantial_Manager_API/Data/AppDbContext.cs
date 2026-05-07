using Finantial_Manager_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Finantial_Manager_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetCategory> BudgetCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //---------------User---------------------------
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique(); //sem repetição de email

                entity.HasMany(u => u.Transactions)
                      .WithOne(t => t.User)
                      .HasForeignKey(t => t.UserId)
                      .OnDelete(DeleteBehavior.Cascade); // Deleta transações quando o usuário é deletado

                entity.HasMany(u => u.Categories)
                      .WithOne(c => c.User)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.Cascade); // Deleta categorias quando o usuário é deletado
            });

            //-------------Transaction---------------------------
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasOne(t => t.Category)
                      .WithMany(c => c.Transactions)
                      .HasForeignKey(t => t.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict); // Impede deleção de categoria se houver transações associadas
            });

            //-------------Category (self-referencing) -----------
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasOne(c => c.ParentCategory)
                      .WithMany(c => c.SubCategories)
                      .HasForeignKey(c => c.ParentCategoryId)
                      .OnDelete(DeleteBehavior.Restrict); // Impede deleção de categoria pai se houver subcategorias associadas 
            });

            //-------------BudgetCategory (join table) -----------
            modelBuilder.Entity<BudgetCategory>(entity =>
            {
                entity.HasOne(bc => bc.Budget)
                      .WithMany(b => b.BudgetCategories)
                      .HasForeignKey(bc => bc.BudgetId)
                      .OnDelete(DeleteBehavior.Cascade); // Deleta associações quando o orçamento é deletado

                entity.HasOne(bc => bc.Category)
                      .WithMany()
                      .HasForeignKey(bc => bc.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict); // Impede deleção de categoria se houver associações com orçamentos
            });

            //----------Globel default categories seed -----------------
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = Guid.NewGuid(), Name = "Salary", Icon = "briefcase", Color = "#22C55E", Type = CategoryType.Income, IsDefault = true },
                new Category { Id = Guid.NewGuid(), Name = "Freelance", Icon = "laptop", Color = "#3B82F6", Type = CategoryType.Income, IsDefault = true },
                new Category { Id = Guid.NewGuid(), Name = "Food", Icon = "utensils", Color = "#F97316", Type = CategoryType.Expense, IsDefault = true },
                new Category { Id = Guid.NewGuid(), Name = "Transport", Icon = "car", Color = "#8B5CF6", Type = CategoryType.Expense, IsDefault = true },
                new Category { Id = Guid.NewGuid(), Name = "Bills", Icon = "file-text", Color = "#EF4444", Type = CategoryType.Expense, IsDefault = true },
                new Category { Id = Guid.NewGuid(), Name = "Health", Icon = "heart-pulse", Color = "#EC4899", Type = CategoryType.Expense, IsDefault = true },
                new Category { Id = Guid.NewGuid(), Name = "Education", Icon = "book-open", Color = "#14B8A6", Type = CategoryType.Expense, IsDefault = true },
                new Category { Id = Guid.NewGuid(), Name = "Leisure", Icon = "gamepad-2", Color = "#F59E0B", Type = CategoryType.Expense, IsDefault = true }
            );
        }
    }
}
