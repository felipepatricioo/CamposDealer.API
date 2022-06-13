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
    [Route("/Sites/TesteAPI/produto")]
    public class ProdutosController : Controller
    {
        private readonly MicrosoftSQLContext _context;
        private IMapper _mapper;

        public ProdutosController(MicrosoftSQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<Produto>> GetProdutos(string descricao)
        {
            return await _context.Produto.Where(n => n.DscProduto == descricao).FirstOrDefaultAsync();
        }

        [HttpPost]
        public async Task<Produto> CreateProdutos(ProdutoDTO productDto)
        {
            Produto product = _mapper.Map<Produto>(productDto);
            _context.Produto.Add(product);
            await _context.SaveChangesAsync();
            return await _context.Produto.Where(p => p.DscProduto == product.DscProduto).FirstOrDefaultAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> UpdateProduto(ProdutoDTO productDto, int id)
        {
            Produto produto = _mapper.Map<Produto>(productDto);
            produto.IdProduto = id;
            _context.Produto.Update(produto);
            await _context.SaveChangesAsync();
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteProduto(int id)
        {
            Produto product = await _context.Produto.Where(p => p.IdProduto == id).FirstOrDefaultAsync();
            _context.Produto.Remove(product);
            await _context.SaveChangesAsync();
            return "Produto deletado com sucesso!";
        }
    }
}
