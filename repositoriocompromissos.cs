using System.Text.Json;
using System.Text.Json.Serialization;
using Modelos;

namespace Persistencia
{
    public static class RepositorioCompromissos
    {
        private const string CAMINHO = "agenda.json";

        public static void Salvar(List<Compromisso> compromissos)
        {
            var json = JsonSerializer.Serialize(compromissos, new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
            File.WriteAllText(CAMINHO, json);
        }

        public static List<Compromisso> Carregar()
        {
            if (!File.Exists(CAMINHO))
                return new List<Compromisso>();

            var json = File.ReadAllText(CAMINHO);
            return JsonSerializer.Deserialize<List<Compromisso>>(json) ?? new();
        }
    }
}
