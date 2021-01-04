using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cadastroweb.Models;
using System.Data.Entity;


namespace Cadastroweb.DataAccess
{
    public class ConexaoContext: DbContext
    {
        public DbSet<LoginModel> logindb { get; set; }

        public DbSet<PessoalModel> pessoaldb { get; set; }

        public DbSet<TrabalhoModel> trabalhodb { get; set; }

        public DbSet<CasaModel> casadb { get; set; }
    }
}