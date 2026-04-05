using System;
using System.Data.SqlClient;

namespace PIM_Eventos_Inclusivos.Database
{
    public class ConexaoDB
    {
        // Altere "NomeDoSeuServidor" para o servidor local da sua máquina
        private readonly string stringConexao = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

        public SqlConnection ObterConexao()
        {
            try
            {
                SqlConnection conexao = new SqlConnection(stringConexao);
                conexao.Open();
                return conexao;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar com o banco de dados: " + ex.Message);
                return null;
            }
        }
    }
}