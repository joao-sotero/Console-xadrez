﻿using tabuleiro;
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
        public bool Xeque { get; private set; }
        public Peca VulneravelEnPassant { get; private set; }


        public PartidaXadrez()
        {
            Tab = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            VulneravelEnPassant = null;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public bool TesteXequemate(Cor cor)
        {
            if (!EstaEmXeque(cor))
                return false;

            foreach(Peca x in PecasEmJogo(cor)){
                bool[,] mat = x.MovimentosPossiveis();
                for(int i =0; i<Tab.Linhas; i++)
                    for(int j = 0; j < Tab.Colunas; j++)
                        if (mat[i, j])
                        {
                            var origem = x.Posicao;
                            var destino = new Posicao(i, j);
                            var pecaCapturada = ExecutaMovimento(origem, destino);
                            var testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(x.Posicao, destino, pecaCapturada);
                         
                            if (!testeXeque)
                                return false;
                        }
            }
            return true;
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
            foreach (Peca x in Pecas)
                if (x.Cor == cor)
                    aux.Add(x);
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
                return Cor.Preta;
            else
                return Cor.Branca;
        }

        public Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
                if (x is Rei)
                    return x;

            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca R = Rei(cor);
            if (R == null)
                throw new TabuleiroException($"Não tem rei da cor: {cor} no tabuleiro!");

            foreach (Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                    if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                        return true;
            }

            return false;
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Dama(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(Tab, Cor.Branca, this));
            ColocarNovaPeca('f', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('a', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('b', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('c', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('d', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('e', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('f', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('g', 2, new Peao(Tab, Cor.Branca, this));
            ColocarNovaPeca('h', 2, new Peao(Tab, Cor.Branca, this));

            ColocarNovaPeca('a', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Dama(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(Tab, Cor.Preta, this));
            ColocarNovaPeca('f', 8, new Bispo(Tab, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(Tab, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('a', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('b', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('c', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('d', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('e', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('f', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('g', 7, new Peao(Tab, Cor.Preta, this));
            ColocarNovaPeca('h', 7, new Peao(Tab, Cor.Preta, this));
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            var pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em Xeque!");
            }

            if (EstaEmXeque(Adversaria(JogadorAtual)))
                Xeque = true;

            if (TesteXequemate(Adversaria(JogadorAtual)))
                Terminada = true;
            else
            {
                Turno++;
                MudarJogador();
            }
            
            Peca p = Tab.Peca(destino);

            //#jogada especial en passant
            if (p is Peao && (destino.Linha == origem.Linha - 2 || (destino.Linha == origem.Linha + 2)))
                VulneravelEnPassant = p;
            else
                VulneravelEnPassant = null;

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
            if (!Tab.Peca(origem).MovimentoPossivel(destino))
                throw new TabuleiroException("Posição de destino invalida");
        }

        private void MudarJogador()
        {
            if (JogadorAtual == Cor.Branca)
                JogadorAtual = Cor.Preta;
            else
                JogadorAtual = Cor.Branca;
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            var peca =  Tab.RemovePeca(origem);
            peca.IncrementarQteMovimentos();
            var pecaCapturada = Tab.RemovePeca(destino);
            Tab.ColocaPeca(peca, destino);

            if(pecaCapturada != null)
                Capturadas.Add(pecaCapturada);

            //#jogada especial roque pequeno
            if (peca is Rei && destino.Coluna == origem.Coluna + 2) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca T = Tab.RemovePeca(origemT);
                T.IncrementarQteMovimentos();
                Tab.ColocaPeca(T, destinoT);
            }

            //#jogada especial roque grande
            if (peca is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                var T = Tab.RemovePeca(origemT);
                T.IncrementarQteMovimentos();
                Tab.ColocaPeca(T, destinoT);
            }

            //#jogada especial en passant
            if(peca is Peao)
            {
                if(origem.Coluna != destino.Coluna && pecaCapturada == null) 
                {
                    Posicao posP;
                    if(peca.Cor == Cor.Branca)
                        posP = new Posicao(destino.Linha + 1, destino.Coluna);
                    else
                        posP = new Posicao(destino.Linha - 1, destino.Coluna);
                    
                    pecaCapturada = Tab.RemovePeca(posP);
                    Capturadas.Add(pecaCapturada); 
                }
            }

            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            var peca = Tab.RemovePeca(destino);
            peca.DecrementarQteMovimentos();
            if(pecaCapturada != null)
            {
                Tab.ColocaPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            Tab.ColocaPeca(peca, origem);

            //#jogada especial roque pequeno
            if (peca is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca T = Tab.RemovePeca(destinoT);
                T.DecrementarQteMovimentos();
                Tab.ColocaPeca(T, origemT);
            }

            //#jogada especial roque grande
            if (peca is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = Tab.RemovePeca(destinoT);
                T.DecrementarQteMovimentos();
                Tab.ColocaPeca(T, origemT);
            }

            //#jogada especial en passant
            if(peca is Peao)
            {
                if(origem.Coluna != destino.Coluna && pecaCapturada == VulneravelEnPassant)
                {
                    Peca peao = Tab.RemovePeca(destino);
                    Posicao posP;
                    if(peca.Cor == Cor.Branca)
                        posP = new Posicao(3, destino.Coluna);
                    else
                        posP = new Posicao(4, destino.Coluna);
                 
                    Tab.ColocaPeca(peao, posP);
                }
            }
        }
    }
}
