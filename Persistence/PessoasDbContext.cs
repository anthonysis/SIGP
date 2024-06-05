using EventosAPI.Entities;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace EventosAPI.Persistence
{
    public class PessoasDbContext
    {
        public List<Pessoa> Pessoas { get; set; }

        public PessoasDbContext()
        {
            Pessoas = new List<Pessoa>();
        }

    }
}
