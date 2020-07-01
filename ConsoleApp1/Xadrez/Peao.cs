using System;
using Tabuleiro;

namespace Xadrez
{
    class Peao : Peca
    {
        public Peao(tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        public override string ToString()
        {
            return "P";
        }
        public override bool movimentospossiveis(tabuleiro tab, Posicao origem, Posicao destino)
        {

            Peca peca = tab.peca(origem.Linha, origem.Coluna);
            if (peca.qteMovimentos == 0)
            {
                if (destino.Linha > origem.Linha + 2 ||
                    destino.Linha < origem.Linha - 2 ||
                    destino.Coluna > origem.Coluna + 1 ||
                    destino.Coluna < origem.Coluna - 1)
                {
                    return false;
                }
            }
            if (peca.qteMovimentos != 0)
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
