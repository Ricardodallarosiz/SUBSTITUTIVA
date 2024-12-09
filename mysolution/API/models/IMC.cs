using System;

namespace API.models;

public class IMC
{
    public int IMCId { get; set; }
    public int AlunoId { get; set; }
    public Aluno Aluno { get; set; }
    public string Classificacao { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public double peso { get; set; }
    public double altura { get; set; }
    public double ValorIMC { get; set; }
}
