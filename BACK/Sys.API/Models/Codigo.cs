using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys.API.Models
{
    public class Codigo
    {
        public int Id { get; set; }
        public string CodigoItem { get; set; }
        public string Descricao { get; set; }
        public StatusEnum Status { get; set; }



        public Codigo() { }
        
        public Codigo(int id)
        {
            Id = id;
        }



    }
}