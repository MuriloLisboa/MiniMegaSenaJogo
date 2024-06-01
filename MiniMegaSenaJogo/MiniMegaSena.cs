using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MiniMegaSena
{
    public class MiniMegaSena : Jogo
    {
        private static Random random = new Random();

        public MiniMegaSena(string nomeJogador, int nivel) : base(nomeJogador)
        {
            Nivel = nivel;
            NumerosEscolhidos = new int[6];
            NumerosSorteados = new int[6];
        }

        public override void SortearNumeros()
        {
            int maxNumero = (Nivel == 1) ? 30 : 60;
            for (int i = 0; i < 6; i++)
            {
                int numeroSorteado;
                do
                {
                    numeroSorteado = random.Next(1, maxNumero + 1);
                } while (NumerosSorteados.Contains(numeroSorteado));

                NumerosSorteados[i] = numeroSorteado;
            }
        }

        public override int VerificarAcertos()
        {
            return NumerosEscolhidos.Intersect(NumerosSorteados).Count();
        }
    }
}
