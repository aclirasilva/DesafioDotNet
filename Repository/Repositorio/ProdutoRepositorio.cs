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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM PRODUTOS";

                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Produto produto = new Produto();
                    produto.Id = dataReader.GetInt32("Id");
                    produto.Descricao = dataReader.GetString("Description");
                    produto.Preco = dataReader.GetDecimal("Preco");
                    produto.Quatidade = dataReader.GetDecimal("Quantidade");

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
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM PRODUTOS WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader dataReader = cmd.ExecuteReader();
                Produto produto = new Produto();

                while (dataReader.Read())
                {
                    produto.Id = dataReader.GetInt32("Id");
                    produto.Descricao = dataReader.GetString("Description");
                    produto.Preco = dataReader.GetDecimal("Preco");
                    produto.Quatidade = dataReader.GetDecimal("Quantidade");
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

                cmd.CommandText = @"INSERT INTO PRODUTO (ID, DESCRICAO, PRECO, QUANTIDADE) VALUES (@ID, @DESCRICAO, @PRECO, @QUANTIDADE)";

                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@Preco", obj.Preco);
                cmd.Parameters.AddWithValue("@Quatidade", obj.Quatidade);

                return cmd.ExecuteNonQuery();
            }
        }
        public int Update(Produto obj)
        {
            using (var con = AppConexao.Conexao)
            {
                var cmd = new SqlCommand();
                cmd.Connection = con as SqlConnection;

                cmd.CommandText = @"UPDATE PRODUTO SET (ID = @ID, DESCRICAO = @DESCRICAO, PRECO = @PRECO, QUANTIDADE = @QUANTIDADE)";

                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@Preco", obj.Preco);
                cmd.Parameters.AddWithValue("@Quatidade", obj.Quatidade);

                return cmd.ExecuteNonQuery();
            }
        }
        public int Delete(Produto obj)
        {
            using (var con = AppConexao.Conexao)
            {
                var cmd = new SqlCommand();
                cmd.Connection = con as SqlConnection;

                cmd.CommandText = @"DELETE FROM PRODUTO WHERE ID = @ID";
                cmd.Parameters.AddWithValue("@Id", obj.Id);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}