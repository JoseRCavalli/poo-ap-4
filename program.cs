using Modelos;
using Persistencia;

Console.WriteLine("Bem-vindo! Digite seu nome:");
string nomeUsuario = Console.ReadLine();
Usuario usuario = new(nomeUsuario);

List<Compromisso> compromissos = RepositorioCompromissos.Carregar();

bool executando = true;
while (executando)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Adicionar compromisso");
    Console.WriteLine("2. Listar compromissos");
    Console.WriteLine("0. Sair");
    Console.Write("Escolha: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Data (yyyy-MM-dd): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            Console.Write("Hora (HH:mm): ");
            TimeSpan hora = TimeSpan.Parse(Console.ReadLine());
            DateTime dataHora = data + hora;

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Local (ex: Sala 1): ");
            string nomeLocal = Console.ReadLine();

            Console.Write("Capacidade máxima: ");
            int capacidade = int.Parse(Console.ReadLine());

            Local local = new(nomeLocal, capacidade);

            Compromisso novo = new(dataHora, descricao, usuario, local);

            Console.Write("Deseja adicionar participantes? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                while (true)
                {
                    Console.Write("Nome do participante (ou vazio para sair): ");
                    string nomePart = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nomePart)) break;

                    Participante p = new(nomePart);
                    novo.AdicionarParticipante(p);
                }
            }

            Console.Write("Deseja adicionar uma anotação? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                Console.Write("Texto: ");
                string texto = Console.ReadLine();
                novo.AdicionarAnotacao(texto);
            }

            usuario.AdicionarCompromisso(novo);
            compromissos.Add(novo);
            RepositorioCompromissos.Salvar(compromissos);
            Console.WriteLine("Compromisso adicionado com sucesso!");
            break;

        case "2":
            foreach (var c in compromissos)
            {
                Console.WriteLine($"\n{c}");
                Console.WriteLine($"Participantes: {string.Join(", ", c.Participantes.Select(p => p.NomeCompleto))}");
                Console.WriteLine($"Anotações:");
                foreach (var a in c.Anotacoes)
                    Console.WriteLine($" - {a}");
            }
            break;

        case "0":
            executando = false;
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}
