using System;
namespace livros
{
    class Program
    {
        static AudioRepositorio repositorio = new  AudioRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarLivros();
                        break;
                    case "2":
                        InserirLivro();
                        break;
                    case "3":
                        ExcluirLivro();
                        break;
                    case "4":
                        VisualizarLivro();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar os nossos serviços!");
            Console.ReadLine();
        }
        private static void ExcluirLivro()
		{
			Console.Write("Digite o ID do AudioLivro: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceLivro);
		}

        private static void VisualizarLivro()
		{
			Console.Write("Digite o ID do AudioLivro: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			var livro = repositorio.RetornaPorId(indiceLivro);

			Console.WriteLine(livro);
		}

        private static void ListarLivros()
		{
			Console.WriteLine("Listar AudioLivros");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum AudioLivro Cadastrado.");
				return;
			}

			foreach (var livro in lista)
			{
                var excluido = livro.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", livro.retornaId(), livro.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirLivro()
		{
			Console.WriteLine("Inserir novo AudioLivro");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do AudioLivro: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Publicação do Livro: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Sinopse do AudioLivro: ");
			string entradaDescricao = Console.ReadLine();

			Audio novoLivro = new Audio(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoLivro);
		}
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine($" Este é o SouNBooks!! O melhor site de Audiobooks do mundo!! \r\n Tem um livro que quer muito ler mas não tem tempo? \r\n Essa é a sua hora! Escute seu livro enquanto realiza as tarefas do dia-dia!");
            Console.WriteLine("\r\n Informe a opção desejada:");

            Console.WriteLine("1 - Listar AudioLivros");
            Console.WriteLine("2 - Inserir Novo");
            Console.WriteLine("3 - Excluir AudioLivro");
            Console.WriteLine("4 - Visualizar Livro");
            Console.WriteLine("C - Limpar Tela");
			Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}