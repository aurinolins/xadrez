using System;

namespace Tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public tabuleiro tabuleiro { get; protected set; }

        public Peca(tabuleiro tabuleiro, Cor cor)
        {
            this.cor = cor;
            this.tabuleiro = tabuleiro;
            this.posicao = null;
            this.qteMovimentos = 0;
        }
    }

}
