namespace Aula02_Agenda.Models;

public class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Telefone> Telefones { get; set; }

    public Pessoa(int id, string nome, List<Telefone> telefones)
    {
        Id = id;
        Nome = nome;
        Telefones = telefones;
    }
}