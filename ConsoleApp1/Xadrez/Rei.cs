using System;
using Tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        public Rei(tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "R";
        }
        public override bool movimentospossiveis(tabuleiro tab, Posicao origem, Posicao destino)
        {

            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(tab.linhas, tab.colunas);


            for (int i = origem.Linha - 1; i < origem.Linha+2; i++)
            {
                for (int j = origem.Coluna - 1; j < origem.Coluna+2; j++)
                {
                    pos.Linha = i;
                    pos.Coluna = j;
                    if ( !tab.PosicaoValida(pos))
                    {
                        continue;
                    }

                    if (tab.peca(i, j) == null)
                    {
                        mat[i, j] = true;
                    }
                    else
                    {
                        if (tab.peca(i, j).cor != tab.peca(origem.Linha,origem.Coluna).cor)
                        {
                            mat[i, j] = true;
                        }
                        else
                        {
                            mat[i, j] = false;
                        }
                       
                    }
                }
            }

            if (mat[destino.Linha, destino.Coluna])
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


