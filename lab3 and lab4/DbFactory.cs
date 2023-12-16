using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace lab3.Database
{
    public class PeopleDbFactory : IDesignTimeDbContextFactory<PeopleDb>
        {
            public PeopleDb CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<PeopleDb>();
                optionsBuilder.UseSqlServer("Server=tcp:iot-2023.database.windows.net,1433;Initial Catalog=IoT_2023;Persist Security Info=False;User ID=PMusielak;Password=Wrotki12#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                return new PeopleDb(optionsBuilder.Options);
            }
        }
    }