using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ExercAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string nomeArquivo = "nomes.csv";
            List<string> nomes;
            {
                if (File.Exists(nomeArquivo)) ;
            }
            nomes = new List<string>(File.ReadAllLines(nomeArquivo));
            Console.WriteLine("Dados carregados com sucesso do arquivo 'nomes.csv'!");
            Console.WriteLine("Pressione qualquer tecla para iniciar...");
            Console.ReadKey();

            {
                nomes = new List<string>();
            }
            bool sair = false;
            while (!sair)
            {
                Console.Clear();
            }

            Console.WriteLine("================================");
            Console.WriteLine("    Gerenciador de Nomes");
            Console.WriteLine("================================");
            Console.WriteLine("1. Inserir um novo nome");
            Console.WriteLine("2. Procurar um nome");
            Console.WriteLine("3. Remover um nome");
            Console.WriteLine("4. Atualizar um nome");
            Console.WriteLine("5. Listar todos os nomes");
            Console.WriteLine("6. Salvar nomes em arquivo"); // --- OPÇÃO NOVA ---
            Console.WriteLine("7. Sair do programa");        // --- OPÇÃO ANTIGA ATUALIZADA ---
            Console.WriteLine("================================");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {

                case "1":
                    Console.Write("Digite o nome para inserir: ");
                    string nomeParaInserir = Console.ReadLine();
                    nomes.Add(nomeParaInserir);
                    Console.WriteLine($"'{nomeParaInserir}' foi adicionado com sucesso!");
                    break;


                case "2":
                    Console.Write("Digite o nome que deseja procurar: ");
                    string nomeParaProcurar = Console.ReadLine();
                    if (nomes.Contains(nomeParaProcurar))
                    {
                        Console.WriteLine($"BOA NOTÍCIA: O nome '{nomeParaProcurar}' foi encontrado na lista!");
                    }
                    else
                    {
                        Console.WriteLine($"AVISO: O nome '{nomeParaProcurar}' NÃO foi encontrado.");
                    }
                    break;

                case "3":
                    Console.Write("Digite o nome que deseja remover: ");
                    string nomeParaRemover = Console.ReadLine();
                    if (nomes.Remove(nomeParaRemover))
                    {
                        Console.WriteLine($"'{nomeParaRemover}' foi removido com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine($"AVISO: O nome '{nomeParaRemover}' não foi encontrado para remover.");
                    }
                    break;


                case "4":
                    Console.Write("Digite o nome que deseja ATUALIZAR (o nome antigo): ");
                    string nomeAntigo = Console.ReadLine();
                    int indice = nomes.IndexOf(nomeAntigo);
                    if (indice != -1)
                    {
                        Console.Write($"Digite o NOVO nome para substituir '{nomeAntigo}': ");
                        string nomeNovo = Console.ReadLine();
                        nomes[indice] = nomeNovo;
                        Console.WriteLine("Nome atualizado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine($"AVISO: O nome '{nomeAntigo}' não foi encontrado para atualizar.");
                    }
                    break;


                case "5":
                    Console.WriteLine("\n--- Lista de Nomes Cadastrados ---");
                    if (nomes.Count == 0)
                    {
                        Console.WriteLine("A lista está vazia.");
                    }
                    else
                    {
                        foreach (string nomeNaLista in nomes)
                        {
                            Console.WriteLine($"- {nomeNaLista}");
                        }
                    }
                    Console.WriteLine("------------------------------------");
                    break;

                case "6":
                    // O método File.WriteAllLines() cria um arquivo (ou sobrescreve um existente)
                    // e escreve cada item da lista 'nomes' como uma nova linha.
                    File.WriteAllLines(nomeArquivo, nomes);
                    Console.WriteLine($"Lista de nomes salva com sucesso no arquivo '{nomeArquivo}'!");
                    break;

                case "7":
                    Console.WriteLine("Encerrando o programa... Até logo!");
                    sair = true;
                    break;

                default:
                    // Mensagem de erro atualizada para o novo intervalo de opções.
                    Console.WriteLine("Opção inválida! Por favor, escolha um número de 1 a 7.");
                    break;


                    if (!sair)
                    {
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                    }
            }
        }
    }
}
