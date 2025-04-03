using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using BlazoriseQuartz.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Quartz;
using Syrna.BlazoriseQuartz.Blazor;
using Syrna.BlazoriseQuartz.Blazor.Components;
using Syrna.BlazoriseQuartz.Blazor.Services;
using Syrna.BlazoriseQuartz.EntityFrameworkCore;
using Syrna.BlazoriseQuartz.ExecutionLog;
using Syrna.BlazoriseQuartz.Scheduler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Syrna.BlazoriseQuartz.Jobs;

namespace Syrna.BlazoriseQuartz.MainDemo.Blazor.Server.Host
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazoriseQuartzUI(this IServiceCollection services,
            IConfiguration blazoriseUIConfiguration,
            Action<DbContextOptionsBuilder> dbContextOptions = null,
            string connectionString = null)
        {
            services.Configure<BlazoriseQuartzUIOptions>(blazoriseUIConfiguration);

            var uiOptions = blazoriseUIConfiguration.Get<BlazoriseQuartzUIOptions>();
            services.AddBlazoriseQuartz(blazoriseUIConfiguration, dbContextOptions, connectionString);

            return AddBlazoriseQuartzUI(services);
        }

        public static IServiceCollection AddBlazoriseQuartzUI(this IServiceCollection services,
            Action<BlazoriseQuartzUIOptions> configure = null,
            Action<DbContextOptionsBuilder> dbContextOptions = null,
            string connectionString = null)
        {
            if (configure == null)
            {
                services.AddOptions<BlazoriseQuartzUIOptions>()
                    .Configure(opt =>
                    {
                    });
                services.AddBlazoriseQuartz(dbContextOptions: dbContextOptions,
                    connectionString: connectionString);
            }
            else
            {
                BlazoriseQuartzUIOptions uiOptions = new();
                services.Configure(configure);
                services.AddBlazoriseQuartz(
                    o =>
                    {
                        o.AllowedJobAssemblyFiles = uiOptions.AllowedJobAssemblyFiles;
                        o.AutoMigrateDb = uiOptions.AutoMigrateDb;
                        o.DataStoreProvider = uiOptions.DataStoreProvider;
                        o.DisallowedJobTypes = uiOptions.DisallowedJobTypes;
                    },
                    dbContextOptions,
                    connectionString);
            }

            return AddBlazoriseQuartzUI(services);
        }

        private static IServiceCollection AddBlazoriseQuartzUI(IServiceCollection services)
        {
            // Blazorise
            //services
	           // .AddBlazorise(options =>
	           // {
		          //  options.Immediate = true;
	           // })
	           // //.AddMaterialProviders()
	           // //.AddMaterialIcons()             
	           // .AddBootstrap5Providers()
	           // .AddFontAwesomeIcons()
            //    ;

            //services.AddScoped<LayoutService>();
            services.AddTransient<ITriggerDetailModelValidator, TriggerDetailModelValidator>();
            services.AddSingleton<IJobUIProvider, JobUIProvider>();

            return services;
        }

        public static IServiceCollection AddBlazoriseQuartz(this IServiceCollection services,
            Action<BlazoriseQuartzCoreOptions> options,
            Action<DbContextOptionsBuilder> dbContextOptions = null,
            string connectionString = null)
        {
            services.Configure(options);

            BlazoriseQuartzCoreOptions coreOptions = new();
            options.Invoke(coreOptions);

            return AddBlazoriseQuartz(services, coreOptions,
                dbContextOptions, connectionString);
        }

        public static IServiceCollection AddBlazoriseQuartz(this IServiceCollection services,
            IConfiguration config = null,
            Action<DbContextOptionsBuilder> dbContextOptions = null,
            string connectionString = null)
        {
            BlazoriseQuartzCoreOptions coreOptions = null;
            if (config != null)
            {
                services.Configure<BlazoriseQuartzCoreOptions>(config);
                coreOptions = config.Get<BlazoriseQuartzCoreOptions>();
            }
            else
            {
                services.AddOptions<BlazoriseQuartzCoreOptions>()
                    .Configure(opt =>
                    {
                    });
            }

            return AddBlazoriseQuartz(services, coreOptions ?? new(),
                dbContextOptions, connectionString);
        }
        private static IServiceCollection AddBlazoriseQuartz(IServiceCollection services,
            BlazoriseQuartzCoreOptions coreOptions,
            Action<DbContextOptionsBuilder> dbContextOptions = null,
            string connectionString = null)
        {
            services.AddBlazoriseQuartzJobs();

            services.TryAddSingleton<ISchedulerDefinitionService, SchedulerDefinitionService>();
            services.AddTransient<ISchedulerAppService, SchedulerAppService>();

            var schListenerSvc = new SchedulerListenerService();
            services.TryAddSingleton<ISchedulerListenerService>(schListenerSvc);
            services.AddSingleton<ITriggerListener>(schListenerSvc);
            services.AddSingleton<IJobListener>(schListenerSvc);
            services.AddSingleton<ISchedulerListener>(schListenerSvc);
            services.AddTransient<IExecutionLogStore, ExecutionLogStore>();
            services.AddTransient<IExecutionLogAppService, ExecutionLogAppService>();

            //services.AddSingleton<IExecutionLogRawSqlProvider, BaseExecutionLogRawSqlProvider>();

            if (dbContextOptions != null)
            {
                services.AddDbContextFactory<BlazoriseQuartzDbContext>(dbContextOptions);
            }
            else
            {
                Action<DbContextOptionsBuilder> dbOptionAction = null;
                switch (coreOptions.DataStoreProvider)
                {
                    case DataStoreProvider.Sqlite:
                        dbOptionAction = options =>
                            options.UseSqlite(connectionString ?? "DataSource=blazoriseQuartzApp.db;Cache=Shared",
                                x => x.MigrationsAssembly("SqliteMigrations"))
                                .UseSnakeCaseNamingConvention();
                        break;
                    case DataStoreProvider.InMemory:
                        dbOptionAction = options =>
                            options.UseInMemoryDatabase(connectionString ?? "BlazoriseQuartzDb");
                        break;
                    case DataStoreProvider.PostgreSQL:
                        ArgumentNullException.ThrowIfNull(connectionString);
                        dbOptionAction = options =>
                            options.UseNpgsql(connectionString,
                                x => x.MigrationsAssembly("PostgreSQLMigrations"))
                                .UseSnakeCaseNamingConvention();
                        break;
                    case DataStoreProvider.SqlServer:
                        ArgumentNullException.ThrowIfNull(connectionString);
                        dbOptionAction = options =>
                            options.UseSqlServer(connectionString,
                                x => x.MigrationsAssembly("Syrna.BlazoriseQuartz.MainDemo.SqlServer.EntityFrameworkCore"))
                                .UseSnakeCaseNamingConvention();
                        break;
                    default:
                        throw new NotSupportedException("Unsupported data store provider. Configure services.AddDbContextFactory() manually");

                }

                services.AddDbContextFactory<BlazoriseQuartzDbContext>(dbOptionAction);
            }

            services.AddHostedService<SchedulerEventLoggingService>();
            LoadJobAssemblies(coreOptions);
            return services;
        }

        private static void LoadJobAssemblies(BlazoriseQuartzCoreOptions coreOptions)
        {
            if (coreOptions.AllowedJobAssemblyFiles == null)
                return;

            var path = Path.GetDirectoryName(Assembly.GetAssembly(typeof(SchedulerDefinitionService))!.Location) ?? string.Empty;
            List<Type> jobTypes = new();
            foreach (var assemblyStr in coreOptions.AllowedJobAssemblyFiles)
            {
                string assemblyPath = Path.Combine(path, assemblyStr + ".dll");
                Assembly.LoadFrom(assemblyPath);
            }
        }
    }
}

