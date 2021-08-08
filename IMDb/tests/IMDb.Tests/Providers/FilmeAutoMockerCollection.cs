using Bogus;
using Bogus.DataSets;
using IMDb.Business.Models;
using IMDb.Business.Services;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ERP.Business.Tests.Providers
{
    [CollectionDefinition(nameof(FilmeAutoMockerCollection))]
    public class FilmeAutoMockerCollection : ICollectionFixture<FilmeTestsAutoMockerFixture>
    {
    }

    public class FilmeTestsAutoMockerFixture : IDisposable
    {
        public FilmeService FilmeService;
        public AutoMocker Mocker;

        public Filme GerarRegistroValido()
        {
            return GerarRegistroValido(1, true).FirstOrDefault();
        }

        public IEnumerable<Filme> ObterVariados()
        {
            var lista = new List<Filme>();

            lista.AddRange(GerarRegistroValido(50, true).ToList());
            lista.AddRange(GerarRegistroValido(50, false).ToList());

            return lista;
        }

        public IEnumerable<Filme> GerarRegistroValido(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var registros = new Faker<Filme>("pt_BR")
                .CustomInstantiator(f => new Filme
                {
                    Nome = f.Name.FullName(genero),
                    Diretor = f.Name.FullName(genero),
                    Genero = f.Name.FullName(genero),
                    Atores = new List<Ator> { new Ator { Nome = f.Name.FullName(genero) } },
                });

            return registros.Generate(quantidade);
        }

        public Filme GerarRegistroInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var registro = new Faker<Filme>("pt_BR")
                .CustomInstantiator(f => new Filme { });

            return registro;
        }

        public FilmeService ObterService()
        {
            Mocker = new AutoMocker();
            FilmeService = Mocker.CreateInstance<FilmeService>();

            return FilmeService;
        }
        public void Dispose()
        {
        }
    }
}