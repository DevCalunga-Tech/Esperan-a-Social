using EsperancaSocial.Desktop.Data;
using EsperancaSocial.Desktop.Models;
using EsperançaSocialDesktop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EsperancaSocial.Desktop.Controllers
{
    public class FuncionarioController
    {
        // Listar todos os funcionários
        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string query = "SELECT id_funcionario, nome, cargo, telefone, email, data_entrada FROM Funcionario ORDER BY nome";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        // Inserir novo funcionário
        public void Inserir(FuncionarioModel funcionario)
        {
            using (SqlConnection conn = Conexao.ObterConexao())
            {
                conn.Open();
                string query = @"INSERT INTO Funcionario (nome, cargo, telefone, email, data_entrada)
                                 VALUES (@nome, @cargo, @telefone, @email, @data_entrada)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@cargo", funcionario.Cargo);
                cmd.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                cmd.Parameters.AddWithValue("@email", funcionario.Email);
                cmd.Parameters.AddWithValue("@data_entrada", funcionario.DataEntrada);
                cmd.ExecuteNonQuery();
            }
        }

        // Atualizar funcionário
        public void Atualizar(FuncionarioModel funcionario)
        {
            using (SqlConnection conn = Conexao.ObterConexao())
            {
                conn.Open();
                string query = @"UPDATE Funcionario SET
                                 nome = @nome,
                                 cargo = @cargo,
                                 telefone = @telefone,
                                 email = @email,
                                 data_entrada = @data_entrada
                                 WHERE id_funcionario = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", funcionario.IdFuncionario);
                cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@cargo", funcionario.Cargo);
                cmd.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                cmd.Parameters.AddWithValue("@email", funcionario.Email);
                cmd.Parameters.AddWithValue("@data_entrada", funcionario.DataEntrada);
                cmd.ExecuteNonQuery();
            }
        }

        // Excluir funcionário
        public void Excluir(int idFuncionario)
        {
            using (SqlConnection conn = Conexao.ObterConexao())
            {
                conn.Open();
                string query = "DELETE FROM Funcionario WHERE id_funcionario = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idFuncionario);
                cmd.ExecuteNonQuery();
            }
        }

        // Buscar funcionário por ID (opcional)
        public FuncionarioModel BuscarPorId(int idFuncionario)
        {
            FuncionarioModel funcionario = null;
            using (SqlConnection conn = Conexao.ObterConexao())
            {
                conn.Open();
                string query = "SELECT * FROM Funcionario WHERE id_funcionario = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idFuncionario);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    funcionario = new FuncionarioModel()
                    {
                        IdFuncionario = Convert.ToInt32(reader["id_funcionario"]),
                        Nome = reader["nome"].ToString(),
                        Cargo = reader["cargo"].ToString(),
                        Telefone = reader["telefone"].ToString(),
                        Email = reader["email"].ToString(),
                        DataEntrada = Convert.ToDateTime(reader["data_entrada"])
                    };
                }
            }
            return funcionario;
        }
        public List<FuncionarioModel> ListarCombo()
        {
            List<FuncionarioModel> lista = new List<FuncionarioModel>();

            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = "SELECT id_funcionario, nome FROM Funcionario ORDER BY nome";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new FuncionarioModel
                    {
                        IdFuncionario = Convert.ToInt32(dr["id_funcionario"]),
                        Nome = dr["nome"].ToString()
                    });
                }
            }

            return lista;
        }
    }
}

