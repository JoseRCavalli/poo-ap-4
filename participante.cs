using System.Collections.Generic;

namespace Modelos
{
    public class Participante
    {
        public string NomeCompleto { get; set; }
        public List<Compromisso> Compromissos { get; set; } = new();

        public Participante(string nome)
        {
            NomeCompleto = nome;
        }

        public void AdicionarCompromisso(Compromisso c)
        {
            if (!Compromissos.Contains(c))
                Compromissos.Add(c);
        }

        public override string ToString()
        {
            return NomeCompleto;
        }
    }
}
