using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using WebApi.Job;

namespace WebApi.Extensoes
{
    public static class QuartzExtension
    {
        public static void AddConfigureQuartz(this IServiceCollection services)
        {
            services.AddTransient<DepartamentoJob>();

            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();
                q.UseSimpleTypeLoader();
                q.UseInMemoryStore();
                q.ScheduleJob<DepartamentoJob>(trigger => trigger
                     .StartNow()
                     .WithSimpleSchedule(x => x.WithInterval(TimeSpan.FromSeconds(10)).RepeatForever())
                 );
            });

            services.AddQuartzHostedService(options =>
            {
                options.WaitForJobsToComplete = true;
            });
        }

    }
}
