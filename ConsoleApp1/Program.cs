using System;
using Tabuleiro;
using Xadrez;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            PartidadeXadrez partida = new PartidadeXadrez();

            
                try
                {
                    while ( ! partida.encerrada)
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tab, partida.jogadoratual);
                        bool jogadapermitida = Tela.EscolherJogada(partida);
                        if (jogadapermitida)
                        {
                            partida.AtualizarPartida();
                        }
                    }
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                }
            
        }
    }
}
