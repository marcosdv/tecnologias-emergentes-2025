using Aula02_Agenda.Repositories;
using Aula02_Agenda.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace Aula02_Agenda.Config;

public static class ServicesExtensions
{
    public static void AddInjecaoDependencias(
        this IServiceCollection services,
        IConfigurationManager config)
    {
        var connectionString = config.GetConnectionString("conexao") ?? "";

        services.AddScoped<SqlConnection>(
                                x => new SqlConnection(connectionString));

        //services.AddSingleton<IPessoaRepository, PessoaRepository>();
        //services.AddTransient<IPessoaRepository, PessoaRepository>();
        services.AddScoped<IPessoaRepository, PessoaRepository>();
    }
}