using System.Collections.Generic;

namespace Modelos
{
    public class Usuario
    {
        public string NomeCompleto { get; set; }

        private List<Compromisso> compromissos = new();

        public IReadOnlyCollection<Compromisso> Compromissos => compromissos.AsReadOnly();

        public Usuario(string nome)
        {
            NomeCompleto = nome;
        }

        public void AdicionarCompromisso(Compromisso c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            compromissos.Add(c);
        }

        public override string ToString()
        {
            return NomeCompleto;
        }
    }
}
