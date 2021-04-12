using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Sample.WorkerService.Extensions;
using Sample.WorkerService.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                // Add the required Quartz.NET services
                services.AddQuartz(q =>
                {
                    // Use a Scoped container to create jobs. I'll touch on this later
                    q.UseMicrosoftDependencyInjectionScopedJobFactory();

                    // Create a "key" for the job                    
                    q.AddJobAndTrigger<OutboxJob>(hostContext.Configuration);

                });

                // Add the Quartz.NET hosted service

                services.AddQuartzHostedService(
                    q => q.WaitForJobsToComplete = true);

                // other config
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
