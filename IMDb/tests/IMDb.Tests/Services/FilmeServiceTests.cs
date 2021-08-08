
using ERP.Business.Tests.Providers;
using IMDb.Business.Intefaces;
using IMDb.Business.Services;
using Moq;
using Xunit;

namespace ERP.Business.Tests.Services
{
    [Collection(nameof(FilmeAutoMockerCollection))]
    public class FilmeServiceTests
    {
        readonly FilmeTestsAutoMockerFixture _filmeTestsAutoMockerFixture;

        private readonly FilmeService _filmeService;

        public FilmeServiceTests(FilmeTestsAutoMockerFixture filmeTestsFixture)
        {
            _filmeTestsAutoMockerFixture = filmeTestsFixture;
            _filmeService = _filmeTestsAutoMockerFixture.ObterService();
        }

        #region Adicionar

        [Fact(DisplayName = "Adicionar com Sucesso")]
        [Trait("Categoria", "Filme Service Tests")]
        public async void FilmeService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var registro = _filmeTestsAutoMockerFixture.GerarRegistroValido();
            _filmeTestsAutoMockerFixture.Mocker.GetMock<IFilmeRepository>().Setup(c => c.Adicionar(registro));

            // Act
            var retorno = await _filmeService.Adicionar(registro);

            // Assert
            Assert.True(retorno);
            _filmeTestsAutoMockerFixture.Mocker.GetMock<IFilmeRepository>().Verify(r => r.Adicionar(registro), Times.Once);
        }

        [Fact(DisplayName = "Adicionar com Falha nos Dados da Entidade")]
        [Trait("Categoria", "Filme Service Tests")]
        public async void FilmeService_Adicionar_DeveFalharDevidoRegistroInvalido()
        {
            // Arrange
            var registro = _filmeTestsAutoMockerFixture.GerarRegistroInvalido();
            _filmeTestsAutoMockerFixture.Mocker.GetMock<IFilmeRepository>().Setup(c => c.Adicionar(registro));

            // Act
            var retorno = await _filmeService.Adicionar(registro);

            // Assert
            Assert.False(retorno);
            _filmeTestsAutoMockerFixture.Mocker.GetMock<IFilmeRepository>().Verify(r => r.Adicionar(registro), Times.Never);
        }

        #endregion Adicionar

    }
}