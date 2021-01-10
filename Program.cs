using System;

namespace Dio_Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUtilizador = ObterOpcaoUtilizador();
            while (opcaoUtilizador.ToUpper() != "X")
            {
                switch (opcaoUtilizador)
                {
                    case  "1":
                        ExibirSeries();
                        break;
                    case  "2":
                        InserirSerie();
                        break;
                    case  "3":
                        AtualizarSerie();
                        break;
                    case  "4":
                        ExcluirSerie();
                        break;
                    case  "5":
                        VerSerie();
                        break;
                    case  "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUtilizador = ObterOpcaoUtilizador();
            }
            Console.WriteLine("Obrigado por utilizar os nossos serviços.");
            Console.ReadLine();
        }

        private static void VerSerie()
        {
            Console.Write("Indique o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Indique o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Indique o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i ,Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Escolha o género de entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Indique o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Indique o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Escreva a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void InserirSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i ,Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Escolha o género de entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.Write("Indique o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Indique o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.Write("Escreva a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void ExibirSeries()
        {
            Console.WriteLine("Lista de Séries");

            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série registada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));    
            }
        }

        private static string ObterOpcaoUtilizador()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries ao seu dispor!");
            Console.WriteLine("Escolha a opção desejada:");
            Console.WriteLine("1 - Exibir lista de séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Ver Série");
            Console.WriteLine("C - Limpar o ecrã");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUtilizador = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUtilizador;
        }
    }
}
