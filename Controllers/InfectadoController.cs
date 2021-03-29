using CoronaVirusAPI.Data.Collections;
using CoronaVirusAPI.Models;
using CoronaVirusAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaVirusAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        InfectadoRepository _infectadoRepository;

        public InfectadoController(InfectadoRepository infectadoRepository)
        {
            _infectadoRepository = infectadoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> SalvarInfectado([FromBody] InfectadoViewModel infectadoViewModel)
        {
            try
            {
                await _infectadoRepository.SalvarInfectado(infectadoViewModel);

                return StatusCode(201, "Infectado adicionado com sucesso");
            }
            catch (Exception e)
            {

                return Conflict(e.Message);
            }

           
        }

        [HttpGet]
        public async Task<IActionResult> ObterInfectados()
        {
            List<Infectado> infectados;

            try
            {
                infectados = await _infectadoRepository.ObterTodosInfectados();
            }
            catch (Exception e)
            {

                return Conflict(e.Message);
            }

            return Ok(infectados);
        }

    }
}
