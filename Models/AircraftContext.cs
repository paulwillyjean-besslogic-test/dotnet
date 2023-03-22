using Microsoft.EntityFrameworkCore;

namespace app.Models;

public class AircraftContext: DbContext
{
    public AircraftContext(DbContextOptions<AircraftContext> options)
        : base(options)
        {}

    public DbSet<Aircraft> Aircrafts => Set<Aircraft>();
}