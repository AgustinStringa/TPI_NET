using API.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers().AddJsonOptions(
                x =>
                {
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    x.JsonSerializerOptions.WriteIndented = true;
                }
        );
        builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
        x.RequireHttpsMetadata = false;
        x.SaveToken = false;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8
                .GetBytes("dummy_secret_for_development_mode")
            ),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });
            builder.Services.AddAuthorizationBuilder();
            var app = builder.Build();
    app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI();
            //app.MapControllers().RequireAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
