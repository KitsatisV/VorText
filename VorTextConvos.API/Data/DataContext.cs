using Microsoft.EntityFrameworkCore;

namespace VorTextConvos.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}
