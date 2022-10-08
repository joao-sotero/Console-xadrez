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
        public HashSet<Peca> Pecas { get; set; }
        public HashSet<Peca> Capturadas { get; set; }


        public PartidaXadrez()
        {
            Tab = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocaPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
           HashSet<Peca> aux = new HashSet<Peca>();
           foreach(Peca peca in Capturadas)
            {
                if(peca.Cor == cor)
                    aux.Add(peca);
            }
           return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in Capturadas)
            {
                if (peca.Cor == cor)
                    aux.Add(peca);
            }
            return aux;
        }


        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));

            ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));
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
            var pecaCapturada = Tab.RemovePeca(destino);
            Tab.ColocaPeca(peca, destino);
            if(pecaCapturada != null)
                Capturadas.Add(pecaCapturada);
        }
    }
}
