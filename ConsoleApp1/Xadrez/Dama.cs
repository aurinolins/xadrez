using System;
using Tabuleiro;

namespace Xadrez
{
    class Dama : Peca
    {
        public Dama(tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        public override string ToString()
        {
            return "D";
        }
        public override bool movimentospossiveis(tabuleiro tab, Posicao origem, Posicao destino)
        {
            Posicao pos = new Posicao(origem.Linha, origem.Coluna);

            while (pos.Linha != destino.Linha || pos.Coluna != destino.Coluna)
            {

                if (destino.Linha > origem.Linha)
                {
                    pos.Linha++;
                }
                else
                {
                    if (destino.Linha < origem.Linha)
                    {
                        pos.Linha--;
                    }
                }
                if (destino.Coluna > origem.Coluna)
                {
                    pos.Coluna++;
                }
                else
                {
                    if (destino.Coluna < origem.Coluna)
                    {
                        pos.Coluna--;
                    }
                }
                if (!tab.PosicaoValida(pos))
                {
                    return false;
                }

                if (tab.peca(pos.Linha, pos.Coluna) == null)
                {
                    if (pos.Linha == destino.Linha &&
                      pos.Coluna == destino.Coluna)
                    {
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (tab.peca(pos.Linha, pos.Coluna).cor !=
                    tab.peca(origem.Linha, origem.Coluna).cor &&
                    pos.Linha == destino.Linha &&
                    pos.Coluna == destino.Coluna)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

        }
    }
}
