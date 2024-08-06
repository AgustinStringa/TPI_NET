using System.Text.Json.Serialization;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers().AddJsonOptions(x =>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            var app = builder.Build();
            app.MapGet("/", () => "Hello World!");
            app.MapControllers();
            app.Run();
        }
    }
}
