﻿using Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
                throw new Exception("Ocorreu um erro ao tentar inserir um Grupo de usuário no banco " + ex.Message) { Data = { { "Id", 22 } } };


            }
            finally
            {
                cn.Close();
            }


        }

        public List<GrupoUsuario> BuscarTodosGrupos()
        {
            List<GrupoUsuario> grupo_usuarios = new List<GrupoUsuario>();
            GrupoUsuario grupousuario;
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = "SELECT id_GrupoUsuario, NomeGrupo FROM GrupoUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        grupousuario = new GrupoUsuario();
                        grupousuario.Id = Convert.ToInt32(rd["id_GrupoUsuario"]);
                        grupousuario.NomeGrupo = rd["NomeGrupo"].ToString();
                        PermissaoDAL permissaoDAL = new PermissaoDAL();
                        grupousuario.Permissoes = permissaoDAL.BuscarPermissoesPor_IdGrupo(grupousuario.Id);


                        grupo_usuarios.Add(grupousuario);
                    }
                }
                return grupo_usuarios;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar Buscar Todos os Grupo de Usuarios no Banco: " + ex.Message) { Data = { { "Id", 23 } } };
            }
            finally
            {
                cn.Close();
            }

        }

        //***********************************************************************************************************************
        public List<GrupoUsuario> BuscarTodosGrupos_PorNome(string _nome)
        {
            List<GrupoUsuario> grupo_usuarios = new List<GrupoUsuario>();
            GrupoUsuario grupousuario;
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = "SELECT id_GrupoUsuario, NomeGrupo FROM GrupoUsuario WHERE UPPER(NomeGrupo) like UPPER(@nome)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@nome", "%" + _nome + "%");
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        grupousuario = new GrupoUsuario();
                        grupousuario.Id = Convert.ToInt32(rd["id_GrupoUsuario"]);
                        grupousuario.NomeGrupo = rd["NomeGrupo"].ToString();


                        grupo_usuarios.Add(grupousuario);
                    }
                }
                return grupo_usuarios;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar Buscar Grupo de Usuarios por Nome no Banco: " + ex.Message) { Data = { { "Id", 24 } } };
            }
            finally
            {
                cn.Close();
            }

        }


        //***********************************************************************************************************************

        public List<GrupoUsuario> BuscarTodos_GruposPorUsuario(int _id_Usuario)
        {
            List<GrupoUsuario> vincular_usuario_grupos = new List<GrupoUsuario>();
            GrupoUsuario grupousuario = new GrupoUsuario();
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT  GU.id_GrupoUsuario,	GU.NomeGrupo FROM  Usuario U " +
                    "INNER JOIN Grupo_com_Usuario_N_N G ON U.id_Usuario = G.cod_usuario " +
                    "INNER JOIN GrupoUsuario GU ON G.cod_GrupoUsuario = GU.id_GrupoUsuario WHERE U.id_Usuario = @id";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", _id_Usuario);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {

                    while (rd.Read())
                    {
                        grupousuario = new GrupoUsuario();
                        grupousuario.Id = Convert.ToInt32(rd["id_GrupoUsuario"]);
                        grupousuario.NomeGrupo = rd["NomeGrupo"].ToString();


                        vincular_usuario_grupos.Add(grupousuario);

                    }

                }
                return vincular_usuario_grupos;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar Buscar Grupo de Ususario por ID no Banco: " + ex.Message) { Data = { { "Id", 25} } };
            }
            finally
            {
                cn.Close();
            }

        }


        //*********************************************************************************************************************
        public List<GrupoUsuario> BuscarGrupoPorNome(string _nomeGrupo)
        {
            List<GrupoUsuario> grupoUsuarios = new List<GrupoUsuario>();
            GrupoUsuario grupousuario;
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = "SELECT id_GrupoUsuario, NomeGrupo FROM GrupoUsuario WHERE UPPER(NomeGrupo) LIKE UPPER(@nome)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@nome", "%" + _nomeGrupo + "%");
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {

                    while (rd.Read())
                    {
                        grupousuario = new GrupoUsuario();
                        grupousuario.Id = Convert.ToInt32(rd["id_GrupoUsuario"]);
                        grupousuario.NomeGrupo = rd["NomeGrupo"].ToString();
                        PermissaoDAL permissaoDAL = new PermissaoDAL();
                        grupousuario.Permissoes = permissaoDAL.BuscarPermissoesPor_IdGrupo(grupousuario.Id);

                        grupoUsuarios.Add(grupousuario);

                    }

                    return grupoUsuarios;

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar buscar todos os usuários: " + ex.Message) { Data = { { "Id", 26 } } };
            }
            finally
            {
                cn.Close();
            }
        }

        //****************************************************************************************************************************
        public GrupoUsuario BuscarGrupoPor_Id(int _idGrupo)
        {
            GrupoUsuario grupousuario = new GrupoUsuario();
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = "SELECT id_GrupoUsuario, NomeGrupo FROM GrupoUsuario WHERE id_GrupoUsuario = @id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", _idGrupo);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        grupousuario = new GrupoUsuario();
                        grupousuario.Id = Convert.ToInt32(rd["id_GrupoUsuario"]);
                        grupousuario.NomeGrupo = rd["NomeGrupo"].ToString();
                        PermissaoDAL permissaoDAL = new PermissaoDAL();
                        grupousuario.Permissoes = permissaoDAL.BuscarPermissoesPor_IdGrupo(grupousuario.Id);

                    }
                    else
                    {
                        throw new Exception("Usuario não encontrado.");
                    }
                    return grupousuario;

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar Buscar Grupo de Usuário por Id do Grupo: " + ex.Message) { Data = { { "Id", 27 } } };
            }
            finally
            {
                cn.Close();
            }
        }

        //****************************************************************************************************************************


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
                throw new Exception("Ocorreu um erro ao tentar Alterar um Grupo no banco " + ex.Message) { Data = { { "Id", 28 } } };


            }
            finally
            {
                cn.Close();
            }


        }

        public void Excluir(GrupoUsuario _idGrupoUsuario, SqlTransaction _transaction = null)
        {
            SqlTransaction transaction = _transaction;
            using (SqlConnection cn = new SqlConnection(Conexao.StringDeConexao))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM GrupoUsuario WHERE id_GrupoUsuario= @id", cn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", _idGrupoUsuario.Id);
                    try
                    {
                        if (_transaction == null)
                        {
                            cn.Open();
                            transaction = cn.BeginTransaction();
                        }
                        cmd.Transaction = transaction;
                        cmd.Connection = transaction.Connection;

                        RemoverTodos_VinculoGrupoPermissao(_idGrupoUsuario, transaction);
                        RemoverTotos_VinculoGrupoUsuario(_idGrupoUsuario, transaction);
                        cmd.ExecuteNonQuery();
                        if (_transaction == null)
                        {
                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocorreu um erro ao tentar Excluir um Grupo de Usuário do banco " + ex.Message) { Data = { { "Id", 28 } } };
                    }

                }
            }
        }

        private void RemoverTotos_VinculoGrupoUsuario(GrupoUsuario _idGrupoUsuario, SqlTransaction _transaction)
        {
            SqlTransaction transaction = _transaction;
            using (SqlConnection cn = new SqlConnection(Conexao.StringDeConexao))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Grupo_com_Usuario_N_N WHERE cod_GrupoUsuario= @id", cn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", _idGrupoUsuario.Id);
                    try
                    {
                        if (_transaction == null)
                        {
                            cn.Open();
                            transaction = cn.BeginTransaction();
                        }
                        cmd.Transaction = transaction;
                        cmd.Connection = transaction.Connection;

                      
                        cmd.ExecuteNonQuery();
                        if (_transaction == null)
                        {
                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocorreu um erro ao tentar Remover o Vínculo do Usuário com o Grupo do Banco " + ex.Message) { Data = { { "Id", 29 } } };
                    }

                }
            }
        }




        /*
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
        *///antigo metodo de excluir
        public void RemoverVinculoGrupoPermissao(int _id_grupo, int _id_permissao)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "DELETE FROM Permissao_com_Grupo WHERE cod_GrupoUsuario = @idgrupo AND cod_Permissao = @idpermissao";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@idgrupo", _id_grupo);
                cmd.Parameters.AddWithValue("@idpermissao", _id_permissao);


                cn.Open();
                cmd.ExecuteScalar();


            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar Remover um Vinculo de Permissão com o Grupo do Banco " + ex.Message) { Data = { { "Id", 30 } } };


            }
            finally
            {
                cn.Close();
            }
        }

        public bool ExisteVinculo_GrupoComUsuario(GrupoUsuario _idGrupo)
        {
            GrupoUsuario grupoUsuario = new GrupoUsuario();
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT 1 AS retorno FROM Grupo_com_Usuario_N_N  WHERE cod_GrupoUsuario = @idGrupo ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@idGrupo", _idGrupo.Id);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar Verificar se há vínculo entre Grupo e Usuário: " + ex.Message) { Data = { { "Id", 31 } } };
            }
            finally
            {
                cn.Close();
            }
        }

        public void VincularPermissaoGrupo(int _idGrupo, int _idPermissao)
        {
            SqlConnection cn = new SqlConnection();
            try
            {

                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO Permissao_com_Grupo(cod_GrupoUsuario,cod_Permissao)" +
                                  "VALUES (@idGrupo,@idPermissao)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@idGrupo", _idGrupo);
                cmd.Parameters.AddWithValue("@idPermissao", _idPermissao);


                cn.Open();
                cmd.ExecuteScalar();


            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar Víncular Permissão com Grupo no Banco " + ex.Message) { Data = { { "Id", 32 } } };


            }
            finally
            {
                cn.Close();
            }

        }

        internal List<GrupoUsuario> BuscarGrupoPor_IdPermissao(int _idPermissao)
        {
            List<GrupoUsuario> grupo_usuarios = new List<GrupoUsuario>();
            GrupoUsuario grupousuario;
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                cmd.Connection = cn;
                cmd.CommandText = "SELECT id_GrupoUsuario, NomeGrupo FROM Permissao P INNER JOIN Permissao_com_Grupo PG ON P.id_Permissao = PG.cod_Permissao INNER JOIN GrupoUsuario GU ON PG.cod_GrupoUsuario = GU.id_GrupoUsuario WHERE P.id_Permissao = @id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@id", _idPermissao);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        grupousuario = new GrupoUsuario();
                        grupousuario.Id = Convert.ToInt32(rd["id_GrupoUsuario"]);
                        grupousuario.NomeGrupo = rd["NomeGrupo"].ToString();
                        PermissaoDAL permissaoDAL = new PermissaoDAL();
                        grupousuario.Permissoes = permissaoDAL.BuscarPermissoesPor_IdGrupo(grupousuario.Id);


                        grupo_usuarios.Add(grupousuario);
                    }
                }
                return grupo_usuarios;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao tentar buscar Grupo de Usuarios por Id da Permissão no Banco: " + ex.Message) { Data = { { "Id", 33 } } };
            }
            finally
            {
                cn.Close();
            }

        }


        private void RemoverTodos_VinculoGrupoPermissao(GrupoUsuario _idGrupoUsuario, SqlTransaction _transaction)
        {
            SqlTransaction transaction = _transaction;
            using (SqlConnection cn = new SqlConnection(Conexao.StringDeConexao))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Permissao_com_Grupo WHERE cod_GrupoUsuario = @id", cn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", _idGrupoUsuario.Id);
                    try
                    {
                        if (_transaction == null)
                        {
                            cn.Open();
                            transaction = cn.BeginTransaction();
                        }
                        cmd.Transaction = transaction;
                        cmd.Connection = transaction.Connection;
               
                        cmd.ExecuteNonQuery();
                        if (_transaction == null)
                        {
                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocorreu um erro ao tentar Remover Vínculo de um Grupo com Permissão " + ex.Message) { Data = { { "Id", 34 } } };
                    }

                }
            }
        }
    }
}