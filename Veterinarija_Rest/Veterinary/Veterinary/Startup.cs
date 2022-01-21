using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Veterinary.Data.Repositories;
using Veterinary.Data;
using Veterinary.Auth;
using Veterinary.Data.Dtos.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Veterinary.Auth.Model;
using System.Web.Http.Cors;

namespace Veterinary
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        private const string CorsPolicyDev = "AllowAll";

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
                

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicyDev, p =>
                {
                    p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Rolës vartotojø
            services.AddIdentity<RestUsers, IdentityRole>()
                    .AddEntityFrameworkStores<RestContextDB>()
                     .AddDefaultTokenProviders();

            // Autentifikacia, JWT taukenai
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters.ValidAudience = _configuration["JWT:ValidAudience"];
                options.TokenValidationParameters.ValidIssuer = _configuration["JWT:ValidIssues"];
                options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            });

            // Autorizacija
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyNames.SameUser, policy => policy.Requirements.Add(new SameUserRequirement()));

            });

            services.AddSingleton<IAuthorizationHandler, SameUserAuthHandler>();

            // Duomenø bazës prijungimas, auto meperis ir kontoleris registracija
            services.AddDbContext<RestContextDB>();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            // Uþregistruojamos duomenø baziø repozitorijos, sukurs per konstruktoriø repozitorijas
            services.AddTransient<IUserRepository, UsersRepository>();
            services.AddTransient<IPetRepository, PetsRepository>();
            services.AddTransient<IVisitRepository, VisitsRepository>();
            services.AddTransient<IServiceRepository, ServicesRepository>();
            services.AddTransient<IVisitServicesRepository, VisitServicesRepository>();


            // Taukenø ir prieð paleidimà atliekami veiksmai
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<DatabaseSeeder, DatabaseSeeder>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Autorizacijai ir atentifikacijai
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(CorsPolicyDev);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
