using System;

namespace Tabuleiro
{
    class PosicaoXadrez
    {
        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }
        public Posicao Toposicao()
        {
            return new Posicao(linha - 8, coluna - 'a');
        }
        public override string ToString()
        {
            return " " + coluna + linha;
        }
    }
}

