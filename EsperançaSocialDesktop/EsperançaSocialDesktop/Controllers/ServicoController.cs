using EsperancaSocial.Desktop.Data;
using EsperançaSocialDesktop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EsperançaSocialDesktop.Controllers
{
    internal class ServicoController
    {
        // Lista todos os serviços com o nome do projeto
        public List<ServicoModel> Listar()
        {
            List<ServicoModel> servicos = new List<ServicoModel>();

            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = @"
                    SELECT s.Id_servico, s.Nome_servico, s.Descricao, s.Categoria, s.Periodicidade, s.Ativo,
                           s.Id_Projeto, p.Nome_Projeto AS NomeProjecto
                    FROM Servico s
                    INNER JOIN Projeto p ON s.Id_Projeto = p.Id_Projeto
                    ORDER BY s.Nome_servico";

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    servicos.Add(new ServicoModel
                    {
                        IdServico = Convert.ToInt32(reader["Id_servico"]),
                        NomeServico = reader["Nome_servico"].ToString(),
                        Descricao = reader["Descricao"].ToString(),
                        Categoria = reader["Categoria"].ToString(),
                        Periodicidade = reader["Periodicidade"].ToString(),
                        Ativo = Convert.ToBoolean(reader["Ativo"]),
                        IdProjecto = Convert.ToInt32(reader["Id_Projeto"]),
                        NomeProjecto = reader["NomeProjecto"].ToString()
                    });
                }
            }

            return servicos;
        }

        // Inserir novo serviço
        public void Inserir(ServicoModel servico)
        {
            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = @"
                    INSERT INTO Servico (Nome_servico, Descricao, Categoria, Periodicidade, Ativo, Id_Projeto)
                    VALUES (@NomeServico, @Descricao, @Categoria, @Periodicidade, @Ativo, @IdProjecto)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@NomeServico", servico.NomeServico);
                cmd.Parameters.AddWithValue("@Descricao", (object)servico.Descricao ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Categoria", (object)servico.Categoria ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Periodicidade", (object)servico.Periodicidade ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Ativo", servico.Ativo);
                cmd.Parameters.AddWithValue("@IdProjecto", servico.IdProjecto);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Atualizar serviço existente
        public void Atualizar(ServicoModel servico)
        {
            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = @"
                    UPDATE Servico
                    SET Nome_servico = @NomeServico,
                        Descricao = @Descricao,
                        Categoria = @Categoria,
                        Periodicidade = @Periodicidade,
                        Ativo = @Ativo,
                        Id_Projeto = @IdProjecto
                    WHERE Id_servico = @IdServico";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdServico", servico.IdServico);
                cmd.Parameters.AddWithValue("@NomeServico", servico.NomeServico);
                cmd.Parameters.AddWithValue("@Descricao", (object)servico.Descricao ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Categoria", (object)servico.Categoria ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Periodicidade", (object)servico.Periodicidade ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Ativo", servico.Ativo);
                cmd.Parameters.AddWithValue("@IdProjecto", servico.IdProjecto);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Excluir serviço
        public void Excluir(int idServico)
        {
            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = "DELETE FROM Servico WHERE Id_servico = @IdServico";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdServico", idServico);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Buscar serviço por ID
        public ServicoModel ObterPorId(int idServico)
        {
            ServicoModel servico = null;

            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = @"
                    SELECT s.Id_servico, s.Nome_servico, s.Descricao, s.Categoria, s.Periodicidade, s.Ativo,
                           s.Id_Projeto, p.Nome_Projeto AS NomeProjecto
                    FROM Servico s
                    INNER JOIN Projeto p ON s.Id_Projeto = p.Id_Projeto
                    WHERE s.Id_servico = @IdServico";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdServico", idServico);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    servico = new ServicoModel
                    {
                        IdServico = Convert.ToInt32(reader["Id_servico"]),
                        NomeServico = reader["Nome_servico"].ToString(),
                        Descricao = reader["Descricao"].ToString(),
                        Categoria = reader["Categoria"].ToString(),
                        Periodicidade = reader["Periodicidade"].ToString(),
                        Ativo = Convert.ToBoolean(reader["Ativo"]),
                        IdProjecto = Convert.ToInt32(reader["Id_Projeto"]),
                        NomeProjecto = reader["NomeProjecto"].ToString()
                    };
                }
            }

            return servico;
        }
    }
}
