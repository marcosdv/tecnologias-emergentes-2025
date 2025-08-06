using Aula01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoController : ControllerBase
    {
        [HttpGet]
        public string RelouUordi()
        {
            return "Relou Uordi";
        }

        //[HttpGet]
        //[Route("ola")]
        //parametro nome via QueryString
        [HttpGet("ola")] 
        public string Ola(string nome)
        {
            return $"Olá {nome}"; //return "Olá " + nome;
        }

        //parametros n1, n2 via Path
        [HttpGet("somar/{n1}/{n2}")]
        public double Somar(double n1, double n2)
        {
            return n1 + n2;
        }

        [HttpPost]
        public double Subtrair(Valores valores)
        {
            return valores.Num1 - valores.Num2;
        }

        [HttpPut]
        public IActionResult Multiplicar(Valores valores)
        {
            var result = valores.Num1 * valores.Num2;
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Dividir(Valores valores)
        {
            if (valores.Num2 == 0)
            {
                return BadRequest("O Num2 não pode ser zero");
            }

            var result = valores.Num1 / valores.Num2;
            return Ok(result);
        }
    }
}
