namespace Modelos
{
    public class Local
    {
        public string Nome { get; set; }
        public int CapacidadeMaxima { get; set; }

        public Local(string nome, int capacidade)
        {
            Nome = nome;
            CapacidadeMaxima = capacidade;
        }

        public bool ValidarCapacidade(int quantidade)
        {
            return quantidade <= CapacidadeMaxima;
        }

        public override string ToString()
        {
            return $"{Nome} (Capacidade: {CapacidadeMaxima})";
        }
    }
}
