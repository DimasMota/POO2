﻿using BLL;
using Models;

namespace ConsoleAppPrincipal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int opc_menu;
            do
            {
                Console.WriteLine("CADASTRO DE USUÁRIO\n\n");
                Console.WriteLine("[1]USUÁRIO\n" +
                                  "[2]GRUPO DE USUÁRIO\n" +
                                  "[3]PERMISSÕES\n" +
                                  "[0]SAIR");
                Console.WriteLine("Olá Mundo");
                opc_menu = Convert.ToInt32(Console.ReadLine());


                if (opc_menu == 1)
                {
                    int opc_usuario;
                    Console.WriteLine("[1]CADASTRAR USUÁRIO\n" +
                                      "[2]ALTERAR USUÁRIO\n" +
                                      "[3]BUSCAR USUÁRIO\n" +
                                      "[4]EXCLUIR USUÁRIO\n" +
                                      "[0]SAIR\n");

                    opc_usuario = Convert.ToInt32(Console.ReadLine());
                    if (opc_usuario == 1)
                    {

                        try
                        {
                            Usuario usuario = new Usuario();
                            UsuarioBLL usuarioBLL = new UsuarioBLL();
                            string sim_nao;
                            do
                            {

                                Console.WriteLine("CADASTRO DE USUÁRIO\n\n");
                                Console.WriteLine("Nome Completo: ");
                                usuario.Nome = Console.ReadLine();
                                Console.WriteLine("Nome de acesso do Usuário");
                                usuario.NomeUsuario = Console.ReadLine();
                                Console.WriteLine("Data de Nascimento");
                                usuario.DataNascimento = Console.ReadLine();
                                Console.WriteLine("CPF do Usuário: ");
                                usuario.Cpf = Console.ReadLine();
                                Console.WriteLine("Senha:");
                                usuario.Senha = Console.ReadLine();
                                Console.WriteLine("Digite seu E_mail");
                                usuario.Email = Console.ReadLine();
                                Console.WriteLine("Usuario Ativo [S]SIM  [N]NÃO :");
                                usuario.Ativo = Console.ReadLine().ToUpper() == "S";


                                Console.WriteLine("Deseja Salvar Usuário?");
                                 sim_nao = Console.ReadLine().ToUpper();
                                if (sim_nao == "S")
                                {
                                    usuarioBLL.Inserir(usuario);

                                }

                                Console.WriteLine("Deseja cadastrar outro Usuário?: [S]SIM [N]NÃO");
                                sim_nao = Console.ReadLine().ToUpper();
                            } while(sim_nao == "S");



                           

                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                    }

                }








            } while (opc_menu != 0);

        }
    }
}