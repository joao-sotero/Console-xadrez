using tabuleiro;
using xadrez_console.tabuleiro;
using xadrez_console.xadrez;

namespace xadrez_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var posX = new PosicaoXadrez('a', 1);
            Console.WriteLine(posX.ToPosicao());
            Console.ReadLine(); 
        }
    }
}