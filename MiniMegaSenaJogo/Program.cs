using System;

namespace MiniMegaSena
{
    class Program
    {
        static void Main(string[] args)
        {
            bool jogarNovamente;
            do
            {
                Console.WriteLine("Bem-vindo ao Mini Mega Sena!");
                Console.Write("Por favor, digite seu nome: ");
                string nomeJogador = Console.ReadLine();

                Console.WriteLine($"Olá, {nomeJogador}! Escolha o nível do jogo:");
                Console.WriteLine("1 - Números de 1 a 30");
                Console.WriteLine("2 - Números de 1 a 60");
                int nivel;
                while (!int.TryParse(Console.ReadLine(), out nivel) || (nivel != 1 && nivel != 2))
                {
                    Console.WriteLine("Nível inválido. Escolha 1 ou 2:");
                }

                MiniMegaSena jogo = new MiniMegaSena(nomeJogador, nivel);

                Console.WriteLine("Digite 6 números entre 1 e " + (nivel == 1 ? "30" : "60") + ":");
                for (int i = 0; i < 6; i++)
                {
                    int numero;
                    while (true)
                    {
                        Console.Write($"Número {i + 1}: ");
                        if (int.TryParse(Console.ReadLine(), out numero) && numero >= 1 && numero <= (nivel == 1 ? 30 : 60))
                        {
                            jogo.NumerosEscolhidos[i] = numero;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Número inválido. Digite um número entre 1 e {(nivel == 1 ? "30" : "60")}:");
                        }
                    }
                }

                jogo.SortearNumeros();
                int acertos = jogo.VerificarAcertos();

                Console.WriteLine($"Números sorteados: {string.Join(", ", jogo.NumerosSorteados)}");
                Console.WriteLine($"Você acertou {acertos} número(s).");

                if (acertos == 4)
                {
                    Console.WriteLine("Parabéns, acertou 4, mas ganhou pouco dinheiro.");
                }
                else if (acertos == 5)
                {
                    Console.WriteLine("Parabéns, acertou 5, quero um churrasco!");
                }
                else if (acertos == 6)
                {
                    Console.WriteLine("Parabéns, acertou 6, você está rico! Quero um carro!");
                }
                else
                {
                    Console.WriteLine("Infelizmente, você não acertou o suficiente para ganhar um prêmio.");
                }

                Console.WriteLine("Deseja jogar novamente? (Sim/Não)");
                string resposta = Console.ReadLine();
                jogarNovamente = resposta.Equals("Sim", StringComparison.OrdinalIgnoreCase);

            } while (jogarNovamente);

            Console.WriteLine("Obrigado por jogar! Até a próxima.");
        }
    }
}
