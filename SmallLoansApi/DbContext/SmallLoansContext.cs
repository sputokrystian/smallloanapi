using Microsoft.EntityFrameworkCore;
using SmallLoansApi.Models;

namespace SmallLoansApi.Repositories
{
    public class SmallLoansContext : DbContext
    {
        public SmallLoansContext(DbContextOptions<SmallLoansContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
                        .HasOne(m => m.Lender)
                        .WithMany(m => m.LendedLoans)
                        .HasForeignKey(m => m.LenderId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
                        .HasOne(m => m.Borrower)
                        .WithMany(m => m.BorrowedLoans)
                        .HasForeignKey(m => m.BorrowerId)
                        .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}