var builder = WebApplication.CreateBuilder(args);


builder.WebHost.UseUrls("http://localhost:8000");


var app = builder.Build(); 

int resultado;

app.MapGet("/", () =>
{
    return Results.Ok("API em execução..");
});

app.MapGet("/calcula/{opcao}/{valor1}/{valor2}", (int opcao, int valor1, int valor2) =>{
switch(opcao) {

    case 1:
    {
       int resultado = valor1 + valor2;
        return Results.Ok(new {
            operacao = "soma",
            valor1,
            valor2,
            resultado
        });
    }

        case 2:
        {
        int resultado = valor1 - valor2;
        return Results.Ok(new {
            operacao = "subtracao",
            valor1,
            valor2,
            resultado
          });
        }

        case 3:
        {
           int resultado = valor1 * valor2;
        return Results.Ok(new {
            operacao = "multiplicacao",
            valor1,
            valor2,
            resultado
             });
        }

        case 4:

        {
        
        {if (valor2 == 0)
                return Results.BadRequest("Não é permitido divisão por zero");

            int resultado = valor1 / valor2;
        return Results.Ok(new {
            operacao = "divisao",
            valor1,
            valor2,
            resultado
             });
        }
        }

        default:
            return Results.Ok("Opção inválida...");
 };

app.MapGet("/calcular/soma/{a}/{b}", (int a, int b) => {

    int resultado = a + b;
    return Results.Ok(new
    {
        operacao = "soma",
        valor1 = a,
        valor2 = b, 
        resultado = resultado
    });

});
});

app.MapGet("/calcular/subtracao/{a}/{b}", (int a, int b) => {

    int resultado = a - b;
    return Results.Ok(new
    {
        operacao = "subtracao",
        valor1 = a,
        valor2 = b, 
        resultado = resultado
    });

});

app.MapGet("/calcular/multiplicacao/{a}/{b}", (int a, int b) => {

    int resultado = a * b;
    return Results.Ok(new
    {
    
        operacao = "multiplicacao",
        valor1 = a,
        valor2 = b, 
        resultado = resultado
    });

});
app.MapGet("/calcular/divisao/{a}/{b}", (int a, int b) => {
    
    if (b==0)
     return Results.BadRequest("Não é permitido divisão por zero");

            int resultado = a / b;
            return Results.Ok(new
            {
                operacao = "divisao",
                valor1 = a,
                valor2 = b,
                resultado = resultado
            });
        
});

app.Run();