using System;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassManagementSystem.Controllers;
using ClassManagementSystem.Models;
using ClassManagementSystem.Scheduling;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Converters;

namespace ClassManagementSystem
{
    public class Startup
    {
        private static string _connString = string.Empty;

        private static SymmetricSecurityKey _signingKey;

        private static TokenValidationParameters _tokenValidationParameters;

        private static IHostingEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _hostingEnvironment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Keys:ServerSecretKey"]));

            _tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true
            };

            // 登录与鉴权
            services
                .AddAuthentication(options => { options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(
                    options =>
                    {
                        options.Events = new JwtBearerEvents();
                        options.TokenValidationParameters = _tokenValidationParameters;
                        options.Events.OnChallenge += Utils.OnChallenge;
                    });

            Utils.JwtHeader = new JwtHeader(new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256));

            // 数据库
            if (!_hostingEnvironment.IsDevelopment())
            {
                _connString = Configuration.GetConnectionString("MYSQL57");
                services.AddDbContextPool<CrmsContext>(options => options.UseMySql(_connString));
            }
            else
            {
                //$env:ASPNETCORE_ENVIRONMENT="Production"
                services.AddDbContextPool<CrmsContext>(options => options.UseInMemoryDatabase("CRMS"));
            }

            // MVC
            services.AddMvc().AddJsonOptions(
                option => { option.SerializerSettings.Converters.Add(new StringEnumConverter()); }
            );

            // 定时任务
            services.AddScheduler();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}