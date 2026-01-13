using EsperancaSocial.Desktop.Data;
using EsperancaSocial.Desktop.Models;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EsperancaSocial.Desktop.Controllers
{
    public class LoginController
    {
        public UsuarioModel Autenticar(string username, string senha)
        {
            UsuarioModel usuario = null;

            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = @"
                    SELECT id_usuario, username, senha_hash, nivel_acesso, ativo
                    FROM Usuario
                    WHERE username = @username
                      AND senha_hash = @senha
                      AND ativo = 1";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@senha", senha);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                   
                    usuario = new UsuarioModel
                    {
                        IdUsuario = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        SenhaHash = reader.GetString(2),
                        NivelAcesso = reader.GetString(3),
                        Ativo = reader.GetBoolean(4)
                    };
                }
            }

            return usuario;
        }
    }
}
