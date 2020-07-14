using System;
using Tabuleiro;
using System.Linq;

namespace Xadrez
{
    class PartidadeXadrez
    {
        public tabuleiro tab { get; private set; }
        public Cor jogadoratual { get; private set; }
        public bool emcheque { get; private set; }
        public bool encerrada { get; set; }
        public Peca vulneravelenpassant { get; set; }
        public Posicao posrei { get; set; }

        public PartidadeXadrez()
        {
            tab = new tabuleiro(8, 8);
            posrei = new Posicao(8, 8);
            jogadoratual = Cor.Branca;
            emcheque = false;
            encerrada = false;
            colocarpecas();


        }
        public Peca executamovimento(Posicao origem, Posicao destino)
        {
            Peca p;
            p = tab.peca(origem);
            tab.RetirarPeca(origem);
            p.incrementarmovimentos();
            Peca pecacapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);

            if (tab.pecas[destino.Linha, destino.Coluna] is Peao &&
                 (destino.Linha == 0 || destino.Linha == 7))
            {
                Cor coraux = tab.pecas[destino.Linha, destino.Coluna].cor;
                tab.pecas[destino.Linha, destino.Coluna] =
                         new Dama(tab, coraux);
                tab.pecas[destino.Linha, destino.Coluna].posicao = destino;
            }

            if (p is Peao && destino.Coluna != origem.Coluna &&
                pecacapturada is null)
            {
                Posicao poscapturada = new Posicao(origem.Linha, destino.Coluna);
                pecacapturada = tab.RetirarPeca(poscapturada);
                pecacapturada.posicao = poscapturada;
                vulneravelenpassant = null;
            }

            if (tab.pecas[destino.Linha, destino.Coluna] is Rei &&
                destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemtorre = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinotorre = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca torre = tab.peca(origemtorre);
                tab.RetirarPeca(origemtorre);
                tab.ColocarPeca(torre, destinotorre);
                torre.incrementarmovimentos();
            }

            if (tab.pecas[destino.Linha, destino.Coluna] is Rei &&
                destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemtorre = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinotorre = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca torre = tab.peca(origemtorre);
                tab.RetirarPeca(origemtorre);
                tab.ColocarPeca(torre, destinotorre);
                torre.incrementarmovimentos();
            }

            if (p is Peao && p.qteMovimentos == 1 && (destino.Linha == 3 || destino.Linha == 4))
            {
                vulneravelenpassant = p;
            }
            else
            {
                vulneravelenpassant = null;
            }

            return pecacapturada;

        }

        public void Desfazmovimento(Posicao origem, Posicao destino, Peca pecaorigem, Peca pecacapturada)
        {
            tab.RetirarPeca(origem);
            tab.RetirarPeca(destino);
            tab.ColocarPeca(pecaorigem, origem);
            tab.ColocarPeca(pecacapturada, pecacapturada.posicao);
            pecaorigem.diminuirmovimentos();

            if (tab.pecas[origem.Linha, origem.Coluna] is Rei &&
                 destino.Coluna == origem.Coluna + 2)
            {
                Peca Torre = tab.pecas[origem.Linha, origem.Coluna + 1];
                Posicao origemtorre = new Posicao(origem.Linha, origem.Coluna + 1);
                Posicao destinotorre = new Posicao(origem.Linha, origem.Coluna + 3);
                tab.RetirarPeca(origemtorre);
                tab.ColocarPeca(Torre, destinotorre);
                Torre.diminuirmovimentos();
                ;
            }

            if (tab.pecas[origem.Linha, origem.Coluna] is Rei &&
                destino.Coluna == origem.Coluna - 2)
            {
                Peca Torre = tab.pecas[origem.Linha, origem.Coluna - 1];
                Posicao origemtorre = new Posicao(origem.Linha, origem.Coluna - 1);
                Posicao destinotorre = new Posicao(origem.Linha, origem.Coluna - 4);
                tab.RetirarPeca(origemtorre);
                tab.ColocarPeca(Torre, destinotorre);
                Torre.diminuirmovimentos();
            }

            if (pecaorigem is Peao && pecacapturada is Peao &&
                pecacapturada.posicao != null &&
                pecacapturada.posicao != destino)
            {
                vulneravelenpassant = pecacapturada;
            }
        }

        public Posicao EncontrarPosicaoRei(Peca pecaorigem)
        {
            if (pecaorigem != null && pecaorigem is Rei)
            {
                Posicao posrei = new Posicao(pecaorigem.posicao.Linha, pecaorigem.posicao.Coluna);
                return posrei;
            }

            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.pecas[i, j] != null && tab.pecas[i, j] is Rei &&
                        tab.pecas[i, j].cor == jogadoratual)
                    {
                        Posicao posrei = new Posicao(i, j);
                        return posrei;

                    }
                }
            }
            Console.WriteLine("Não encontramos Rei !!! ");
            Console.ReadLine();
            return null;
        }

        public bool ReiemCheque(Posicao posrei)
        {
            Posicao pospeca = new Posicao(tab.linhas, tab.colunas)
     ;
            for (int i = 0; i < this.tab.linhas; i++)
            {
                pospeca.Linha = i;

                for (int j = 0; j < this.tab.colunas; j++)
                {
                    pospeca.Coluna = j;

                    if (this.tab.pecas[i, j] != null && tab.pecas[i, j].cor != jogadoratual)
                    {
                        if (this.tab.pecas[i, j].movimentospossiveis(tab, pospeca, posrei))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool ChequeMate(Posicao posrei)
        {
            Peca rei = tab.pecas[posrei.Linha, posrei.Coluna];

            for (int i = 0; i < this.tab.linhas; i++)
            {
                for (int j = 0; j < this.tab.colunas; j++)
                {
                    Posicao pospeca = new Posicao(i, j);
                    if (this.tab.pecas[i, j] == null || this.tab.pecas[i, j].cor != jogadoratual)
                    {
                        if (this.tab.pecas[posrei.Linha, posrei.Coluna].movimentospossiveis(tab, posrei, pospeca))
                        {
                            Peca pecaaux = this.tab.pecas[pospeca.Linha, pospeca.Coluna];

                            this.tab.pecas[pospeca.Linha, pospeca.Coluna] =
                                this.tab.pecas[posrei.Linha, posrei.Coluna];

                            this.tab.pecas[posrei.Linha, posrei.Coluna] = null;

                            if (ReiemCheque(pospeca))
                            {
                                this.tab.pecas[pospeca.Linha, pospeca.Coluna] = pecaaux;
                                this.tab.pecas[posrei.Linha, posrei.Coluna] = rei;

                                continue;
                            }
                            else
                            {
                                this.tab.pecas[pospeca.Linha, pospeca.Coluna] = pecaaux;
                                this.tab.pecas[posrei.Linha, posrei.Coluna] = rei;

                                return false;
                            }
                        }
                    }
                }
            }

            return true;

        }
        public void AtualizarPartida()
        {
            if (this.jogadoratual == Cor.Branca)
            {
                this.jogadoratual = Cor.Preta;
            }
            else
            {
                this.jogadoratual = Cor.Branca;
            }

            posrei = this.EncontrarPosicaoRei(null);

            this.posrei = posrei;

            if (this.ReiemCheque(posrei))
            {
                this.emcheque = true;
            }
            else
            {
                this.emcheque = false;
            }

        }
        private void colocarpecas()
        {
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('a', 1).Toposicao());
            tab.ColocarPeca(new Cavalo(tab, Cor.Branca), new PosicaoXadrez('b', 1).Toposicao());
            tab.ColocarPeca(new Bispo(tab, Cor.Branca), new PosicaoXadrez('c', 1).Toposicao());
            tab.ColocarPeca(new Dama(tab, Cor.Branca), new PosicaoXadrez('d', 1).Toposicao());
            tab.ColocarPeca(new Rei(tab, Cor.Branca, this), new PosicaoXadrez('e', 1).Toposicao());
            tab.ColocarPeca(new Bispo(tab, Cor.Branca), new PosicaoXadrez('f', 1).Toposicao());
            tab.ColocarPeca(new Cavalo(tab, Cor.Branca), new PosicaoXadrez('g', 1).Toposicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('h', 1).Toposicao());


            tab.ColocarPeca(new Peao(tab, Cor.Branca, this), new PosicaoXadrez('a', 2).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Branca, this), new PosicaoXadrez('b', 2).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Branca, this), new PosicaoXadrez('c', 2).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Branca, this), new PosicaoXadrez('d', 2).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Branca, this), new PosicaoXadrez('e', 2).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Branca, this), new PosicaoXadrez('f', 2).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Branca, this), new PosicaoXadrez('g', 2).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Branca, this), new PosicaoXadrez('h', 2).Toposicao());


            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('a', 8).Toposicao());
            tab.ColocarPeca(new Cavalo(tab, Cor.Preta), new PosicaoXadrez('b', 8).Toposicao());
            tab.ColocarPeca(new Bispo(tab, Cor.Preta), new PosicaoXadrez('c', 8).Toposicao());
            tab.ColocarPeca(new Dama(tab, Cor.Preta), new PosicaoXadrez('d', 8).Toposicao());
            tab.ColocarPeca(new Rei(tab, Cor.Preta, this), new PosicaoXadrez('e', 8).Toposicao());
            tab.ColocarPeca(new Bispo(tab, Cor.Preta), new PosicaoXadrez('f', 8).Toposicao());
            tab.ColocarPeca(new Cavalo(tab, Cor.Preta), new PosicaoXadrez('g', 8).Toposicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('h', 8).Toposicao());


            tab.ColocarPeca(new Peao(tab, Cor.Preta, this), new PosicaoXadrez('a', 7).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Preta, this), new PosicaoXadrez('b', 7).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Preta, this), new PosicaoXadrez('c', 7).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Preta, this), new PosicaoXadrez('d', 7).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Preta, this), new PosicaoXadrez('e', 7).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Preta, this), new PosicaoXadrez('f', 7).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Preta, this), new PosicaoXadrez('g', 7).Toposicao());
            tab.ColocarPeca(new Peao(tab, Cor.Preta, this), new PosicaoXadrez('h', 7).Toposicao());


        }
    }
}
