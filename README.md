# Sistema de Compromissos • AP #04

Aplicação em **C# (.NET 7)** para gerenciamento de compromissos com persistência em **JSON**, desenvolvida como trabalho da disciplina de Programação Orientada a Objetos (POO).

---

## Funcionalidades

| Recurso | Descrição |
|---------|-----------|
| **Cadastro de Compromissos** | Data/hora futura, descrição, local, participantes e anotações. |
| **Validações** | Datas no futuro, descrição obrigatória e capacidade do local. |
| **Participantes N : N** | Cada participante pode estar em vários compromissos e vice-versa. |
| **Anotações (Composição)** | Anexadas ao compromisso com carimbo de data/hora. |
| **Menu de Console** | Interface interativa com opções numéricas. |
| **Persistência Automática** | Salvamento/recuperação transparente no arquivo `agenda.json`. |

---

## Estrutura de Pastas

/Modelos/ → Entidades de domínio
Usuario.cs
Compromisso.cs
Participante.cs
Anotacao.cs
Local.cs

/Persistencia/ → Lógica de serialização JSON
RepositorioCompromissos.cs

Program.cs → Menu de console
sistema-compromissos-json.csproj
README.md
agenda.json → Arquivo de dados gerado em tempo de execução

yaml
Copiar
Editar

---

## Estratégia de Serialização

> **Modelo hierárquico (árvore)** — todos os objetos relacionados
> (Local, Participantes, Anotações) são embutidos dentro do próprio
> `Compromisso` no JSON.

### Vantagens

- **JSON único (`agenda.json`)**: fácil de versionar e transportar.
- **Coerência de dados**: cada compromisso é autossuficiente.
- **Simplicidade**: evita IDs cruzados entre múltiplos arquivos.

---

## Como Executar

Pré-requisito: **.NET SDK 7.0** (ou superior) instalado.

```bash
# Restaurar dependências e compilar
dotnet build

# Executar a aplicação
dotnet run
No menu, escolha:

Copiar
Editar
1 – Adicionar compromisso
2 – Listar compromissos
0 – Sair