using System;
using Tabuleiro;
using Xadrez;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                tabuleiro tab = new tabuleiro(8, 8);
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));
                Tela.ImprimirTabuleiro(tab);
                Console.ReadLine();
            }
            catch (TabuleiroException e)
            {
               Console.WriteLine(e.Message);
            }
            PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            Console.WriteLine(pos);
            Console.WriteLine(pos.Toposicao());
            
        }
    }
}
