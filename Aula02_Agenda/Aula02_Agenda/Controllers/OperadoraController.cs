using System.Data;
using Aula02_Agenda.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Aula02_Agenda.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperadoraController : ControllerBase
{
    private const string connectionString =
        "Server=LAB-01-PROFESSO\\SQLEXPRESS;" +
        "Database=AgendaDb;" +
        "Trusted_Connection=True;" +
        "Integrated Security=true;" +
        "Encrypt=False";

    [HttpGet]
    public IActionResult Get()
    {
        var lista = new List<Operadora>();

        //SqlConnection -> Cria a conexao com o banco de dados
        using (var connection = new SqlConnection(connectionString))
        {
            //abre a conexao com o banco de dados
            connection.Open();

            //cria o objeto que permite executar comandos no banco
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM TbOperadora";

                //executa o comando no banco e retorna os dados do Select
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var operadora = new Operadora(
                        reader.GetInt32(0),
                        reader.GetString(1)
                    );

                    lista.Add(operadora);
                }
            }
        }

        return Ok(lista);
    }

    [Authorize(Roles = "Admin,User")]
    [HttpPost]
    public IActionResult Adicionar(Operadora operadora)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText =
                    "INSERT INTO TbOperadora (OpeNome) VALUES (@nome)";
                command.Parameters
                    .Add("@nome", SqlDbType.VarChar).Value = operadora.Nome;

                var i = command.ExecuteNonQuery();

                return Ok($"{i} linhas adicionadas.");
            }
        }
    }

    [Authorize(Roles = "Admin,User")]
    [HttpPut]
    public IActionResult Alterar(Operadora operadora)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE TbOperadora SET " +
                    "OpeNome = @nome WHERE OpeId = @id";
                command.Parameters
                    .Add("@nome", SqlDbType.VarChar).Value = operadora.Nome;
                command.Parameters
                    .Add("@id", SqlDbType.Int).Value = operadora.Id;

                var i = command.ExecuteNonQuery();

                return Ok($"{i} linhas alteradas.");
            }
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete]
    public IActionResult Excluir(int id)
    {
        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE FROM TbOperadora " +
                        "WHERE OpeId = @id";

                    command.Parameters.
                        Add("@id", SqlDbType.Int).Value = id;

                    var i = command.ExecuteNonQuery();

                    return Ok($"{i} linhas excluidas.");
                }
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}