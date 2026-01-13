using EsperancaSocial.Desktop.Data;
using EsperançaSocialDesktop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EsperançaSocialDesktop.Controllers
{
    internal class AgendamentoController
    {
        // LISTAR todos os agendamentos com nomes da família e funcionário
        public List<AgendamentoModel> Listar()
        {
            var lista = new List<AgendamentoModel>();

            try
            {
                using (var con = Conexao.ObterConexao())
                {
                    string sql = @"
                        SELECT a.id_agendamento,
                               a.id_familia, f.nome_responsavel,
                               a.id_funcionario, fu.Nome,
                               a.data_agendada,
                               a.tipo_servico,
                               a.status
                        FROM Agendamento a
                        INNER JOIN Familia f ON a.id_familia = f.id_familia
                        INNER JOIN Funcionario fu ON a.id_funcionario = fu.id_funcionario
                        ORDER BY a.data_agendada";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new AgendamentoModel
                        {
                            IdAgendamento = Convert.ToInt32(reader["id_agendamento"]),
                            IdFamilia = Convert.ToInt32(reader["id_familia"]),
                            NomeFamilia = reader["nome_responsavel"].ToString(),
                            IdFuncionario = Convert.ToInt32(reader["id_funcionario"]),
                            NomeFuncionario = reader["Nome"].ToString(),
                            DataAgendada = Convert.ToDateTime(reader["data_agendada"]),
                            TipoServico = reader["tipo_servico"]?.ToString(),
                            Status = reader["status"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar agendamentos: " + ex.Message);
            }

            return lista;
        }

        // INSERIR novo agendamento
        public void Inserir(AgendamentoModel agendamento)
        {
            if (agendamento.IdFamilia <= 0 || agendamento.IdFuncionario <= 0)
                throw new Exception("Família e Funcionário devem ser selecionados.");

            if (string.IsNullOrWhiteSpace(agendamento.TipoServico))
                throw new Exception("O campo Tipo de Serviço é obrigatório.");

            try
            {
                using (var con = Conexao.ObterConexao())
                {
                    string sql = @"
                        INSERT INTO Agendamento
                        (id_familia, id_funcionario, data_agendada, tipo_servico, status)
                        VALUES
                        (@id_familia, @id_funcionario, @data_agendada, @tipo_servico, @status)";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id_familia", agendamento.IdFamilia);
                    cmd.Parameters.AddWithValue("@id_funcionario", agendamento.IdFuncionario);
                    cmd.Parameters.AddWithValue("@data_agendada", agendamento.DataAgendada);
                    cmd.Parameters.AddWithValue("@tipo_servico", agendamento.TipoServico);
                    cmd.Parameters.AddWithValue("@status", agendamento.Status ?? "Pendente");

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir agendamento: " + ex.Message);
            }
        }

        // ATUALIZAR agendamento existente
        public void Atualizar(AgendamentoModel agendamento)
        {
            if (agendamento.IdAgendamento <= 0)
                throw new Exception("Selecione um agendamento para atualizar.");

            try
            {
                using (var con = Conexao.ObterConexao())
                {
                    string sql = @"
                        UPDATE Agendamento
                        SET id_familia = @id_familia,
                            id_funcionario = @id_funcionario,
                            data_agendada = @data_agendada,
                            tipo_servico = @tipo_servico,
                            status = @status
                        WHERE id_agendamento = @id_agendamento";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id_agendamento", agendamento.IdAgendamento);
                    cmd.Parameters.AddWithValue("@id_familia", agendamento.IdFamilia);
                    cmd.Parameters.AddWithValue("@id_funcionario", agendamento.IdFuncionario);
                    cmd.Parameters.AddWithValue("@data_agendada", agendamento.DataAgendada);
                    cmd.Parameters.AddWithValue("@tipo_servico", agendamento.TipoServico);
                    cmd.Parameters.AddWithValue("@status", agendamento.Status ?? "Pendente");

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar agendamento: " + ex.Message);
            }
        }

        // EXCLUIR agendamento
        public void Excluir(int idAgendamento)
        {
            if (idAgendamento <= 0)
                throw new Exception("Selecione um agendamento para excluir.");

            try
            {
                using (var con = Conexao.ObterConexao())
                {
                    string sql = "DELETE FROM Agendamento WHERE id_agendamento = @id_agendamento";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id_agendamento", idAgendamento);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir agendamento: " + ex.Message);
            }
        }
    }
}
