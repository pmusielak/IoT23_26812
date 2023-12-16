using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CdvAzure.Functions;
using Microsoft.EntityFrameworkCore;
using lab3.Database;
using lab3.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services => {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSingleton<DatabasePeopleService>();
        services.AddSingleton<DatabaseAddressesService>();
        services.AddDbContext<PeopleDb>(options => {
            options.UseSqlServer("Server=tcp:iot-2023.database.windows.net,1433;Initial Catalog=IoT_2023;Persist Security Info=False;User ID=PMusielak;Password=Wrotki12#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        });
    })
    .Build();

host.Run();
