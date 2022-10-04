using AssessmentKaiqueCoelho.Interface;
using AssessmentKaiqueCoelho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssessmentKaiqueCoelho
{
    public class Program
    {
        private static ManipuladorDeAmigos manager = new AmigosInFile();

        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            manager.ExibirAniversario();

            Console.WriteLine("--------------------------------Bem vindo ao gerenciador de aniversário--------------------------------");
            Console.WriteLine("1 -  Cadastrar amigos");
            Console.WriteLine("2 -  Mostrar amigos");
            Console.WriteLine("3 -  Excluir");
            Console.WriteLine("4 -  Atualizar");
            Console.WriteLine("5 -  Procurar");
            Console.WriteLine("6 -  Salvar");
            Console.WriteLine("---> Enter para sair");
            Console.WriteLine("balela");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    CadastrarAmigo();
                    break;
                case "2":
                    MostrarAmigos();
                    break;
                case "3":
                    ExcluirAmigo();
                    break;
                case "4":
                    AtualizarAmigo();
                    break;
                case "5":
                    ProcurarAmigo();
                    break;
                case "6":
                    Salvar();
                    break;
            }
        }
       

        private static void Salvar()
        {
            if (manager is AmigosInFile temp)
            {
                temp.EscreverArquivo();
            }
            Menu();
        }

        private static void CadastrarAmigo()
        {
            Amigos amigos = new Amigos();
            Console.Write("Insira o nome da pessoa:");
            amigos.Nome = Console.ReadLine();
            Console.Write("Insira o sobrenome da pessoa:");
            amigos.SobreNome = Console.ReadLine();
            Console.Write("Insira a data de nascimento da pessoa no formato DD/MM/YYYY:");
            var Data = Convert.ToDateTime(Console.ReadLine());
            amigos.Aniversario = Data;
            manager.CadastrarAmigo(amigos);
            Menu();
        }




        public static void MostrarAmigos()
        {
            foreach (var item in manager.MostrarAmigos())
            {
                item.Mostrar();


            }
            Menu();
        }
        private static void ProcurarAmigo()
        {
            Console.WriteLine("Digite o nome da pessoa que deseja encontrar:");
            var username = Console.ReadLine();

            var amigos = manager.ProcurarAmigo(username);

            Console.WriteLine("Imprimindo Resultado da Busca");

            foreach (var item in amigos)
            {
                item.Mostrar();
            }
            Menu();

        }
        private static void ExcluirAmigo()
        {
            Console.WriteLine("Digite o nome para excluir o Amigo");
            var username = Console.ReadLine();

            var amigos = manager.ProcurarAmigo(username);

            Console.WriteLine("Imprimindo Resultado da Busca");

            foreach (var item in amigos)
            {
                item.Mostrar();

                Console.WriteLine("Deseja excluir o Amigo? (S/N)");

                string opcao = Console.ReadLine();

                if (opcao == "S")
                {
                    manager.ExcluirAmigo(item.Nome);
                }
            }
            Menu();

        }
        private static void AtualizarAmigo()
        {
            Console.WriteLine("Digite o nome para atualizar o Amigo");
            var username = Console.ReadLine();

            var amigos1 = manager.ProcurarAmigo(username);

            Console.WriteLine("Imprimindo Resultado da Busca");

            foreach (var item in amigos1)
            {
                item.Mostrar();

                Console.WriteLine("Deseja atualizar o Amigo? (S/N)");

                string opcao = Console.ReadLine();

                if (opcao == "S")
                {
                    Amigos amigos = new Amigos();
                    manager.ExcluirAmigo(item.Nome);
                    Console.Write("Insira o nome da pessoa:");
                    amigos.Nome = Console.ReadLine();
                    Console.Write("Insira o sobrenome da pessoa:");
                    amigos.SobreNome = Console.ReadLine();
                    Console.Write("Insira a data de nascimento da pessoa no formato DD/MM/YYYY:");
                    var Data = Convert.ToDateTime(Console.ReadLine());
                    amigos.Aniversario = Data;
                    manager.CadastrarAmigo(amigos);


                }
            }
            Menu();

        }
    }
}