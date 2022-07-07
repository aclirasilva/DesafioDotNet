using Infraestructure.Interface;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructure.Conexao
{
    /// <summary>
    /// ADO.NET: Classe de Conexao com o Banco de Dados
    /// </summary>
    public class DBConexao : IDBConexao
    {
        public IDbConnection Conexao { get; }
        
        public DBConexao(IConfiguration configuration)
        {
            try
            {
                //Pega a string de conexao com o banco de dados
                var con = configuration.GetConnectionString("SqlServerConnection");
                //Instancia de conexao com banco de dados
                Conexao = new SqlConnection(con);
                //Abre a conexao com o banco de dados
                Conexao.Open();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public void Dispose()
        {
            Conexao.Dispose();
        }
    }
}
