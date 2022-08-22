using tabuleiro;

namespace xadrez_console.tabuleiro
{
    public class Peca
    {
        public Posicao? Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; set; }
        public Tabuleiro Tab { get; set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Tab = tab;
            Cor = cor;
            QteMovimentos = 0;
        }
    }
}
