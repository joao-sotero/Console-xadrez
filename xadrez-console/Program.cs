using tabuleiro;
using xadrez_console.tabuleiro;
using xadrez_console.xadrez;

namespace xadrez_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tab = new Tabuleiro(8, 8);

            tab.ColocaPeca(new Torre(tab, Cor.Branca), new Posicao(0, 0));
            tab.ColocaPeca(new Rei(tab, Cor.Branca), new Posicao(1, 3));
            tab.ColocaPeca(new Torre(tab, Cor.Branca), new Posicao(2, 4));



            Tela.imprimirTabuleiro(tab);
            Console.ReadLine(); 
        }
    }
}