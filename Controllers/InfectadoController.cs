using CoronaVirusAPI.Data.Collections;
using CoronaVirusAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Linq;

namespace CoronaVirusAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoViewModel infectadoViewModel)
        {
            var infectado = new Infectado(infectadoViewModel.DataNascimento, infectadoViewModel.Genero, infectadoViewModel.Latitude, infectadoViewModel.Longitude);

            _infectadosCollection.InsertOne(infectado);

            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();

            return Ok(infectados);
        }

    }
}
