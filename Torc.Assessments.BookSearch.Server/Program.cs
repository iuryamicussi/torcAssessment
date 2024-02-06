
using Torc.Assessments.BookSearch.Server.BLL;
using Torc.Assessments.BookSearch.Server.DAL;

namespace Torc.Assessments.BookSearch.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("bookDb");

            builder.Services.AddScoped<ISqlServerConnector, SqlServerConnector>(sp =>
                new SqlServerConnector(connectionString));
            builder.Services.AddScoped<IBookDal, BookDal>();
            builder.Services.AddScoped<IBookBll, BookBll>();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
