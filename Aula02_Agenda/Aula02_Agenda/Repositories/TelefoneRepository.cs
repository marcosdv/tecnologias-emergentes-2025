using System.Security.Cryptography;
using Aula02_Agenda.Models.Entities;
using Aula02_Agenda.Models.Requests;
using Aula02_Agenda.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Aula02_Agenda.Repositories;

public class TelefoneRepository : ITelefoneRepository
{
    private readonly SqlConnection _sqlConnection;

    public TelefoneRepository(SqlConnection sqlConnection)
    {
        _sqlConnection = sqlConnection;
    }

    public void Adicionar(TelefoneRequest telefone)
    {
        _sqlConnection.Execute(
            "INSERT INTO TbTelefone (TelNumero, OpeId, PesId) " +
            "VALUES (@TelNumero, @OpeId, @PesId)", new
            {
                TelNumero = telefone.Numero,
                OpeId = telefone.OpeId,
                PesId = telefone.PesId
            });
    }

    public void Alterar(TelefoneRequest telefone)
    {
        _sqlConnection.Execute(
            " UPDATE TbTelefone SET " +
            "   TelNumero = @TelNumero, " +
            "   OpeId = @OpeId, " +
            "   PesId = @PesId " +
            " WHERE TelId = @TelId", new
            {
                TelNumero = telefone.Numero,
                OpeId = telefone.OpeId,
                PesId = telefone.PesId,
                TelId = telefone.Id
            });
    }

    public void Excluir(int id)
    {
        _sqlConnection.Execute(
            "DELETE FROM TbTelefone WHERE TelId = @TelId",
            new { TelId = id });
    }

    public IEnumerable<Telefone> Get()
    {
        return _sqlConnection.Query<Telefone>(
            "SELECT TelId AS Id, TelNumero as Numero FROM TbTelefone");
    }

    public Telefone? GetById(int id)
    {
        var lista = _sqlConnection.Query<Telefone, Operadora, Telefone>(
            "SELECT T.TelId AS Id, T.TelNumero as Numero, " +
            "   O.OpeId, O.OpeNome AS Nome " +
            "INNER JOIN TbOperadora O ON T.OpeId = O.OpeId " +
            "FROM TbTelefone T " +
            "WHERE T.TelId = @TelId",
            (telefone, operadora) => {
                telefone.Operadora = operadora;
                return telefone;
            },
            new { TelId = id });

        return lista.FirstOrDefault();
    }
}