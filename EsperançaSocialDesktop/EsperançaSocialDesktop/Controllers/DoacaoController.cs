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
    internal class DoacaoController
    {

        // Listar todas as doações com o nome do doador
        public List<DoacaoModel> Listar()
        {
            List<DoacaoModel> doacoes = new List<DoacaoModel>();

            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = @"
                    SELECT d.IdDoacao, d.IdDoador, d.TipoDoacao, d.Descricao, 
                           d.Quantidade, d.ValorEstimado, d.DataDoacao,
                           dr.Nome AS NomeDoador
                    FROM Doacao d
                    INNER JOIN Doador dr ON d.IdDoador = dr.id_doador
                    ORDER BY d.DataDoacao DESC";

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    doacoes.Add(new DoacaoModel
                    {
                        IdDoacao = Convert.ToInt32(reader["IdDoacao"]),
                        IdDoador = Convert.ToInt32(reader["IdDoador"]),
                        TipoDoacao = reader["TipoDoacao"].ToString(),
                        Descricao = reader["Descricao"].ToString(),
                        Quantidade = reader["Quantidade"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["Quantidade"]),
                        ValorEstimado = reader["ValorEstimado"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["ValorEstimado"]),
                        DataDoacao = Convert.ToDateTime(reader["DataDoacao"]),
                        NomeDoador = reader["NomeDoador"].ToString()
                    });
                }
            }

            return doacoes;
        }
        // Inserir nova doação
        public void Inserir(DoacaoModel doacao)
        {
            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = @"
                    INSERT INTO Doacao (IdDoador, TipoDoacao, Descricao, Quantidade, ValorEstimado, DataDoacao)
                    VALUES (@IdDoador, @TipoDoacao, @Descricao, @Quantidade, @ValorEstimado, @DataDoacao)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdDoador", doacao.IdDoador);
                cmd.Parameters.AddWithValue("@TipoDoacao", doacao.TipoDoacao);
                cmd.Parameters.AddWithValue("@Descricao", doacao.Descricao);
                cmd.Parameters.AddWithValue("@Quantidade", (object)doacao.Quantidade ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ValorEstimado", (object)doacao.ValorEstimado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DataDoacao", doacao.DataDoacao);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Atualizar doação existente
        public void Atualizar(DoacaoModel doacao)
        {
            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = @"
                    UPDATE Doacao
                    SET IdDoador = @IdDoador,
                        TipoDoacao = @TipoDoacao,
                        Descricao = @Descricao,
                        Quantidade = @Quantidade,
                        ValorEstimado = @ValorEstimado,
                        DataDoacao = @DataDoacao
                    WHERE IdDoacao = @IdDoacao";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdDoacao", doacao.IdDoacao);
                cmd.Parameters.AddWithValue("@IdDoador", doacao.IdDoador);
                cmd.Parameters.AddWithValue("@TipoDoacao", doacao.TipoDoacao);
                cmd.Parameters.AddWithValue("@Descricao", doacao.Descricao);
                cmd.Parameters.AddWithValue("@Quantidade", (object)doacao.Quantidade ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ValorEstimado", (object)doacao.ValorEstimado ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DataDoacao", doacao.DataDoacao);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Excluir doação
        public void Excluir(int idDoacao)
        {
            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = "DELETE FROM Doacao WHERE IdDoacao = @IdDoacao";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdDoacao", idDoacao);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
