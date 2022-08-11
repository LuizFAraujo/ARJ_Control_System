using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sys.API.Models;

namespace Sys.API.DataDb
{
    public class DataDbContext : DbContext
    {
        // O "DataDbContext" recebe o resultado dos parâmetros de
        // configuração do banco de dados passados no "Program.cs".
        // O resultado recebido é passado, também, para o "base", assim quando
        // executar os comandos do efcore, irá criar o BD, com base nos "DbSets"
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }
        // -----------------------------------------------

        public DbSet<Codigo> Codigos { get; set; }

    }
}