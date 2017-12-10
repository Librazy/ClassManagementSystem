using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ClassManagementSystem.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

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
            services.AddMvc();

            services.AddMvc().AddJsonOptions(jsonOptions =>
            {
                jsonOptions.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Keys:ServerSecretKey"]));

            _tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = false,

                // Validate the JWT Audience (aud) claim
                ValidateAudience = false,

                // Validate the token expiry
                ValidateLifetime = true,

                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };

            services
                .AddAuthentication(options => { options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(options => { options.TokenValidationParameters = _tokenValidationParameters; });

            Utils.JwtHeader = new JwtHeader(new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256));

            if (!_hostingEnvironment.IsDevelopment())
            {
                _connString = Configuration.GetConnectionString("MYSQL57");
                services.AddDbContext<CrmsContext>(options => options.UseMySql(_connString));
            }
            else
            {
                services.AddDbContext<CrmsContext>(options => options.UseInMemoryDatabase("CRMS"));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_hostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

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