namespace AcademiaApi.Models;

public class Exercicio
{
    public int Id { get; set; }

    public string Nome { get; set; } = "";

    public string GrupoMuscular { get; set; } = "";

    public List<string> MusculosSecundarios { get; set; } = new();

    public string Equipamento { get; set; } = "";

    public string Tipo { get; set; } = "";

    public string Nivel { get; set; } = "";

    public string SeriesRecomendadas { get; set; } = "";

    public string Repeticoes { get; set; } = "";

    public string Observacao { get; set; } = "";

    public string Gif { get; set; } = "";
}