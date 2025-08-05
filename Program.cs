using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;
// Cria os modelos de hóspedes e cadastra na lista de hóspedes

bool working = true;

List<Pessoa> hospodes = new List<Pessoa>();

Suite suite = new Suite(tipoSuite: "Premium", capacidade: 6, valorDiaria: 90);
Suite suite1 = new Suite(tipoSuite: "Normal", capacidade: 4, valorDiaria: 60);
Suite suite2 = new Suite(tipoSuite: "Kitnet", capacidade: 2, valorDiaria: 30);

Reserva reserva = new Reserva(diasReservados: 11);
reserva.CadastrarSuite(suite);


while (working)
{
    Console.Clear();
    Console.WriteLine("=== Hotelaria Silva & Co ===\n");
    Console.WriteLine("1 - Cadastrar hóspedes");
    Console.WriteLine("2 - Ver detalhes da reserva");
    Console.WriteLine("3 - Sair\n");
    Console.Write("Digite sua opção: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Cadastro de Hóspedes");

            hospodes.Clear();

            Console.WriteLine("Quantos hospodes deseja cadastrar? ");
            int quantidade = int.Parse(Console.ReadLine());

            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine($"Digite o nome do hospode {i + 1}: ");
                string nome = Console.ReadLine();
                hospodes.Add(new Pessoa(nome));
            }

            reserva.CadastrarHospedes(hospodes);
            Console.WriteLine("Hospodes cadastrados com sucesso!");

            break;
        case "2":
            Console.Clear();
            Console.WriteLine("Detalhes da reserva: \n");

            Console.WriteLine($"Suíte: {suite.TipoSuite}");
            Console.WriteLine($"Capacidade: {suite.Capacidade}");
            Console.WriteLine($"Dias reservados: {reserva.DiasReservados}");
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");

            foreach (var c in hospodes)
            {
                Console.WriteLine($"- {c.Nome}");
            }

            Console.WriteLine($"Valor total da reserva: R${reserva.CalcularValorDiaria():F2}");

            break;
        case "3":
            working = false;
            break;
        default:
            Console.WriteLine("Opção iválida");
            break;
    }
    if (working)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}

Console.WriteLine("O programa se encerrou\n"+ "Muito obrgado e até breve!");
