using System;
using System.Collections.Generic;

namespace Modelos
{
    public class Compromisso
    {
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public Usuario Usuario { get; set; }
        public Local Local { get; set; }

        public List<Participante> Participantes { get; set; } = new();
        public List<Anotacao> Anotacoes { get; set; } = new();

        public Compromisso(DateTime dataHora, string descricao, Usuario usuario, Local local)
        {
            if (dataHora <= DateTime.Now)
                throw new ArgumentException("Data e hora devem estar no futuro.");
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("Descrição é obrigatória.");

            DataHora = dataHora;
            Descricao = descricao;
            Usuario = usuario;
            Local = local;
        }

        public void AdicionarParticipante(Participante p)
        {
            if (!Participantes.Contains(p))
            {
                Participantes.Add(p);
                p.AdicionarCompromisso(this);
            }
        }

        public void AdicionarAnotacao(string texto)
        {
            Anotacoes.Add(new Anotacao(texto));
        }

        public override string ToString()
        {
            return $"{DataHora}: {Descricao} em {Local.Nome}";
        }
    }
}
