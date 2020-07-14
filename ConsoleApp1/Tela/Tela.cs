using System;
using Tabuleiro;
using Xadrez;

namespace ConsoleApp1

{
    class Tela
    {

        public static void ImprimirTabuleiro(tabuleiro Tab, Cor jogador)
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

        public static bool EscolherJogada(PartidadeXadrez partida)
        {
            if (partida.emcheque)
            {
                if (partida.ChequeMate(partida.posrei))
                {
                    Console.WriteLine("Atenção : Cheque Mate !!! ");
                    Console.WriteLine();
                    Console.WriteLine("Partiuda Encerrada !!!");
                    Console.ReadLine();
                    partida.encerrada = true;
                    return false;
                }
                else
                {

                    Console.WriteLine("Atenção : Seu Rei está em Cheque !!! ");
                    Console.WriteLine();
                }

            }

            Console.WriteLine("Origem : ");
            string origemaux = Console.ReadLine();
            if (origemaux == null)
            {
                Console.WriteLine("Posicao de Origem Invalida : ");
                Console.ReadLine();
                return false;
            }
            char coluna = origemaux[0];
            int linha = int.Parse(origemaux[1] + "");
            Posicao origem = new Posicao(8 - linha, coluna - 'a');
            if (origem == null)
            {
                Console.WriteLine("Posicao de Origem Invalida : ");
                Console.ReadLine();
                return false;
            }
            if (!partida.tab.PosicaoValida(origem))
            {
                Console.WriteLine("Posicao de origem Invalida : ");
                Console.ReadLine();
                return false;
            }
            if (!partida.tab.ExistePeca(origem))
            {
                Console.WriteLine("Peça de Origem Inexistente : ");
                Console.ReadLine();
                return false;
            }

            if (partida.tab.peca(origem).cor != partida.jogadoratual)
            {
                Console.WriteLine("Peça de Origem não pertence ao jogador atual : ");
                Console.ReadLine();
                return false;
            }

            Console.WriteLine("Destino : ");
            string destinoaux = Console.ReadLine();
            if (destinoaux == null)
            {
                Console.WriteLine("Posicao de destino Invalida : ");
                Console.ReadLine();
                return false;
            }
            coluna = destinoaux[0];
            linha = int.Parse(destinoaux[1] + "");
            Posicao destino = new Posicao(8 - linha, coluna - 'a');
            if (destino == null)
            {
                Console.WriteLine("Posicao de destino Invalida : ");
                Console.ReadLine();
                return false;
            }


            if (!partida.tab.PosicaoValida(destino))
            {
                Console.WriteLine("Posicao de destino Invalida : ");
                Console.ReadLine();
                return false;
            }

            Peca pecaorigem = partida.tab.peca(origem);

            if ( ! pecaorigem.movimentospossiveis(partida.tab, origem, destino))
            {
                Console.WriteLine("Posicao de Destino Invalida : ");
                Console.ReadLine();
                return false;
            }

            Peca pecacapturada = partida.executamovimento(origem, destino);

            Posicao posrei = partida.EncontrarPosicaoRei(pecaorigem);

            if (partida.ReiemCheque(posrei))
            {
                Console.WriteLine("Atenção : Seu Rei Fica em Cheque !!! ");
                Console.WriteLine();
                Console.ReadLine();
                partida.Desfazmovimento(origem, destino, pecaorigem, pecacapturada);
                return false;
            }

            return true;
        }

    }
}
