using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sys.API.DataDb;
using Sys.API.Models;

namespace Sys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodigoController : ControllerBase
    {
        private readonly DataDbContext _context;

        public CodigoController(DataDbContext context)
        {
            _context = context;

        }

        // ================================================================
        [HttpGet]
        public IEnumerable<Codigo> Get()
        {
            return _context.Codigos;

        }

        // ================================================================
        [HttpGet("{id}")]
        public Codigo Get(int id)
        {
            var codigo = _context.Codigos.FirstOrDefault(cod => cod.Id == id);

            if (codigo == null)
                throw new Exception("Código inválido!");

            return codigo;
            // return _context.Codigos.FirstOrDefault(cod => cod.Id == id);
        }

        // ================================================================
        [HttpPost]
        public IEnumerable<Codigo> Post(Codigo codigo)
        {
            _context.Codigos.Add(codigo);

            // se, conseguir inserir UM
            // retorna TODOS
            if (_context.SaveChanges() > 0)
                return _context.Codigos;
            else
                // senão, lança uma exceção
                throw new Exception("Não foi possível adicionar novo código!");
        }

        // ================================================================
        [HttpPut("{id}")]
        public Codigo Put(int id, Codigo codigo)
        {
            // se id do objeto diferente do informado, lança uma excecão
            if (codigo.Id != id)
                throw new Exception("Impossível atualizar, código inválido!");

            _context.Update(codigo);

            if (_context.SaveChanges() > 0)
                return _context.Codigos.FirstOrDefault(cod => cod.Id == id);
            else
                return new Codigo();
        }

        // ================================================================
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var codigo = _context.Codigos.FirstOrDefault(cod => cod.Id == id);

            if (codigo == null)
                throw new Exception("Impossível deletar, código inválido!");

            _context.Remove(codigo);

            return _context.SaveChanges() > 0;
        }


    }
}