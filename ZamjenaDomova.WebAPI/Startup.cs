using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ZamjenaDomova.Model.Requests;
using ZamjenaDomova.WebAPI.Database;
using ZamjenaDomova.WebAPI.Filters;
using ZamjenaDomova.WebAPI.Helpers;
using ZamjenaDomova.WebAPI.Services;

namespace ZamjenaDomova.WebAPI
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

            services.AddDbContext<ZamjenaDomovaContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("LocalDB")));

            //DOCKER
            //var server = Configuration["DBServer"] ?? "ms-sql-server";
            //var port = Configuration["DBPort"] ?? "1433";
            //var user = Configuration["DBUser"] ?? "SA";
            //var password = Configuration["DBPassword"] ?? "Pa55w0rd2020";
            //var database = Configuration["Database"] ?? "KljucZaKljuc";

            //services.AddDbContext<ZamjenaDomovaContext>(options =>
            //    options.UseSqlServer($"Server={server},{port};Initial Catalog={database}; User ID={user};Password={password};ConnectRetryCount=200;"));

            //swagger 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."

                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configuring jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = int.Parse(context.Principal.Identity.Name);

                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }

                        if (user.Roles != null)
                        {
                            var claims = new List<Claim>();

                            foreach (var role in user.Roles)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, role.Name));
                            }

                            var appIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                            context.Principal.AddIdentity(appIdentity);
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWishlistService, WishlistService>();
            services.AddScoped<IListingService, ListingService>();
            services.AddScoped<IService<Model.AmenitiesCategory, object>, BaseService<Model.AmenitiesCategory, object, Database.AmenitiesCategory>>();
            services.AddScoped<IService<Model.Territory, object>, BaseService<Model.Territory, object, Database.Territory>>();
            services.AddScoped<IService<Model.Role, RoleSearchRequest>, RoleService>();
            services.AddScoped<ICRUDService<Model.Amenity, Model.Requests.AmenitySearchRequest, Model.Requests.AmenityUpsertRequest, Model.Requests.AmenityUpsertRequest>, AmenityService>();
            //services.AddScoped<ICRUDService<Model.ListingImageModel, object, Model.ListingImageModel, Model.ListingImageModel>, ListingImageService>();
            services.AddScoped<RatingService>();
            services.AddScoped<ListingImageService>();
            services.AddMvc(x => x.Filters.Add<ErrorFilter>());


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DefaultFilesOptions DefaultFile = new DefaultFilesOptions();
            DefaultFile.DefaultFileNames.Clear();
            DefaultFile.DefaultFileNames.Add("Index.html");
            app.UseDefaultFiles(DefaultFile);
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });

            PrepDB.PrepPopulation(app);
        }
    }
}
