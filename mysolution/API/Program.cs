using API.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapPost("/api/aluno/cadastrar", ([FromBody] Aluno aluno, [FromServices] AppDataContext ctx) =>
{
    ctx.alunos.Add(aluno);
    ctx.SaveChanges();
    return Results.Ok(aluno);

});

app.MapPost("/api/imc/cadastrar", ([FromBody] IMC imc, [FromServices] AppDataContext ctx) =>
{
    imc.ValorIMC = imc.peso / (imc.altura * imc.altura);
    if (imc.ValorIMC < 18.5) imc.Classificacao = "Magreza";
    else if (imc.ValorIMC > 18.5 && imc.ValorIMC < 24.9) imc.Classificacao = "Normal";
    else if (imc.ValorIMC > 25 && imc.ValorIMC < 29.9) imc.Classificacao = "sobrepeso";
    else if (imc.ValorIMC > 30 && imc.ValorIMC < 39.9) imc.Classificacao = "obesidade";
    else imc.Classificacao = "obesidade grave";


    ctx.IMCs.Add(imc);
    ctx.SaveChanges();
    return Results.Ok(imc);

});

app.MapGet("/api/imc/listar", ([FromServices] AppDataContext ctx) =>
{
    var IMCs = ctx.IMCs
        .Include(imc => imc.Aluno)
        .Select(imc => new
        {
            imc.IMCId,
            imc.peso,
            imc.altura,
            imc.ValorIMC,
            imc.Classificacao,
            imc.DataCriacao,
            Aluno = new
            {
                imc.Aluno.AlunoId,
                imc.Aluno.Nome,
                imc.Aluno.DataNascimento
            }
        })
        .ToList();

    return Results.Ok(IMCs);
});

app.MapPut("/api/imc/alterar/{id}", ([FromRoute] int id, [FromBody] IMC imcAtualizado, [FromServices] AppDataContext ctx) =>
{
    var imc = ctx.IMCs.Find(id);

    imc.peso = imcAtualizado.peso;
    imc.altura = imcAtualizado.altura;

    imc.ValorIMC = imc.peso / (imc.altura * imc.altura);
    if (imc.ValorIMC < 18.5) imc.Classificacao = "Magreza";
    else if (imc.ValorIMC > 18.5 && imc.ValorIMC < 24.9) imc.Classificacao = "Normal";
    else if (imc.ValorIMC > 25 && imc.ValorIMC < 29.9) imc.Classificacao = "sobrepeso";
    else if (imc.ValorIMC > 30 && imc.ValorIMC < 39.9) imc.Classificacao = "obesidade";
    else imc.Classificacao = "obesidade grave";



    ctx.SaveChanges();
    return Results.Ok(imc);


});





app.Run();
