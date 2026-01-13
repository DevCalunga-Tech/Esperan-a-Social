using EsperancaSocial.Desktop.Data;
using EsperancaSocial.Desktop.Models;
using EsperançaSocialDesktop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EsperancaSocial.Desktop.Controllers
{
    public class AtendimentoController
    {
        // =======================
        // LISTAR
        // =======================
        public List<AtendimentoModel> Listar()
        {
            List<AtendimentoModel> lista = new List<AtendimentoModel>();

            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = @"
                    SELECT 
                        a.id_atendimento,
                        a.id_familia,
                        f.nome_responsavel AS nome_familia,
                        a.id_individuo,
                        i.nome AS nome_individuo,
                        a.id_servico,
                        s.nome_servico,
                        a.id_funcionario,
                        fu.nome AS nome_funcionario,
                        a.data_atendimento,
                        a.tipo_atendimento,
                        a.observacoes
                    FROM Atendimento a
                    INNER JOIN Familia f ON a.id_familia = f.id_familia
                    LEFT JOIN Individuo i ON a.id_individuo = i.id_individuo
                    INNER JOIN Servico s ON a.id_servico = s.id_servico
                    INNER JOIN Funcionario fu ON a.id_funcionario = fu.id_funcionario
                    ORDER BY a.data_atendimento DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new AtendimentoModel
                    {
                        IdAtendimento = Convert.ToInt32(dr["id_atendimento"]),
                        IdFamilia = Convert.ToInt32(dr["id_familia"]),
                        NomeFamilia = dr["nome_familia"].ToString(),

                        IdIndividuo = dr["id_individuo"] != DBNull.Value
                            ? Convert.ToInt32(dr["id_individuo"])
                            : (int?)null,

                        NomeIndividuo = dr["nome_individuo"]?.ToString(),

                        IdServico = Convert.ToInt32(dr["id_servico"]),
                        NomeServico = dr["nome_servico"].ToString(),

                        IdFuncionario = Convert.ToInt32(dr["id_funcionario"]),
                        NomeFuncionario = dr["nome_funcionario"].ToString(),

                        DataAtendimento = Convert.ToDateTime(dr["data_atendimento"]),
                        TipoAtendimento = dr["tipo_atendimento"]?.ToString(),
                        Observacoes = dr["observacoes"]?.ToString()
                    });
                }
            }

            return lista;
        }

        // =======================
        // INSERIR
        // =======================
        public void Inserir(AtendimentoModel atendimento)
        {
            Validar(atendimento);

            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = @"
                    INSERT INTO Atendimento
                    (id_familia, id_individuo, id_servico, id_funcionario,
                     data_atendimento, tipo_atendimento, observacoes)
                    VALUES
                    (@id_familia, @id_individuo, @id_servico, @id_funcionario,
                     @data_atendimento, @tipo_atendimento, @observacoes)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_familia", atendimento.IdFamilia);
                cmd.Parameters.AddWithValue("@id_individuo",
                    (object)atendimento.IdIndividuo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id_servico", atendimento.IdServico);
                cmd.Parameters.AddWithValue("@id_funcionario", atendimento.IdFuncionario);
                cmd.Parameters.AddWithValue("@data_atendimento", atendimento.DataAtendimento);
                cmd.Parameters.AddWithValue("@tipo_atendimento", atendimento.TipoAtendimento ?? "");
                cmd.Parameters.AddWithValue("@observacoes", atendimento.Observacoes ?? "");

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // =======================
        // ATUALIZAR
        // =======================
        public void Atualizar(AtendimentoModel atendimento)
        {
            if (atendimento.IdAtendimento <= 0)
                throw new Exception("Selecione um atendimento válido para atualizar.");

            Validar(atendimento);

            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = @"
                    UPDATE Atendimento SET
                        id_familia = @id_familia,
                        id_individuo = @id_individuo,
                        id_servico = @id_servico,
                        id_funcionario = @id_funcionario,
                        data_atendimento = @data_atendimento,
                        tipo_atendimento = @tipo_atendimento,
                        observacoes = @observacoes
                    WHERE id_atendimento = @id_atendimento";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_atendimento", atendimento.IdAtendimento);
                cmd.Parameters.AddWithValue("@id_familia", atendimento.IdFamilia);
                cmd.Parameters.AddWithValue("@id_individuo",
                    (object)atendimento.IdIndividuo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id_servico", atendimento.IdServico);
                cmd.Parameters.AddWithValue("@id_funcionario", atendimento.IdFuncionario);
                cmd.Parameters.AddWithValue("@data_atendimento", atendimento.DataAtendimento);
                cmd.Parameters.AddWithValue("@tipo_atendimento", atendimento.TipoAtendimento ?? "");
                cmd.Parameters.AddWithValue("@observacoes", atendimento.Observacoes ?? "");

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // =======================
        // EXCLUIR
        // =======================
        public void Excluir(int idAtendimento)
        {
            if (idAtendimento <= 0)
                throw new Exception("Selecione um atendimento válido para excluir.");

            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = "DELETE FROM Atendimento WHERE id_atendimento = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idAtendimento);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // =======================
        // VALIDAÇÃO CENTRAL
        // =======================
        private void Validar(AtendimentoModel atendimento)
        {
            if (atendimento.IdFamilia <= 0)
                throw new Exception("Selecione uma família válida.");

            if (atendimento.IdServico <= 0)
                throw new Exception("Selecione um serviço válido.");

            if (atendimento.IdFuncionario <= 0)
                throw new Exception("Selecione um funcionário válido.");
        }
    }
}
