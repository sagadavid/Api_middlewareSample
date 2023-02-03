var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run(async context =>
{
    await context.Response.WriteAsync("this is middleware component");
    //We use the Run method, which adds a terminal component
    //to the app pipeline. We can see we are not using the next
    //delegate because the Run method is always terminal and
    //terminates the pipeline. This method accepts a single
    //parameter of the RequestDelegate type.

}
);

app.MapControllers();

app.Run();
