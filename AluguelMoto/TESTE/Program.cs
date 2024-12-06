using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using TESTE.Model;
using TESTE.Infraestrutura;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.ConfigureHttpJsonOptions(options =>
//{
//    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
//});

builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();


//builder.Services.AddOpenApi(); //alterando o endpoint para alugelmoto


builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IMotoRepository, MotoRepository>();

builder.Services.AddTransient<IEntregadorRepository, EntregadorRepository>();


var app = builder.Build();

//var sampleTodos = new Todo[] {
//    new(1, "Walk the dog"),
//    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
//    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
//    new(4, "Clean the bathroom"),
//    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
//};

//var todosApi = app.MapGroup("/todos");
//todosApi.MapGet("/", () => sampleTodos);
//todosApi.MapGet("/{id}", (int id) =>
//    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
//        ? Results.Ok(todo)
//        : Results.NotFound());


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.MapOpenApi();
    //app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "API Alguel Motos"));
}


//app.MapControllers();

app.UseHttpsRedirection();

app.UseAuthorization();



app.Run();


//public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

//[JsonSerializable(typeof(Todo[]))]
//internal partial class AppJsonSerializerContext : JsonSerializerContext
//{

//}
