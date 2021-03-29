using CoronaVirusAPI.Data.Collections;
using CoronaVirusAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaVirusAPI.Repositories
{
    public class InfectadoRepository
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoRepository(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());

        }
        public async Task SalvarInfectado(InfectadoViewModel infectadoViewModel)
        {
           var infectado = new Infectado(infectadoViewModel.DataNascimento, infectadoViewModel.Genero, infectadoViewModel.Latitude, infectadoViewModel.Longitude);

           await _infectadosCollection.InsertOneAsync(infectado);

  
        }

        public async Task<List<Infectado>> ObterTodosInfectados()
        {
            List<Infectado> infectados = new List<Infectado>();

            var filter = new BsonDocument();
            using (var cursor = await _infectadosCollection.Find(filter).ToCursorAsync())
            {
                while (await cursor.MoveNextAsync())
                {
                    foreach (var doc in cursor.Current)
                    {
                        infectados.Add(doc);
                    }
                }
            }

            return infectados;
        }
    }
}
