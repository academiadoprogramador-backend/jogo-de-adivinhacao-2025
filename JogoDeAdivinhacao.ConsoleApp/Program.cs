namespace JogoDeAdivinhacao.ConsoleApp
{
    internal class Program
    {
        // Versão 4: Criar múltiplas tentativas  
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Jogo de Adivinhação");
                Console.WriteLine("--------------------------------------------");

                // escolha de dificuldade
                Console.WriteLine("Nível de dificuldade:");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("1 - Fácil (10 tentativas)");
                Console.WriteLine("2 - Normal (5 tentativas)");
                Console.WriteLine("3 - Difícil (3 tentativas)");
                Console.WriteLine("--------------------------------------------");

                Console.Write("Digite sua escolha: ");
                string escolhaDeDificuldade = Console.ReadLine();

                int totalDeTentativas = 0;

                if (escolhaDeDificuldade == "1")
                    totalDeTentativas = 10;

                else if (escolhaDeDificuldade == "2")
                    totalDeTentativas = 5;

                else
                    totalDeTentativas = 3;

                // escolha de número aleatório
                Random geradorDeNumeros = new Random();

                int numeroSecreto = geradorDeNumeros.Next(1, 21);

                int[] numerosChutados = new int[100];
                int contadorNumerosChutados = 0;

                // lógica do jogo
                for (int tentativa = 1; tentativa <= totalDeTentativas; tentativa++)
                {
                    Console.Clear();
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Tentativa {tentativa} de {totalDeTentativas}");
                    Console.WriteLine("--------------------------------------------");

                    Console.Write("Números já chutados: ");

                    for (int i = 0; i < numerosChutados.Length; i++)
                    {
                        if (numerosChutados[i] > 0)
                            Console.Write(numerosChutados[i] + " ");
                    }

                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------");

                    int numeroDigitado;
                    bool numeroRepetido;

                    do
                    {
                        numeroRepetido = false;

                        Console.Write("Digite um número (de 1 à 20) para chutar: ");
                        numeroDigitado = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < numerosChutados.Length; i++)
                        {
                            if (numerosChutados[i] == numeroDigitado)
                            {
                                Console.WriteLine("Você já digitou este número! Aperte ENTER para tentar novamente...");
                                Console.ReadLine();

                                numeroRepetido = true;
                                break;
                            }
                        }
                    } while (numeroRepetido == true);

                    numerosChutados[contadorNumerosChutados] = numeroDigitado;
                    contadorNumerosChutados++;

                    if (numeroDigitado == numeroSecreto)
                    {
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Parabéns, você acertou!");
                        Console.WriteLine("--------------------------------------------");
                        break;
                    }
                    else if (numeroDigitado > numeroSecreto)
                    {
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("O número digitado foi maior que o número secreto!");
                        Console.WriteLine("--------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("O número digitado foi menor que o número secreto!");
                        Console.WriteLine("--------------------------------------------");
                    }

                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }

                Console.Write("Deseja continuar? (S/N): ");
                string opcaoContinuar = Console.ReadLine().ToUpper();

                if (opcaoContinuar != "S")
                    break;
            }
        }
    }
}
