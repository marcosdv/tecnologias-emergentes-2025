using Aula02_Agenda.Models;
using Aula02_Agenda.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Aula02_Agenda.Repositories;

public class PessoaRepository : IPessoaRepository
{
    private const string connectionString =
        "Server=LAB-01-PROFESSO\\SQLEXPRESS;" +
        "Database=AgendaDb;" +
        "Trusted_Connection=True;" +
        "Integrated Security=true;" +
        "Encrypt=False";

    private readonly SqlConnection _connection;

    public PessoaRepository()
    {
        _connection = new SqlConnection(connectionString);
    }

    public IEnumerable<Pessoa> Get()
    {
        return _connection.Query<Pessoa>(
            "SELECT PesId AS Id, PesNome AS Nome FROM TbPessoa");
    }

    public Pessoa? GetById(int id)
    {
        return _connection.QueryFirstOrDefault<Pessoa>(
            "SELECT PesId AS Id, PesNome AS Nome FROM TbPessoa " +
            "WHERE PesId = @Id", new { Id = id });
    }

    public void Adicionar(Pessoa pessoa)
    {
        _connection.Execute(
            "INSERT INTO TbPessoa (PesNome) VALUES (@Nome)",
            new { Nome = pessoa.Nome });
    }

    public void Alterar(Pessoa pessoa)
    {
        _connection.Execute("UPDATE TbPessoa SET PesNome = @Nome " +
            "WHERE PesId = @Id",
            new { Id = pessoa.Id, Nome = pessoa.Nome });
    }

    public void Excluir(int id)
    {
        _connection.Execute("DELETE FROM TbPessoa WHERE PesId = @Id",
            new { Id = id });
    }
}