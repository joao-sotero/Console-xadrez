using tabuleiro;
using xadrez;
using xadrez_console.tabuleiro;

namespace xadrez_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var px = new PartidaXadrez();
                while (!px.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(px);

                        Console.WriteLine();
                        Console.Write("origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        px.ValidarPosicaoOrigem(origem);

                        Console.Clear();
                        bool[,] posicoesPossiveis = px.Tab.Peca(origem).MovimentosPossiveis();
                        Tela.imprimirTabuleiro(px.Tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        px.ValidarPosicaoDestino(origem, destino);

                        px.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}