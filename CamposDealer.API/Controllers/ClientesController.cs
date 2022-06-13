using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CamposDealer.API.Models;
using CamposDealer.API.Models.Context;
using CamposDealer.API.Models.DTO;
using AutoMapper;

namespace CamposDealer.API.Controllers
{
    [ApiController]
    [Route("/Sites/TesteAPI/cliente")]
    public class ClientesController : Controller
    {
        private readonly MicrosoftSQLContext _context;
        private IMapper _mapper;

        public ClientesController(MicrosoftSQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetCliente(string name)
        {
            return await _context.Cliente.Where(c => c.NmCliente == name).ToListAsync();
        }

        [HttpPost]
        public async Task<Cliente> CreateCliente(ClienteDTO clienteDTO)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return await _context.Cliente.Where(c => c.NmCliente == cliente.NmCliente).FirstOrDefaultAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> UpdateCliente(ClienteDTO clienteDTO, int id)
        {
        
            Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
            cliente.IdCliente = id;
            _context.Cliente.Update(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteCliente(int id)
        {
            Cliente cliente = await _context.Cliente.Where(c => c.IdCliente == id).FirstOrDefaultAsync();
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return "Cliente deletado com sucesso!";
        }
    }
}
