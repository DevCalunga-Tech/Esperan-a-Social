using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsperancaSocial.Desktop.Data;
using EsperancaSocial.Desktop.Models;
using System.Data.SqlClient;

namespace EsperancaSocial.Desktop.Controllers
{
    public class FamiliaController
    {

        public void Inserir(FamiliaModel familia)
        {
            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = @"
                    INSERT INTO Familia
                    (nome_responsavel, telefone, endereco, bairro,
                     numero_membros, renda_familiar, situacao)
                    VALUES
                    (@nome, @telefone, @endereco, @bairro,
                     @num, @renda, @situacao)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", familia.NomeResponsavel);
                cmd.Parameters.AddWithValue("@telefone", familia.Telefone);
                cmd.Parameters.AddWithValue("@endereco", familia.Endereco);
                cmd.Parameters.AddWithValue("@bairro", familia.Bairro);
                cmd.Parameters.AddWithValue("@num", familia.NumeroMembros);
                cmd.Parameters.AddWithValue("@renda", familia.RendaFamiliar);
                cmd.Parameters.AddWithValue("@situacao", familia.Situacao);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Atualizar(FamiliaModel familia)
        {
            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = @"
            UPDATE Familia SET
                nome_responsavel = @nome,
                telefone = @telefone,
                endereco = @endereco,
                bairro = @bairro,
                numero_membros = @num,
                renda_familiar = @renda,
                situacao = @situacao
            WHERE id_familia = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", familia.NomeResponsavel);
                cmd.Parameters.AddWithValue("@telefone", familia.Telefone);
                cmd.Parameters.AddWithValue("@endereco", familia.Endereco);
                cmd.Parameters.AddWithValue("@bairro", familia.Bairro);
                cmd.Parameters.AddWithValue("@num", familia.NumeroMembros);
                cmd.Parameters.AddWithValue("@renda", familia.RendaFamiliar);
                cmd.Parameters.AddWithValue("@situacao", familia.Situacao);
                cmd.Parameters.AddWithValue("@id", familia.IdFamilia);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Excluir(int idFamilia)
        {
            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = "DELETE FROM Familia WHERE id_familia = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idFamilia);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public List<FamiliaModel> Listar()
        {
            List<FamiliaModel> lista = new List<FamiliaModel>();

            using (SqlConnection conn = Conexao.ObterConexao())
            {
                string sql = "SELECT * FROM Familia";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new FamiliaModel
                    {
                        IdFamilia = (int)dr["id_familia"],
                        NomeResponsavel = dr["nome_responsavel"].ToString(),
                        Telefone = dr["telefone"].ToString(),
                        Endereco = dr["endereco"].ToString(),
                        Bairro = dr["bairro"].ToString(),
                        NumeroMembros = dr["numero_membros"] != DBNull.Value ? (int)dr["numero_membros"] : 0,
                        RendaFamiliar = dr["renda_familiar"] != DBNull.Value ? (decimal)dr["renda_familiar"] : 0,
                        DataCadastro = (DateTime)dr["data_cadastro"],
                        Situacao = dr["situacao"].ToString()
                    });
                }
            }
            return lista;
        }

    }
}

