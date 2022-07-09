using Domain;
using Domain.Interface;
using Infraestructure.Interface;
using System.Data;
using System.Data.SqlClient;

namespace Repository
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        protected IDBConexao AppConexao;
        public ProdutoRepositorio(IDBConexao conexao)
        {
            AppConexao = conexao;
        }
        public IEnumerable<Produto> GetAll()
        {
            List<Produto> lstProduto = new List<Produto>();

            using (var con = AppConexao.Conexao)
            {
                var cmd = new SqlCommand();
                cmd.Connection = con as SqlConnection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ConsultaProduto";
                cmd.Parameters.AddWithValue("@Id", "");

                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Produto produto = new Produto();
                    produto.Id = dataReader.GetInt32("Id");
                    produto.Descricao = dataReader.GetString("Descricao");
                    produto.Marca = dataReader.GetString("Marca");
                    produto.Preco = dataReader.GetDecimal("Preco");
                    produto.DtCadastro = dataReader.GetDateTime("DtCadastro");
                    produto.DtAlteracao = dataReader.GetDateTime("DtAlteracao");

                    lstProduto.Add(produto);
                }
            }

            return lstProduto;
        }
        public Produto GetId(int id)
        {
            using (var con = AppConexao.Conexao)
            {
                var cmd = new SqlCommand();
                cmd.Connection = con as SqlConnection;
                cmd.CommandType = CommandType.StoredProcedure ;
                cmd.CommandText = "SP_ConsultaProduto";
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader dataReader = cmd.ExecuteReader();
                Produto produto = new Produto();

                while (dataReader.Read())
                {
                    produto.Id = dataReader.GetInt32("Id");
                    produto.Descricao = dataReader.GetString("Descricao");
                    produto.Marca = dataReader.GetString("Marca");
                    produto.Preco = dataReader.GetDecimal("Preco");
                    produto.DtCadastro = dataReader.GetDateTime("DtCadastro");
                    produto.DtAlteracao = dataReader.GetDateTime("DtAlteracao");
                }

                return produto;
            }
        }
        public int Insert(Produto obj)
        {
            using (var con = AppConexao.Conexao)
            {
                var cmd = new SqlCommand();
                cmd.Connection = con as SqlConnection;

                cmd.CommandText = @"INSERT INTO PRODUTOS (DESCRICAO, MARCA, PRECO, DTCADASTRO, DTALTERACAO) 
                                    VALUES (@DESCRICAO, @MARCA, @PRECO, @DTCADASTRO, @DTALTERACAO)";

                //cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@Marca", obj.Marca);
                cmd.Parameters.AddWithValue("@Preco", obj.Preco);
                cmd.Parameters.AddWithValue("@DtCadastro", obj.DtCadastro);
                cmd.Parameters.AddWithValue("@DtAlteracao", obj.DtAlteracao);

                return cmd.ExecuteNonQuery();
            }
        }
        public int Update(Produto obj)
        {
            using (var con = AppConexao.Conexao)
            {
                var cmd = new SqlCommand();
                cmd.Connection = con as SqlConnection;

                cmd.CommandText = @"UPDATE PRODUTOS SET DESCRICAO = @DESCRICAO, MARCA = @MARCA, 
                                    PRECO = @PRECO, DTCADASTRO = @DTCADASTRO, DTALTERACAO = @DTALTERACAO 
                                    WHERE ID = @ID";

                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@Marca", obj.Marca);
                cmd.Parameters.AddWithValue("@Preco", obj.Preco);
                cmd.Parameters.AddWithValue("@DtCadastro", obj.DtCadastro);
                cmd.Parameters.AddWithValue("@DtAlteracao", obj.DtAlteracao);

                return cmd.ExecuteNonQuery();
            }
        }
        public int Delete(Produto obj)
        {
            using (var con = AppConexao.Conexao)
            {
                var cmd = new SqlCommand();
                cmd.Connection = con as SqlConnection;

                cmd.CommandText = @"DELETE FROM PRODUTOS WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@Id", obj.Id);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}