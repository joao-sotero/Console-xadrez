using tabuleiro;
using xadrez_console.tabuleiro;
using xadrez_console.xadrez;

namespace xadrez
{
    public class PartidaXadrez
    {
        public Tabuleiro Tab { get;  private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; set; }

        public PartidaXadrez()
        {
            Tab = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            ColocarPecas();
        }

        private void ColocarPecas()
        {
            Tab.ColocaPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 1).ToPosicao());
            Tab.ColocaPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('d', 1).ToPosicao());
            Tab.ColocaPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            Tab.ColocaPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('f', 1).ToPosicao());
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Tab.Peca(pos) == null)
                throw new TabuleiroException("Não Existe peça na posição de origem escolhida");
            if (JogadorAtual != Tab.Peca(pos).Cor)
                throw new TabuleiroException("A peça de origem escolhida é do adiversario");
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida");
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).PodeMoverPara(destino))
                throw new TabuleiroException("Posição de destino invalida");
        }

        private void MudarJogador()
        {
            if (JogadorAtual == Cor.Branca)
                JogadorAtual = Cor.Preta;
            else
                JogadorAtual = Cor.Branca;
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            var peca =  Tab.RemovePeca(origem);
            peca.IncrementarQteMovimentos();
            Tab.RemovePeca(destino);
            Tab.ColocaPeca(peca, destino);
        }
    }
}
