using System;
using System.Collections.Generic;
using Tabuleiro;
namespace Xadrez
{
    class Bispo : Peca
    {
        public Bispo(tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        public override string ToString()
        {
            return "B";
        }
        public override bool movimentospossiveis(tabuleiro tab, Posicao origem, Posicao destino)
        {
            if (origem.Linha == destino.Linha || origem.Coluna == destino.Coluna)
            {
                return false;
            }

            Posicao pos = new Posicao(origem.Linha, origem.Coluna);

            while (pos.Coluna != destino.Coluna)
            {
                if (destino.Linha > origem.Linha)
                {
                    pos.Linha++;
                }
                else
                {
                    pos.Linha--;
                }

                if (destino.Coluna > origem.Coluna)
                {
                    pos.Coluna++;
                }
                else
                {
                    pos.Coluna--;
                }
                if (!tab.PosicaoValida(pos))
                {
                    continue;
                }

                if (tab.peca(pos.Linha, pos.Coluna) == null)
                {
                    continue;
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
            return true;
        }
    }
}
