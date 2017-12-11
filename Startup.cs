using System;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using ClassManagementSystem.Controllers;
using ClassManagementSystem.Models;
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
                .AddJwtBearer(
                    options =>
                    {
                        options.Events = new JwtBearerEvents();
                        options.TokenValidationParameters = _tokenValidationParameters;
                        options.Events.OnChallenge += async eventContext =>
                        {
                            if (eventContext.AuthenticateFailure != null)
                            {
                                if (string.IsNullOrEmpty(eventContext.Error) &&
                                    string.IsNullOrEmpty(eventContext.ErrorDescription) &&
                                    string.IsNullOrEmpty(eventContext.ErrorUri))
                                {
                                    eventContext.Response.Headers.Append(HeaderNames.WWWAuthenticate,
                                        eventContext.Options.Challenge);
                                }
                                else
                                {
                                    // https://tools.ietf.org/html/rfc6750#section-3.1
                                    // WWW-Authenticate: Bearer realm="example", error="invalid_token", error_description="The access token expired"
                                    var builder = new StringBuilder(eventContext.Options.Challenge);
                                    if (eventContext.Options.Challenge.IndexOf(" ", StringComparison.Ordinal) > 0)
                                    {
                                        // Only add a comma after the first param, if any
                                        builder.Append(',');
                                    }
                                    if (!string.IsNullOrEmpty(eventContext.Error))
                                    {
                                        builder.Append(" error=\"");
                                        builder.Append(eventContext.Error);
                                        builder.Append("\"");
                                    }
                                    if (!string.IsNullOrEmpty(eventContext.ErrorDescription))
                                    {
                                        if (!string.IsNullOrEmpty(eventContext.Error))
                                        {
                                            builder.Append(",");
                                        }

                                        builder.Append(" error_description=\"");
                                        builder.Append(eventContext.ErrorDescription);
                                        builder.Append('\"');
                                    }
                                    if (!string.IsNullOrEmpty(eventContext.ErrorUri))
                                    {
                                        if (!string.IsNullOrEmpty(eventContext.Error) ||
                                            !string.IsNullOrEmpty(eventContext.ErrorDescription))
                                        {
                                            builder.Append(",");
                                        }

                                        builder.Append(" error_uri=\"");
                                        builder.Append(eventContext.ErrorUri);
                                        builder.Append('\"');
                                    }

                                    eventContext.Response.Headers.Append(HeaderNames.WWWAuthenticate,
                                        builder.ToString());
                                }
                                eventContext.Response.StatusCode = 401;
                                eventContext.Response.Headers.Append(HeaderNames.ContentType, "application/json");

                                eventContext.HandleResponse();
                                var msg = "登录无效";

                                var ex = eventContext.AuthenticateFailure;
                                var exceptions = new ReadOnlyCollection<Exception>(new[] {ex});
                                if (ex is AggregateException agEx)
                                {
                                    exceptions = agEx.InnerExceptions;
                                }
                                if (exceptions.Select(e => e is SecurityTokenExpiredException).Any())
                                {
                                    msg = "登录已过期，请重新登录";
                                }
                                // 检查更多错误情况
                                var json = $"{{\"msg\": \"{msg}\"}}";
                                var b = Encoding.UTF8.GetBytes(json);
                                await eventContext.Response.Body.WriteAsync(b, 0, b.Length);
                            }
                        };
                    });

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

            services.AddMvc().AddJsonOptions(
                option => { option.SerializerSettings.Converters.Add(new StringEnumConverter()); }
            );
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