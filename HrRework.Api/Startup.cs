using HrRework.Application.Candidates.Queries;
using HrRework.Application.Interfaces;
using HrRework.Application.Interviewers.Queries;
using HrRework.Application.Interviews.Queries;
using HrRework.DAL.Candidates;
using HrRework.DAL.Interviewers;
using HrRework.DAL.Interviews;
using HrRework.Infrastructure;
using HrRework.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HrRework.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            AddDependencies(services);

            services.AddDbContext<HrReworkContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString(Constants.Database.ConnectionString));
            });

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(2, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
        }

        private void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<ICandidateQuery, CandidateQuery>();
            services.AddScoped<IInterviewerQuery, InterviewerQuery>();
            services.AddScoped<IInterviewQuery, InterviewQuery>();

            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IInterviewerRepository, InterviewerRepository>();
            services.AddScoped<IInterviewRepository, InterviewRepository>();

            services.AddScoped<DbContext, HrReworkContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseApiVersioning();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            HrReworkInitialization.EnsureDatabaseIsCreated(app);
        }
    }
}
