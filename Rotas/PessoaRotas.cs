using PrimeiraAPI.Models;

namespace PrimeiraAPI.Rotas
{
    public static class PessoaRotas
    {
        //dados temporários para
        public static List<Pessoa> Pessoas = new()
        {
            new Pessoa(id: Guid.NewGuid(), nome: "Neymar"),
            new Pessoa(id: Guid.NewGuid(), nome: "Cristiano"),
            new Pessoa(id: Guid.NewGuid(), nome: "Messi"),
            new Pessoa(id: Guid.NewGuid(), nome: "Lucas")
        };

        public static void MapPessoaRotas(this WebApplication app)
        {
            app.MapGet(pattern: "/pessoas", handler: () => Pessoas);
        }
    }
}