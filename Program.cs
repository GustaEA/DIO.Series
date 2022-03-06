using System;

namespace DIO.Series
{
	public class Program
	{
		static SerieRepositorio repositorio = new SerieRepositorio();
		public static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();
			
			while(opcaoUsuario.ToUpper() != "X")
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
					AtualizaSerie();
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
		}
		
		private static void ListarSeries()
		{
			Console.WriteLine("Lista de séries:");
			var lista = repositorio.Lista();
			if (lista.Count == 0)
			{
				System.Console.WriteLine("Nenhuma série cadastrada");
				return;
			}
			
			foreach (var serie in lista)
			{
				var excluido = serie.RetornaExcluido();
				if(!excluido)
				{
				System.Console.WriteLine($"ID {serie.RetornaId()} - {serie.RetornaTitulo()}");
				}
			}
		}
		
		private static void InserirSerie()
		{
			System.Console.WriteLine("Insira nova série:");
			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}
			
			System.Console.WriteLine("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());
			
			System.Console.WriteLine("Digite o Título da série: ");
			string entradaTitulo = Console.ReadLine();
			
			System.Console.WriteLine("Digite o ano de início da série: ");
			int entradaAno = int.Parse(Console.ReadLine());
			
			System.Console.WriteLine("Digite a descrição da série: ");
			string entradaDescricao = Console.ReadLine();
			
			Serie novaSerie = new Serie(Id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										Titulo: entradaTitulo,
										Ano: entradaAno,
										Descricao: entradaDescricao);
			
			repositorio.Insere(novaSerie);
		}
		
		private static void AtualizaSerie()
		{
			System.Console.WriteLine("DIgite o ID da série: ");
			int indiceDaSerie = int.Parse(Console.ReadLine());
			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}
			
			System.Console.WriteLine("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());
			
			System.Console.WriteLine("Digite o Título da série: ");
			string entradaTitulo = Console.ReadLine();
			
			System.Console.WriteLine("Digite o ano de início da série: ");
			int entradaAno = int.Parse(Console.ReadLine());
			
			System.Console.WriteLine("Digite a descrição da série: ");
			string entradaDescricao = Console.ReadLine();
			
			Serie atualizaserie = new Serie(Id: indiceDaSerie,
										genero: (Genero)entradaGenero,
										Titulo: entradaTitulo,
										Ano: entradaAno,
										Descricao: entradaDescricao);
			
			repositorio.Atualiza(indiceDaSerie, atualizaserie);
		}
		
		private static void ExcluirSerie()
		{
			System.Console.WriteLine("Digite o ID da série que deseja excluir: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			
			repositorio.Exclui(indiceSerie);
		}
		
		private static void VisualizarSerie()
		{
			System.Console.WriteLine("Digite o ID da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			
			var serie = repositorio.RetornaPorId(indiceSerie);
			
			System.Console.WriteLine(serie);
		}
		
		private static string ObterOpcaoUsuario()
		{
			System.Console.WriteLine();
			System.Console.WriteLine("Mega Filmes HD a seu dispor!!!");
			System.Console.WriteLine("informe a opção desejada: ");
			
			System.Console.WriteLine("1. Listar séries");
			System.Console.WriteLine("2. Inserir nova série");
			System.Console.WriteLine("3. Atualizar série");
			System.Console.WriteLine("4. Excluir série");
			System.Console.WriteLine("5. Visualizar série");
			System.Console.WriteLine("C. Limpar tela");
			System.Console.WriteLine("X. Sair");
			
			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}