using EsperancaSocial.Desktop.Data;
using EsperancaSocial.Desktop.Models;
using EsperançaSocialDesktop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EsperancaSocial.Desktop.Controllers
{
    public class IndividuoController
    {
        // Inserir novo indivíduo
        public void Inserir(IndividuoModel individuo)
        {
            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = @"INSERT INTO Individuo 
                    (id_familia, nome, data_nascimento, genero, escolaridade, parentesco, condicao_saude, observacoes)
                    VALUES (@idFamilia, @nome, @dataNasc, @genero, @escolaridade, @parentesco, @condicao, @obs)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idFamilia", individuo.IdFamilia);
                cmd.Parameters.AddWithValue("@nome", individuo.Nome);
                cmd.Parameters.AddWithValue("@dataNasc", individuo.DataNascimento);
                cmd.Parameters.AddWithValue("@genero", individuo.Genero);
                cmd.Parameters.AddWithValue("@escolaridade", individuo.Escolaridade);
                cmd.Parameters.AddWithValue("@parentesco", individuo.Parentesco);
                cmd.Parameters.AddWithValue("@condicao", individuo.CondicaoSaude);
                cmd.Parameters.AddWithValue("@obs", individuo.Observacoes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Atualizar indivíduo existente
        public void Atualizar(IndividuoModel individuo)
        {
            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = @"UPDATE Individuo SET
                    id_familia = @idFamilia,
                    nome = @nome,
                    data_nascimento = @dataNasc,
                    genero = @genero,
                    escolaridade = @escolaridade,
                    parentesco = @parentesco,
                    condicao_saude = @condicao,
                    observacoes = @obs
                    WHERE id_individuo = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idFamilia", individuo.IdFamilia);
                cmd.Parameters.AddWithValue("@nome", individuo.Nome);
                cmd.Parameters.AddWithValue("@dataNasc", individuo.DataNascimento);
                cmd.Parameters.AddWithValue("@genero", individuo.Genero);
                cmd.Parameters.AddWithValue("@escolaridade", individuo.Escolaridade);
                cmd.Parameters.AddWithValue("@parentesco", individuo.Parentesco);
                cmd.Parameters.AddWithValue("@condicao", individuo.CondicaoSaude);
                cmd.Parameters.AddWithValue("@obs", individuo.Observacoes);
                cmd.Parameters.AddWithValue("@id", individuo.IdIndividuo);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Excluir indivíduo
        public void Excluir(int idIndividuo)
        {
            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = "DELETE FROM Individuo WHERE id_individuo = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idIndividuo);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Listar todos os indivíduos (com nome da família)
        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = @"SELECT i.id_individuo, i.nome, i.data_nascimento, i.genero, i.escolaridade,
                                      i.parentesco, i.condicao_saude, i.observacoes, f.nome_responsavel AS Familia
                               FROM Individuo i
                               INNER JOIN Familia f ON i.id_familia = f.id_familia
                               ORDER BY i.nome";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }
        public List<IndividuoModel> ListarCombo()
        {
            List<IndividuoModel> lista = new List<IndividuoModel>();

            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = "SELECT id_individuo, nome FROM Individuo ORDER BY nome";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new IndividuoModel
                    {
                        IdIndividuo = Convert.ToInt32(dr["id_individuo"]),
                        Nome = dr["nome"].ToString()
                    });
                }
            }

            return lista;
        }
    }
}
