﻿using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class GrupoUsuarioDAL
    {
        public void Inserir(GrupoUsuario _grupousuario)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO GrupoUsuario(NomeGrupo)" +
                                  "VALUES (@nomegrupo)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@nomegrupo", _grupousuario.NomeGrupo);


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

        public GrupoUsuario Buscar(string _grupo)
        {
            return new GrupoUsuario();
        }
        public void Alterar(GrupoUsuario _grupousuario)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE GrupoUsuario SET NomeGrupo = @nomegrupo WHERE id_GrupoUsuario = @id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@nomegrupo", _grupousuario.NomeGrupo);
                cmd.Parameters.AddWithValue("@id", _grupousuario.Id);


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



        public void Excluir(GrupoUsuario _idGrupoUsuario)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM GrupoUsuario WHERE id_GrupoUsuario= @id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", _idGrupoUsuario.Id);


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