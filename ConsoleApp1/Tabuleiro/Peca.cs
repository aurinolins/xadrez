using System;

namespace Tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; set; }
        public tabuleiro tabuleiro { get; protected set; }

        public Peca(tabuleiro tabuleiro, Cor cor)
        {
            this.cor = cor;
            this.tabuleiro = tabuleiro;
            this.posicao = null;
            this.qteMovimentos = 0;
        }
        public void incrementarmovimentos()
        {
            qteMovimentos++;
        }
        public void diminuirmovimentos()
        {
            qteMovimentos--;
        }
        public abstract bool movimentospossiveis(tabuleiro tab , Posicao origem, Posicao posicaodestino);

       
    }

}
