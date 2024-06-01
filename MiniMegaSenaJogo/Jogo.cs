using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiniMegaSena
{
    public abstract class Jogo
    {
        public string NomeJogador { get; set; }
        public int[] NumerosEscolhidos { get; set; }
        public int[] NumerosSorteados { get; protected set; }
        public int Nivel { get; set; }

        public Jogo(string nomeJogador)
        {
            NomeJogador = nomeJogador;
        }

        public abstract void SortearNumeros();
        public abstract int VerificarAcertos();
    }
}

