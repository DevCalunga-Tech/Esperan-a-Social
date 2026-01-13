using EsperancaSocial.Desktop.Data;
using EsperançaSocialDesktop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsperançaSocialDesktop.Controllers
{
    internal class ProjectoController
    {
        // LISTAR
        public List<ProjectoModel> Listar()
        {
            List<ProjectoModel> projectos = new List<ProjectoModel>();

            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = @"
                    SELECT id_projeto, nome_projeto, data_inicio, data_fim, descricao, status
                    FROM Projeto
                    ORDER BY data_inicio DESC";

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    projectos.Add(new ProjectoModel
                    {
                        IdProjecto = Convert.ToInt32(reader["id_projeto"]),
                        NomeProjecto = reader["nome_projeto"].ToString(),
                        DataInicio = Convert.ToDateTime(reader["data_inicio"]),
                        DataFim = reader["data_fim"] == DBNull.Value
                                    ? (DateTime?)null
                                    : Convert.ToDateTime(reader["data_fim"]),
                        Descricao = reader["descricao"].ToString(),
                        Status = reader["status"].ToString()
                    });
                }
            }

            return projectos;
        }

        // INSERIR
        public void Inserir(ProjectoModel projecto)
        {
            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = @"
                    INSERT INTO Projeto
                    (nome_projeto, data_inicio, data_fim, descricao, status)
                    VALUES
                    (@NomeProjecto, @DataInicio, @DataFim, @Descricao, @Status)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@NomeProjecto", projecto.NomeProjecto);
                cmd.Parameters.AddWithValue("@DataInicio", projecto.DataInicio);
                cmd.Parameters.AddWithValue("@DataFim", (object)projecto.DataFim ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Descricao", projecto.Descricao);
                cmd.Parameters.AddWithValue("@Status", projecto.Status);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ATUALIZAR
        public void Atualizar(ProjectoModel projecto)
        {
            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = @"
                    UPDATE Projeto
                    SET nome_projeto = @NomeProjecto,
                        data_inicio = @DataInicio,
                        data_fim = @DataFim,
                        descricao = @Descricao,
                        status = @Status
                    WHERE id_projeto = @IdProjecto";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdProjecto", projecto.IdProjecto);
                cmd.Parameters.AddWithValue("@NomeProjecto", projecto.NomeProjecto);
                cmd.Parameters.AddWithValue("@DataInicio", projecto.DataInicio);
                cmd.Parameters.AddWithValue("@DataFim", (object)projecto.DataFim ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Descricao", projecto.Descricao);
                cmd.Parameters.AddWithValue("@Status", projecto.Status);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // EXCLUIR
        public void Excluir(int idProjecto)
        {
            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = "DELETE FROM Projeto WHERE id_projeto = @IdProjecto";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdProjecto", idProjecto);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
