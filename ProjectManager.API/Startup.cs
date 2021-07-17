using Application.Contracts.Identity;
using Application.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistance.DependencyInjection;
using ProjectManager.API.AuthFilters;
using ProjectManager.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.API
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
            services.AddPersistance(Configuration);
            services.AddApplication();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectManager.API", Version = "v1" });
                c.OperationFilter<AuthorizeCheckOperationFilter>();
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
                            TokenUrl = new Uri("https://localhost:5001/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"api", "Full access" },
                                {"email", "Email address" }
                            }
                        }
                    }
                });
            });
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", opt =>
                {
                    opt.Authority = "https://localhost:5001";
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = false
                    };
                });
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "api");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectManager.API v1");
                    c.OAuthClientId("swagger");
                    c.OAuth2RedirectUrl("https://localhost:44383/swagger/oauth2-redirect.html");
                    c.OAuthUsePkce();
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
