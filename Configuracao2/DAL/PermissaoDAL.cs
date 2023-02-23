﻿using Models;
using System.Data.SqlClient;


namespace DAL
{
    public class PermissaoDAL
    {
        public void Inserir(Permissao _permissao)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO Permissao(Descricao)" +
                                  "VALUES (@descricao)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@descricao", _permissao.Descricao);


                cn.Open();
                cmd.ExecuteScalar();


            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um usuário no banco " + ex.Message);


            }
            finally
            {
                cn.Close();
            }


        }

        public Permissao Buscar(string _descricaoPermissao)
        {
            return new Permissao();
        }
        public void Alterar(Permissao _permissao)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE Permissao SET Descricao = @descricao WHERE id_Permissao = @id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@descricao", _permissao.Descricao);
                cmd.Parameters.AddWithValue("@id", _permissao.Id);


                cn.Open();
                cmd.ExecuteScalar();


            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um usuário no banco " + ex.Message);


            }
            finally
            {
                cn.Close();
            }


        }

        public void Excluir(Permissao _idPermissao)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM Permissao WHERE id_Permissao= @id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@id", _idPermissao.Id);


                cn.Open();
                cmd.ExecuteScalar();


            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um usuário no banco " + ex.Message);


            }
            finally
            {
                cn.Close();
            }

        }

    }
}