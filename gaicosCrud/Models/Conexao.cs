using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gaicosCrud.Models
{
    public class Conexao : DbContext
    {
        public Conexao() : base("gaicosCrud")
        {

            
        }

        public DbSet<Pessoa> Pessoa { get; set; }

    }
}