using System;
using System.Data.SqlClient;

namespace PIM_Eventos_Inclusivos.Repositories
{
    public class ParticipanteRepository
    {
        public bool CadastrarParticipante(string nome, string email, string senha)
        {
            ConexaoDB banco = new ConexaoDB();
            
            using (SqlConnection conexao = banco.ObterConexao())
            {
                if (conexao == null) return false;

                string query = "INSERT INTO Participantes (Nome, Email, Senha) VALUES (@Nome, @Email, @Senha)";

                using (SqlCommand comando = new SqlCommand(query, conexao))
                {
                    // A utilização de parâmetros protege o sistema contra ataques de injeção de SQL
                    comando.Parameters.AddWithValue("@Nome", nome);
                    comando.Parameters.AddWithValue("@Email", email);
                    comando.Parameters.AddWithValue("@Senha", senha);

                    int linhasAfetadas = comando.ExecuteNonQuery();
                    
                    return linhasAfetadas > 0;
                }
            }
        }
    }
}