var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseUrls("http://localhost:8000");

var app = builder.Build();

app.MapGet("/", () => "calculadora");

app.MapGet("/soma", () => new { resultado = 10 + 5 });
app.MapGet("/subtracao", () => new { resultado = 10 - 5 });
app.MapGet("/multiplicacao", () => new { resultado = 10 * 5 });
app.MapGet("/divisao", () => new { resultado = 4 / 2 });

app.Run();

