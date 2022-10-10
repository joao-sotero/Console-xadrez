using tabuleiro;
using xadrez_console.tabuleiro;

namespace xadrez_console.xadrez
{
    public class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] MovimentoPossiveis = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(pos.Linha - 1, pos.Coluna - 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                MovimentoPossiveis[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(pos.Linha - 2, pos.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                MovimentoPossiveis[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(pos.Linha - 2, pos.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                MovimentoPossiveis[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(pos.Linha - 1, pos.Coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                MovimentoPossiveis[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(pos.Linha + 1, pos.Coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                MovimentoPossiveis[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(pos.Linha + 2, pos.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                MovimentoPossiveis[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(pos.Linha + 2, pos.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                MovimentoPossiveis[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(pos.Linha + 1, pos.Coluna - 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                MovimentoPossiveis[pos.Linha, pos.Coluna] = true;
            }
            return MovimentoPossiveis;
        }
    }
}
