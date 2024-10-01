using API.Helpers;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
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
			builder.Services.AddScoped<AreaService>();
			builder.Services.AddScoped<CurriculumService>();
			builder.Services.AddScoped<SubjectService>();
			builder.Services.AddScoped<CommissionService>();
			builder.Services.AddScoped<CourseService>();
			builder.Services.AddScoped<StudentCourseService>();
			builder.Services.AddScoped<UserService>();
			builder.Services.AddScoped<StudentService>();
			builder.Services.AddScoped<TeacherService>();
			builder.Services.AddScoped<AdministrativeService>();
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
