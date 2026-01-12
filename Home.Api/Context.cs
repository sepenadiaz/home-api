using Microsoft.EntityFrameworkCore;

namespace Home.Api
{
    public partial class Context : DbContext
    {
        public Context() { }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations in the assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CreditCardConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

