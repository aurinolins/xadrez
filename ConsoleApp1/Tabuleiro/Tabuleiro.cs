using System;


namespace Tabuleiro
{
    class tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        public Peca[,] pecas { get ; protected set; }
        

        public tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            this.pecas = new Peca[linhas, colunas];
        }
        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public Peca peca(Posicao pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }
        public void ColocarPeca(Peca P, Posicao pos)
        {
            ValidarPosicao(pos);
            if (pecas[pos.Linha, pos.Coluna] != null)
            {
                throw new TabuleiroException("Posicão Já Tem uma Peça");
            }
            pecas[pos.Linha, pos.Coluna] = P;
        }
        public Peca RetirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca pecaaux = peca(pos);
            pecaaux.posicao = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return pecaaux;
        }


        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= linhas || pos.Coluna < 0 || pos.Coluna >= colunas)
            {
                return false;
            }
            return true;
        }
        public void ValidarPosicao(Posicao pos)
        {
            if ( ! PosicaoValida(pos))
            {
                throw new TabuleiroException("Posicao Invalida");
            }
        }
    }
}
