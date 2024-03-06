using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectExam.DbContext;
using ProjectExam.Services.Contracts;
using ProjectExam.Services;
using ProjectExam.Repositories.Contracts;
using ProjectExam.Repositories;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
     .ConfigureServices((hostBuilder, services) =>
     {
         services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(hostBuilder.Configuration.GetConnectionString("MyConnectionString")));
           services.AddApplicationInsightsTelemetryWorkerService();
            services.ConfigureFunctionsApplicationInsights();


         services.AddScoped<IEventService, EventService>();


         services.AddScoped<IEventRepository, EventRepository>();
     })
    .Build();

host.Run();
