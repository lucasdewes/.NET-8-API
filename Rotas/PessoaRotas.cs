using PrimeiraAPI.Models;

namespace PrimeiraAPI.Rotas
{
    public static class PessoaRotas
    {
        //dados temporários para
        public static List<Pessoa> ListaPessoas = new()
        {
            new Pessoa(id: Guid.NewGuid(), nome: "Neymar"),
            new Pessoa(id: Guid.NewGuid(), nome: "Cristiano"),
            new Pessoa(id: Guid.NewGuid(), nome: "Messi"),
            new Pessoa(id: Guid.NewGuid(), nome: "Lucas")
        };

        public static void MapPessoaRotas(this WebApplication app)
        {
            app.MapGet(pattern: "/pessoas", handler: () => ListaPessoas);

            app.MapGet("/pessoas/{nome}",
                handler: (string nome) => ListaPessoas.Find(x => x.Nome == nome));

            app.MapGet("/pessoas/{id}",
                handler: (string id) => ListaPessoas.Find(x => x.Id.ToString() == id));

            app.MapPost(pattern: "pessoas",
                handler: (Pessoa pessoa) =>
                {
                    if (pessoa.Nome.Count() < 4)
                        return Results.BadRequest(error: new { message = "Ao menos 4 caracteres!" });

                    ListaPessoas.Add(pessoa);
                    return Results.Ok(pessoa);
                }
            );
        }
    }
}