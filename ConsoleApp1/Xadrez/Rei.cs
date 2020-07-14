using System;
using Tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        private PartidadeXadrez partida;

        public Rei(tabuleiro tab, Cor cor, PartidadeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }
        public override bool movimentospossiveis(tabuleiro tab, Posicao origem, Posicao destino)
        {
            Posicao pos = new Posicao(tab.linhas, tab.colunas);

            /* Testar Rock Pequeno */

            if ( ! partida.emcheque &&
                destino.Linha == origem.Linha && destino.Coluna == origem.Coluna + 2 &&
                tab.pecas[origem.Linha, origem.Coluna].qteMovimentos == 0 &&
                tab.pecas[origem.Linha, origem.Coluna + 3] is Torre &&
                tab.pecas[origem.Linha, origem.Coluna + 3].qteMovimentos == 0 &&
                tab.pecas[origem.Linha, origem.Coluna + 1] == null &&
                tab.pecas[origem.Linha, origem.Coluna + 2] == null)
            {
                return true;
            }

            /* Testar Roque Grande */


            if ( ! partida.emcheque &&
                destino.Linha == origem.Linha && destino.Coluna == origem.Coluna - 2 &&
                tab.pecas[origem.Linha, origem.Coluna].qteMovimentos == 0 &&
                tab.pecas[origem.Linha, origem.Coluna - 4] is Torre &&
                tab.pecas[origem.Linha, origem.Coluna - 4].qteMovimentos == 0 &&
                tab.pecas[origem.Linha, origem.Coluna - 1] == null &&
                tab.pecas[origem.Linha, origem.Coluna - 2] == null &&
                tab.pecas[origem.Linha, origem.Coluna - 3] == null)
            {
                return true;
            }

            /* Logica Geral */

            for (int i = origem.Linha - 1; i < origem.Linha + 2; i++)
            {
                for (int j = origem.Coluna - 1; j < origem.Coluna + 2; j++)
                {
                    pos.Linha = i;
                    pos.Coluna = j;
                    if (!tab.PosicaoValida(pos))
                    {
                        continue;
                    }
                    if (i == destino.Linha && j == destino.Coluna)
                    {
                        if (tab.pecas[i, j] == null || tab.pecas[i, j].cor !=
                            tab.pecas[origem.Linha, origem.Coluna].cor)
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
    }
}


