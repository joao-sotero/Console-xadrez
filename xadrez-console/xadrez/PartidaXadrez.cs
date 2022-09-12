using tabuleiro;
using xadrez_console.tabuleiro;
using xadrez_console.xadrez;

namespace xadrez
{
    public class PartidaXadrez
    {
        public Tabuleiro Tab { get;  private set; }
        public int Turno { get; set; }
        public Cor JogadorAtual { get; set; }
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

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            var peca =  Tab.RemovePeca(origem);
            peca.IncrementarQteMovimentos();
            Tab.RemovePeca(destino);
            Tab.ColocaPeca(peca, destino);
        }
    }
}
