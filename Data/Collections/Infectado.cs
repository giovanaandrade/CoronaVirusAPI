using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace CoronaVirusAPI.Data.Collections
{
    public class Infectado
    {
        public Infectado(DateTime dataNascimento, int genero, double latitude, double longitude)
        {
            DataNascimento = dataNascimento;
            Genero = (Genero)genero;
            Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
            DataCadastro = DateTime.Now;
        }

        public DateTime DataNascimento { get; private set; }
        public Genero Genero { get; private set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; private set; }
        public DateTime DataCadastro { get; private set; }
    }
}

