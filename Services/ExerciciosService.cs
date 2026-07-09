using System.Text.Json;
using AcademiaApi.Models;

namespace AcademiaApi.Services;

public class ExerciciosService
{
    private readonly IWebHostEnvironment _env;

    public ExerciciosService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public List<Exercicio> ObterTodos()
    {
        var caminho = ObterCaminhoDoArquivo();

        if (!File.Exists(caminho))
        {
            Console.WriteLine($"Arquivo não encontrado: {caminho}");
            return new List<Exercicio>();
        }

        var json = File.ReadAllText(caminho);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var lista = JsonSerializer.Deserialize<List<Exercicio>>(json, options);

        Console.WriteLine($"Quantidade de exercícios: {lista?.Count}");

        return lista ?? new List<Exercicio>();
    }

    private string ObterCaminhoDoArquivo()
    {
        var caminhos = new[]
        {
            Path.Combine(_env.ContentRootPath, "Data", "exercicios.json"),
            Path.Combine(AppContext.BaseDirectory, "Data", "exercicios.json"),
            Path.Combine(Directory.GetCurrentDirectory(), "Data", "exercicios.json")
        };

        foreach (var caminho in caminhos)
        {
            if (File.Exists(caminho))
            {
                return caminho;
            }
        }

        return caminhos[0];
    }
}