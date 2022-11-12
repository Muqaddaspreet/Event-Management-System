using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookReadingEvent.Core.ExceptionManagement;
using BookReadingEvent.ProductDomain.AppServices;
using BookReadingEvent.ProductDomain.AppServices.Facade;
using BookReadingEvent.ProductDomain.AppServices.Factory;
using BookReadingEvent.ProductDomain.AppServices.Mapper;
using BookReadingEvent.ProductDomain.Configuration;
using BookReadingEvent.ProductDomain.Data.DBContext;
using BookReadingEvent.ProductDomain.Repository;
using BookReadingEvent.Web.Mapper;
using BookReadingEvent.Web.Subject;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using BookReadingEvent.ProductDomain.UoW;
using BookReadingEvent.ProductDomain.UoW.Files;

namespace BookReadingEvent.Web
{
    public class Startup
    {
        private MapperConfiguration _mapperConfiguration { get; set; }
        private IExceptionManager exceptionManager;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
                cfg.AddProfile(new WebMappingProfile());
            });

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            BookReadingEvent.Core.Logging.ILogger logger = new BookReadingEvent.Loggig.NLog.Logger();
            exceptionManager = new ExceptionManager(logger);
            services.AddMvc();
            services.AddDistributedMemoryCache(); 
            services.AddSession();
            services.RegisterRepositories();
            services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());
            services.AddSingleton<IProductAppService, ProductAppService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserRepository,UserRepository>();
            services.AddSingleton<IUserLoginService, UserLoginService>();
            services.AddSingleton<ICreateEventService, CreateEventService>();
            services.AddSingleton<ICreateEventRepositry, CreateEventRepositry>();
            services.AddSingleton<IExceptionManager, ExceptionManager>();
            services.AddSingleton<IEventFacade, EventFacade>();
            services.AddSingleton<FacadeFactory, FacadeFactory>();
            services.AddSingleton<INotifySubject, NotifySubject>();
            services.AddSingleton<IUserLoginFacade, UserLoginFacade>();
            services.AddSingleton<BookReadingEvent.Core.Logging.ILogger, BookReadingEvent.Loggig.NLog.Logger>();
            //   services.AddSingleton<BookReadingEvent.ProductDomain.UoW.IUnitOfWork,BookReadingEvent.ProductDomain.UoW.UnitOfWork>();
            services.AddSingleton<ICustomUnitOfWork, CustomUnitOfWork>();
            services.AddDbContext<ProductDomainDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
