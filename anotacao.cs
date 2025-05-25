using System;

namespace Modelos
{
    public class Anotacao
    {
        public string Texto { get; set; }
        public DateTime DataCriacao { get; set; }

        public Anotacao(string texto)
        {
            Texto = texto;
            DataCriacao = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{DataCriacao}] {Texto}";
        }
    }
}
