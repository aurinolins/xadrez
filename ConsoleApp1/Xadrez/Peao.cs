using System;
using Tabuleiro;

namespace Xadrez
{
    class Peao : Peca
    {
        private PartidadeXadrez partida;
        public Peao(tabuleiro tab, Cor cor, PartidadeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }
        public override string ToString()
        {
            return "P";
        }
        public override bool movimentospossiveis(tabuleiro tab, Posicao origem, Posicao destino)
        {
            if (tab.peca(origem.Linha, origem.Coluna).cor == Cor.Branca &&
                destino.Linha > origem.Linha)
            {
                return false;
            }
            if (tab.peca(origem.Linha, origem.Coluna).cor == Cor.Preta &&
               destino.Linha < origem.Linha)
            {
                return false;
            }

            if ((origem.Linha == 3 || origem.Linha == 4) &&
                destino.Coluna != origem.Coluna  &&
                tab.peca(destino.Linha, destino.Coluna) == null &&
                tab.peca(origem.Linha, destino.Coluna) is Peao &&
                tab.peca(origem.Linha, destino.Coluna).cor !=
                tab.peca(origem.Linha, origem.Coluna).cor &&
                tab.peca(origem.Linha, destino.Coluna) == partida.vulneravelenpassant) 
            {
                return true;
            }

            if (destino.Linha == origem.Linha)
            {
                return false;
            }

            if (destino.Coluna > origem.Coluna + 1 ||
                destino.Coluna < origem.Coluna - 1)
            {
                return false;
            }

            if (tab.peca(origem.Linha, origem.Coluna).qteMovimentos == 0)
            {
                if (destino.Linha > origem.Linha + 2 ||
                    destino.Linha < origem.Linha - 2)
                {
                    return false;
                }
                if ((destino.Linha == origem.Linha + 2 ||
                    destino.Linha == origem.Linha - 2) &&
                    destino.Coluna != origem.Coluna)
                {
                    return false;
                }

            }
            if (tab.peca(origem.Linha, origem.Coluna).qteMovimentos != 0)
            {
                if (destino.Linha > origem.Linha + 1 ||
                    destino.Linha < origem.Linha - 1 ||
                    destino.Coluna > origem.Coluna + 1 ||
                    destino.Coluna < origem.Coluna - 1)
                {
                    return false;
                }
            }
            if (tab.peca(destino.Linha, destino.Coluna) == null)
            {
                if (destino.Coluna == origem.Coluna)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (tab.peca(destino.Linha, destino.Coluna).cor !=
                tab.peca(origem.Linha, origem.Coluna).cor &&
                destino.Coluna != origem.Coluna)
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
