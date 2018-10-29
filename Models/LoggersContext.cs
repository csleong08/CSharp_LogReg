using Microsoft.EntityFrameworkCore;

namespace LogReg.Models
{
    public class LoggersContext : DbContext
    {
        public DbSet<Loggers> loggers { get; set; } // always make users lowercase

        // base() calls the parent class' constructor passing the "options" parameter along
        public LoggersContext(DbContextOptions<LoggersContext> options) : base(options) { }
    }
}