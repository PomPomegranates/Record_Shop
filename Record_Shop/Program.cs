
using Microsoft.EntityFrameworkCore;
using Record_Shop.Service;
using Record_Shop.Model;
using Microsoft.Extensions.Configuration.UserSecrets;
using Newtonsoft.Json;

namespace Record_Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            Console.WriteLine(builder.Environment.IsDevelopment());
            if (builder.Environment.IsDevelopment())
            {
                
                builder.Services.AddDbContext<RecordShopDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
            }
            else 
            {
                builder.Services.AddDbContext<RecordShopDbContext>(options => options.UseSqlServer("Connection_String"));
            }
            //builder.Services.AddDbContext<RecordShopDbContext>();
            builder.Services.AddScoped<IRecordShopService, RecordShopService>();
            builder.Services.AddScoped<IRecordShopModel, RecordShopModel>();


            // Add services to the container.   


            builder.Services.AddControllers();
    //.AddJsonOptions(options =>
    //{
    //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    //});
            //.AddNewtonsoftJson(options =>

            //{
            //    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //});
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
