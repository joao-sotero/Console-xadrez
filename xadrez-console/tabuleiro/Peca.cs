using tabuleiro;

namespace xadrez_console.tabuleiro
{
    public class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; set; }
        public Tabuleiro Tab { get; set; }

        public Peca(Posicao posicao, Cor cor)
        {
            Posicao = posicao;
            Cor = cor;
            QteMovimentos = 0;
        }
    }
}
