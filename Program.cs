using System;
using DIO.Series.classes;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();
            
           while (opcaoUsuario.ToUpper() != "X")
           {
                switch (opcaoUsuario)
                {
                    case "1":
                        
                    ListarSeries();
                    break;
                    case "2":
                        
                    InserirSerie();
                    break;
                    case "3":
                        
                    AtualizarSerie();
                    break;
                    case "4":
                  
                    ExcluirSerie();
                    break;
                    case "5":
                   
                    VisualizarSerie();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
           }
           Console.WriteLine("Obrigado por utilizar nossos serviços.");
		   Console.ReadLine();
        }
        //metodo de visualizacao de serie
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
        }
        //metodo de exclusao de serie
        private static void ExcluirSerie()
        {
           Console.Write("Digite o id da série: ");
		   int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
        }
        //metodo de atulizar dados da serie
        private static void AtualizarSerie()
        {
           Console.Write("Digite o id da série: ");
		   int indiceSerie = int.Parse(Console.ReadLine());

           foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
              
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

            Console.Write("Digite a Duração da Série: ");
            string entradaDuracao = Console.ReadLine();

            Console.Write("Digite a Classificação da Série: ");
            string entradaClassificacao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
                                        duracao: entradaDuracao,
                                        classificacao: entradaClassificacao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        //metodo de inserção de serie
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao sa serie: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite a Duração da Série: ");
            string entradaDuracao = Console.ReadLine();

            Console.Write("Digite a Classificação da Série: ");
            string entradaClassificacao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao, 
                                        duracao: entradaDuracao,
                                        classificacao: entradaClassificacao);

            repositorio.Insere(novaSerie);
        }
        //metodo de listagem das series cadastradas
        private static void ListarSeries()
        {
            Console.WriteLine("Listar series");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }
        //Lista de Opcoes 
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Amazon Prime Video Series a seu dispor!!!");
            Console.WriteLine("Informe a opcao desejada:");

            Console.WriteLine("1- Listar series");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
