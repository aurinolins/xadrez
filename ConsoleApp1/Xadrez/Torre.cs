using System;
using Tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }
        public override bool movimentospossiveis(tabuleiro tab, Posicao origem, Posicao destino)
        {
            if (origem.Linha != destino.Linha && origem.Coluna != destino.Coluna)
            {
                return false;
            }

            Posicao pos = new Posicao(tab.linhas, tab.colunas);


            if (origem.Linha == destino.Linha)
            {
                /*
                 Pesquisa Horizontal
                */
                pos.Linha = origem.Linha;
                pos.Coluna = origem.Coluna;
                while (pos.Coluna != destino.Coluna)
                {

                    if (destino.Coluna > origem.Coluna)
                    {
                        pos.Coluna = pos.Coluna + 1;
                    }
                    else
                    {
                        pos.Coluna = pos.Coluna - 1;
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
            /*
                Pesquisa Vertical
            */
            pos.Linha = origem.Linha;
            pos.Coluna = origem.Coluna;
            while (pos.Linha != destino.Linha)
            {

                if (destino.Linha > origem.Linha)
                {
                    pos.Linha = pos.Linha + 1;
                }
                else
                {
                    pos.Linha = pos.Linha - 1;
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
                    tab.peca(origem.Linha, origem.Coluna).cor  &&
                    pos.Linha == destino.Linha)
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




