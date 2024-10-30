
namespace Api1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
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

/*
    Webserver -> https://locashost:7127  -> 80 http  https 443
        URL -> controller

        HTTP / HTTPS  TLS
            Verbs:
                GET  <- query /pizza/1
                POST  ->  create new resources   /pizza
                PUT   ->   modify  PUT /pizza/1
                DELETE ->   remove  DELETE  /pizza/1
                HEAD
                OPTIONS
                TRACE

            browser curl postman  -> https://locashost:7127/version
 
 */