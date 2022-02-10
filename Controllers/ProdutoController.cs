using Api.Core.Dto.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data.Repository.Interfaces;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class ProdutoController:ControllerBase
    {
        private readonly IRepositorysOfTheUnitOfWork _repositorysOfTheUnitOfWork;

        public ProdutoController(IRepositorysOfTheUnitOfWork repositorysOfTheUnitOfWork)
        {
            _repositorysOfTheUnitOfWork = repositorysOfTheUnitOfWork;
        }

        [HttpGet("/api/produto")]
        public  async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            try
            {
                var produtos = await _repositorysOfTheUnitOfWork.Produto
               .FindAllByCondition(p => p.Status == ProdutoStatus.Ativo).Include(p => p.Departamento).ToListAsync();
                return Ok(produtos);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("/api/produto")]
        public ActionResult<Produto> Inserir([FromBody] Produto produto)
        {
            try
            {
                if (produto == null) return BadRequest();
                _repositorysOfTheUnitOfWork.Produto.Create(produto);
                _repositorysOfTheUnitOfWork.save();
                return Ok(produto);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut("/api/produto")]
        public ActionResult<Produto> Atualizar([FromBody] Produto produto)
        {
            try
            {
                if (produto == null) return BadRequest();
                _repositorysOfTheUnitOfWork.Produto.Update(produto);
                _repositorysOfTheUnitOfWork.save();
                return Ok(produto);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        //[HttpDelete("/api/produto/{id}")]
        //public void Delete(int id)
        //{
        //    var produto = _context.Produtos.Find(id);
        //    if (produto == null)
        //    {
        //        return;
        //    }

        //    produto.Status = ProdutoStatus.Inativo;            
        //    _context.Update(produto);
        //    _context.SaveChanges();
        //}
    }
}
