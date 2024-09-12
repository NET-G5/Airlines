using Airline.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Airline.Infrastructure;

//public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AirlineDbContext>
//{
//    //public AirlineDbContext CreateDbContext(string[] args)
//    //{
//    //    var optionsBuilder = new DbContextOptionsBuilder<AirlineDbContext>();
//    //    optionsBuilder.UseSqlServer(ConfigurationDefaults.ConectionString);

//    //    return new AirlineDbContext(optionsBuilder.Options);
//    //}
//}