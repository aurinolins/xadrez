using System;
using Tabuleiro;

namespace ConsoleApp1

{
    class Tela
    {
        public static void ImprimirTabuleiro(tabuleiro Tab, int turno, Cor jogador )
        {
            for (int i = 0; i < Tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < Tab.colunas; j++)
                {
                    if (Tab.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimirpeca(Tab.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.WriteLine();
            if (jogador == Cor.Branca)
            {
                Console.WriteLine("As Brancas jogam !!! ");
            }
            else
            {
                Console.WriteLine("As pretas jogam !!! ");
            }

            Console.WriteLine();

        }
        public static void imprimirpeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
