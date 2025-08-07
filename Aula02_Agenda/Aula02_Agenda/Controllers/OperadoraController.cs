using System.Data;
using Aula02_Agenda.Models;
using Microsoft.AspNetCore.Http;
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
        /*
        var connection = new SqlConnection(connectionString);
        connection.Open();
        //...SELECT
        connection.Close();
        connection.Dispose();
        */

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
}