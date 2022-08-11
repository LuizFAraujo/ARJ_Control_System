using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sys.API.Models;

namespace Sys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodigoController : ControllerBase
    {



        public IEnumerable<Codigo> CodigosLista = new List<Codigo>(){
                new Codigo(1),
                new Codigo(2),
                new Codigo(3),
            };



        [HttpGet]
        public IEnumerable<Codigo> Get()
        {
            return CodigosLista;

        }

        [HttpGet("{id}")]
        public Codigo Get(int id)
        {
            return CodigosLista.FirstOrDefault(cd => cd.Id == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Return post código.";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Return put código ID: {id}.";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Return delete código ID: {id}.";
        }

    }
}