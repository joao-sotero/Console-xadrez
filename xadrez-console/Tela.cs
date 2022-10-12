using tabuleiro;
using xadrez;
using xadrez_console.tabuleiro;
using xadrez_console.xadrez;

namespace xadrez_console
{
    public class Tela
    {
        public static void ImprimirPartida(PartidaXadrez px)
        {
            imprimirTabuleiro(px.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(px);
            Console.WriteLine();
            Console.WriteLine("Turno: " + px.Turno);
            Console.WriteLine("Aguardando jogada: " + px.JogadorAtual);
            if(px.Xeque)
                Console.WriteLine("XEQUE!");
        }

        public static void ImprimirPecasCapturadas(PartidaXadrez px)
        {
            Console.WriteLine("Peças capturadas");
            Console.Write("Brancas: ");
            ImprimirConjunto(px.PecasCapturadas(Cor.Branca));
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(px.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca peca in conjunto)
            {
                Console.Write(peca+" ");
            }
            Console.WriteLine("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(tab.Linhas - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            try
            {
                string s = Console.ReadLine();
                char coluna = s[0];
                int linha = int.Parse(s[1] + " ");
                return new PosicaoXadrez(coluna, linha);
            }
            catch (IndexOutOfRangeException)
            {
                //System.FormatException
                throw new TabuleiroException("Digite uma posição valida");
            }
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;   
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(tab.Linhas - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                        Console.BackgroundColor = fundoAlterado;
                    else
                        Console.BackgroundColor = fundoOriginal;

                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = fundoOriginal;
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirPeca(Peca peca)
        {
            var pecaWrite = peca == null ? "-" : peca.ToString();

            if (peca != null && peca.Cor == Cor.Branca)
                Console.Write(pecaWrite +" ");
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(pecaWrite + " ");
                Console.ForegroundColor = aux;
            }
        }
    }
}
