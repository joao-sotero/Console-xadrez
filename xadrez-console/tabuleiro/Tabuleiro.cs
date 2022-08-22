﻿using tabuleiro;

namespace xadrez_console.tabuleiro
{
    public class Tabuleiro
    {
        public int Linhas { get; private set; }
        public int Colunas { get; private set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public void ColocaPeca(Peca peca, Posicao posicao)
        {
            pecas[posicao.Linha, posicao.Coluna] = peca;
        }
    }
}