using Garagem.Application.Commands;
using Garagem.Application.Commands.Modelo;
using Garagem.Application.Entities;
using Garagem.Application.Repositories;
using Garagem.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Garagem.Tests.Application.Services;

[TestClass]
public class ModeloServiceTests
{
    private readonly ModeloService _service;
    private readonly Mock<IModeloRepository> _repository;

    public ModeloServiceTests()
    {
        _repository = new Mock<IModeloRepository>();
        _service = new ModeloService(_repository.Object);
    }

    [TestMethod]
    [DataRow("", "", 2)]
    [DataRow("Nome", "", 1)]
    [DataRow("", "Marca", 1)]
    public void DadoUmCommandInvalidoDeveRetornarErroAoAdicionar(
        string nome, string marca, int qtdErrosEsperados)
    {
        //Arrange
        var command = new ModeloAdicionarCommand
        {
            Nome = nome,
            Marca = marca
        };

        //Act
        var result = _service.Adicionar(command);

        //Assert
        var qtdErros = result.Dados is List<string> errors ? errors.Count : 0;

        Assert.IsFalse(result.Sucesso);
        Assert.AreEqual(qtdErrosEsperados, qtdErros);
    }

    [TestMethod]
    public void DadoUmCommandValidoDeveRetornarSucessoAoAdicionar()
    {
        //Arrange
        var command = new ModeloAdicionarCommand
        {
            Nome = "Nome",
            Marca = "Marca"
        };

        //Act
        var result = _service.Adicionar(command);

        //Assert
        var qtdErros = result.Dados is List<string> errors ? errors.Count : 0;

        Assert.IsTrue(result.Sucesso);
        Assert.AreEqual(0, qtdErros);
    }

    [TestMethod]
    [DataRow(1, "", "", 2)]
    [DataRow(0, "", "", 3)]
    [DataRow(0, "Nome", "Marca", 1)]
    [DataRow(0, "Nome", "", 2)]
    public void DadoUmCommandInvalidoDeveRetornarErroAoAlterar(int codigo,
        string nome, string marca, int qtdErrosExperados)
    {
        //Arrange
        var command = new ModeloAlterarCommand
        {
            Id = codigo,
            Nome = nome,
            Marca = marca
        };

        //Act
        var result = _service.Alterar(command);

        //Assert
        var qtdErros = result.Dados is List<string> errors ? errors.Count : 0;
        Assert.IsFalse(result.Sucesso);
        Assert.AreEqual(qtdErrosExperados, qtdErros);
    }

    [TestMethod]
    public void DadoUmModeloNaoExistenteBancoDeveRetornarErroAoAlterar()
    {
        //Arrange
        var command = new ModeloAlterarCommand
        {
            Id = 1,
            Nome = "Nome",
            Marca = "Marca"
        };

        //Act
        var result = _service.Alterar(command);

        //Assert
        var qtdErros = result.Dados is List<string> errors ? errors.Count : 0;
        Assert.IsFalse(result.Sucesso);
        Assert.AreEqual(0, qtdErros);
    }

    [TestMethod]
    public void DadoUmCommandValidoDeveRetornarSucessoAoAlterar()
    {
        //Arrange
        var command = new ModeloAlterarCommand
        {
            Id = 1,
            Nome = "Nome",
            Marca = "Marca"
        };

        var modelo = new Modelo();

        _repository.Setup(x => x.GetById(It.IsAny<int>())).Returns(modelo);

        //Act
        var result = _service.Alterar(command);

        //Assert
        var qtdErros = result.Dados is List<string> errors ? errors.Count : 0;
        Assert.IsTrue(result.Sucesso);
        Assert.AreEqual(0, qtdErros);
    }
}
