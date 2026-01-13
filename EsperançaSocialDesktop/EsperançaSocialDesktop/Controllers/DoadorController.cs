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
    internal class DoadorController
    {
        // Listar todos os doadores
        public List<DoadorModel> Listar()
        {
            var lista = new List<DoadorModel>();

            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = "SELECT * FROM doador";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new DoadorModel
                    {
                        IdDoador = (int)dr["id_doador"],
                        Nome = dr["nome"].ToString(),
                        Telefone = dr["telefone"].ToString(),
                        Email = dr["email"].ToString(),
                        Tipo = dr["tipo"].ToString()
                    });
                }
            }

            return lista;
        }

        // Inserir um novo doador
        public void Inserir(DoadorModel d)
        {
            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = @"INSERT INTO doador (nome, telefone, email, tipo)
                               VALUES (@nome, @telefone, @email, @tipo)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nome", d.Nome);
                cmd.Parameters.AddWithValue("@telefone", d.Telefone);
                cmd.Parameters.AddWithValue("@email", d.Email);
                cmd.Parameters.AddWithValue("@tipo", d.Tipo);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Atualizar(DoadorModel d)
        {
            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = @"UPDATE doador 
                       SET nome = @nome,
                           telefone = @telefone,
                           email = @email,
                           tipo = @tipo
                       WHERE id_doador = @id";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nome", d.Nome);
                cmd.Parameters.AddWithValue("@telefone", d.Telefone);
                cmd.Parameters.AddWithValue("@email", d.Email);
                cmd.Parameters.AddWithValue("@tipo", d.Tipo);
                cmd.Parameters.AddWithValue("@id", d.IdDoador);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Excluir doador pelo ID
        public void Excluir(int id)
        {
            using (SqlConnection con = Conexao.ObterConexao())
            {
                string sql = "DELETE FROM doador WHERE id_doador = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
