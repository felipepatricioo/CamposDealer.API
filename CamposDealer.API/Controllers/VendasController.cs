using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CamposDealer.API.Models;
using CamposDealer.API.Models.Context;
using AutoMapper;
using CamposDealer.API.Models.DTO;

namespace CamposDealer.API.Controllers
{
    [ApiController]
    [Route("/Sites/TesteAPI/venda")]
    public class VendasController : Controller
    {
        private readonly MicrosoftSQLContext _context;
        private IMapper _mapper;
        public VendasController(MicrosoftSQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }


        [HttpGet]
        public async Task<IEnumerable<Venda>> GetVendas(string nameOrDesc)
        {
            Cliente client = await _context.Cliente.Where(c => c.NmCliente == nameOrDesc).FirstOrDefaultAsync();
            Produto product = await _context.Produto.Where(p => p.DscProduto == nameOrDesc).FirstOrDefaultAsync();

            if(product == null)
            {
                return await _context.Vendas.Where(v => v.IdCliente == client.IdCliente).ToListAsync();
            } else if(client == null)
            {
                return await _context.Vendas.Where(v => v.IdProduto == product.IdProduto).ToListAsync();
            }

            return await _context.Vendas.Where(v => v.IdProduto == product.IdProduto).ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateVenda(VendaDTO vendaDto)
        {
            Venda venda = _mapper.Map<Venda>(vendaDto);
            venda.VlrTotalVenda = venda.VlrUnitarioVenda * venda.QtdVenda;
            venda.DthVenda = DateTime.Now;
            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();
            return Ok("Venda Criada com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateVenda(VendaDTO vendaDto, int id)
        {
            Venda venda = _mapper.Map<Venda>(vendaDto);
            venda.IdVenda = id;
            venda.VlrTotalVenda = venda.VlrUnitarioVenda * venda.QtdVenda;
            _context.Vendas.Update(venda);
            await _context.SaveChangesAsync();
            return Ok(venda);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteVenda(int id)
        {
            Venda venda = await _context.Vendas.Where(v => v.IdVenda == id).FirstOrDefaultAsync();
            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
            return "Venda deletada com sucesso!";
        }
    }
}
