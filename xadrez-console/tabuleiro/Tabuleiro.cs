using tabuleiro;

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

        public Peca Peca(Posicao posicao)
        {
            return pecas[posicao.Linha, posicao.Coluna];
        }

        public void ColocaPeca(Peca peca, Posicao posicao)
        {
            if (ExistPeca(posicao))
                throw new TabuleiroException("Já existe peça nessa posição");
            pecas[posicao.Linha, posicao.Coluna] = peca;
        }

        public bool PosicaoValida(Posicao posicao)
        {
            if (posicao.Linha < 0 || posicao.Linha > Linhas || posicao.Coluna < 0 || posicao.Coluna > Colunas)
                return false;

            return true;
        }

        public void ValidarPosicao(Posicao posicao)
        {
            if (!PosicaoValida(posicao))
                throw new TabuleiroException("Posição invalida");
        }

        public bool ExistPeca(Posicao posicao)
        {
            ValidarPosicao(posicao);
            return Peca(posicao) != null;
        }
    }
}