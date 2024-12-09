using System;

namespace API.models;

public class Aluno
{
    public int AlunoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }

    public List<IMC> iMCs { get; set; } = new List<IMC>();
}
