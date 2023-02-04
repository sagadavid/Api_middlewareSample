var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

//app.Use(async (context, next) =>
//{
//    Console.WriteLine($"use.console1");
//    await next();
//    Console.WriteLine($"use.console2");
//    //await next();
//});
app.Map("/usingmapbranch", builder =>
{
    builder.Use(async (context, next) =>
    {
        Console.WriteLine("Map.Use.console1");

        await context.Response.WriteAsync("Map.use.context.response\n");
        await next.Invoke();
        //await next();

        Console.WriteLine("Map.Use.console2");
    });
    builder.Run(async context =>
    {
        Console.WriteLine($"Map.Run.console");
        await context.Response.WriteAsync("Map.Run.context.response\n");
    });
});
//app.Run(async context =>
//{
//    Console.WriteLine($"Run.console");
//    await context.Response.WriteAsync("Run.context.response");
//    //We use the Run method, which adds a terminal component
//    //to the app pipeline. We can see we are not using the next
//    //delegate because the Run method is always terminal and
//    //terminates the pipeline. This method accepts a single
//    //parameter of the RequestDelegate type.

//});

app.MapControllers();

app.Run();
