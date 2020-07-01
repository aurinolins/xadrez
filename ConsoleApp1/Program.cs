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

            {
                try
                {
                    while ( ! partida.encerrada)
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tab, partida.turno, partida.jogadoratual);
                        Console.WriteLine("Origem : ");
                        string origemaux = Console.ReadLine();
                        char coluna = origemaux[0];
                        int linha = int.Parse(origemaux[1] + "");
                        Posicao origem = new Posicao(8 - linha, coluna - 'a');
                        if (origem == null)
                        {
                            Console.WriteLine("Posicao de Origem Invalida : ");
                            Console.ReadLine();
                            continue;
                        }
                        if (!partida.tab.PosicaoValida(origem))
                        {
                            Console.WriteLine("Posicao de origem Invalida : ");
                            Console.ReadLine();
                            continue;
                        }
                        if (!partida.tab.ExistePeca(origem))
                        {
                            Console.WriteLine("Peça de Origem Inexistente : ");
                            Console.ReadLine();
                            continue;
                        }

                        if (partida.tab.peca(origem).cor != partida.jogadoratual)
                        {
                            Console.WriteLine("Peça de Origem não pertence ao jogador atual : ");
                            Console.ReadLine();
                            continue;
                        }

                        Console.WriteLine("Destino : ");
                        string destinoaux = Console.ReadLine();
                        coluna = destinoaux[0];
                        linha = int.Parse(destinoaux[1] + "");
                        Posicao destino = new Posicao(8 - linha, coluna - 'a');
                        if (destino == null)
                        {
                            Console.WriteLine("Posicao de destino Invalida : ");
                            Console.ReadLine();
                            continue;
                        }


                        if (!partida.tab.PosicaoValida(destino))
                        {
                            Console.WriteLine("Posicao de destino Invalida : ");
                            Console.ReadLine();
                            continue;
                        }

                        Peca pecaorigem = partida.tab.peca(origem);

                        if (pecaorigem.movimentospossiveis(partida.tab,origem, destino))
                        {
                            partida.executamovimento(origem, destino);
                            Posicao posrei = partida.EncontrarPosicaoRei(partida.tab);
                            Console.WriteLine("Posição do rei : " + posrei);
                            Console.ReadLine();
                         /*   if (partida.ReiemCheque(posrei))
                            {
                                Console.WriteLine("Atenção : Seu Rei está em Cheque !!! ");
                                Console.WriteLine();
                            } */
                        }
                        else
                        {
                            Console.WriteLine("Posicao de Destino Invalida : ");
                            Console.ReadLine();
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
}
