using Domain;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoServico _produtoServico;
        public ProdutoController(IProdutoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var obj = _produtoServico.GetAll();
                return Ok(obj);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        [HttpGet]
        [Route("GetId")]
        public IActionResult GetId(int Id)
        {
            try
            {
                var obj = _produtoServico.GetId(Id);
                return Ok(obj);
            }
            catch (System.Exception err)
            {
                throw new System.Exception(err.Message);
            }
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] Produto produto)
        {
            try
            {
                var obj = _produtoServico.Insert(produto);
                return Ok(obj);
            }
            catch (System.Exception erro)
            {
                throw new System.Exception(erro.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Produto produto)
        {
            try
            {
                var obj = _produtoServico.Update(produto);
                return Ok(obj);
            }
            catch (System.Exception erro)
            {
                throw new System.Exception(erro.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete([FromBody] Produto produto)
        {
            try
            {
                var obj = _produtoServico.Delete(produto);
                return Ok(obj);
            }
            catch (System.Exception erro)
            {
                throw new System.Exception(erro.Message);
            }
        }
    }
}