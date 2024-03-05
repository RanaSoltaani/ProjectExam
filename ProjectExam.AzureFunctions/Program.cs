using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectExam.DbContext;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
     .ConfigureServices((hostBuilder, services) =>
     {
         services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(hostBuilder.Configuration.GetConnectionString("MyConnectionString")));
           services.AddApplicationInsightsTelemetryWorkerService();
            services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();
