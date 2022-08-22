using xadrez_console.tabuleiro;

namespace xadrez_console
{
    public class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Colunas; j++)
                {
                    var peca = tab.peca(i, j) == null ? "-" : tab.peca(i, j).ToString();

                    Console.Write(peca + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
