using System;
using System.Collections.Generic;
using Tabuleiro;

namespace Xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "C";
        }
        public override bool movimentospossiveis(tabuleiro tab, Posicao origem, Posicao destino)
        {
            
            if (destino.Linha == origem.Linha || destino.Coluna == origem.Coluna)
            {
                return false;
            }

            if (destino.Linha > origem.Linha+2 || 
                destino.Linha < origem.Linha-2 ||
                destino.Coluna > origem.Coluna + 2 ||
                destino.Coluna < origem.Coluna - 2)
            {
                return false;
            }
                        
            if (tab.peca(destino.Linha, destino.Coluna) == null)
            {
                return true;
            }
           
            if (tab.peca(destino.Linha, destino.Coluna).cor !=
                tab.peca(origem.Linha, origem.Coluna).cor)
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
