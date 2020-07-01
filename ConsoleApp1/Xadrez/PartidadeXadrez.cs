using System;
using Tabuleiro;

namespace Xadrez
{
    class PartidadeXadrez
    {
        public tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadoratual { get; private set; }
        public bool encerrada { get; private set; }

        public PartidadeXadrez()
        {
            tab = new tabuleiro(8, 8);
            turno = 1;
            jogadoratual = Cor.Branca;
            encerrada = false;
            colocarpecas();


        }
        public void executamovimento(Posicao origem, Posicao destino)
        {
            Peca p;
            p = tab.peca(origem);
            tab.RetirarPeca(origem);
            p.incrementarqtdmovimentos();
            Peca pecacapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
            this.turno++;
            if (this.jogadoratual == Cor.Branca)
            {
                this.jogadoratual = Cor.Preta;
            }
            else
            {
                this.jogadoratual = Cor.Branca;
            }

        }
        public Posicao EncontrarPosicaoRei(tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.pecas[i, j] != null && tab.pecas[i, j] is Rei && tab.pecas[i, j].cor == jogadoratual)
                    {
                        return tab.pecas[i, j].posicao;

                    }
                }
            }
            return null;
        }

        public bool ReiemCheque(tabuleiro tab, Posicao posrei)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.pecas[i, j] != null && tab.pecas[i, j].cor != jogadoratual)
                    {
                        if (tab.pecas[i, j].movimentospossiveis(tab, tab.pecas[i, j].posicao, posrei))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;

        }

        private void colocarpecas()
        {
            tab.ColocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('c', 1).Toposicao());
            tab.ColocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('c', 5).Toposicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).Toposicao());
            tab.ColocarPeca(new Cavalo(tab, Cor.Branca), new PosicaoXadrez('d', 2).Toposicao());
            tab.ColocarPeca(new Bispo(tab, Cor.Branca), new PosicaoXadrez('e', 2).Toposicao());
            tab.ColocarPeca(new Cavalo(tab, Cor.Preta), new PosicaoXadrez('e', 1).Toposicao());
            tab.ColocarPeca(new Bispo(tab, Cor.Preta), new PosicaoXadrez('d', 1).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('a', 2).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Preta), new PosicaoXadrez('b', 2).Toposicao());



            tab.ColocarPeca(new Dama(tab, Cor.Preta), new PosicaoXadrez('c', 7).Toposicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).Toposicao());
            tab.ColocarPeca(new Cavalo(tab, Cor.Preta), new PosicaoXadrez('d', 7).Toposicao());
            tab.ColocarPeca(new Dama(tab, Cor.Branca), new PosicaoXadrez('e', 7).Toposicao());
            tab.ColocarPeca(new Cavalo(tab, Cor.Preta), new PosicaoXadrez('e', 8).Toposicao());
            tab.ColocarPeca(new Bispo(tab, Cor.Preta), new PosicaoXadrez('d', 8).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('a', 7).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Branca), new PosicaoXadrez('b', 7).Toposicao());
        }
    }
}
