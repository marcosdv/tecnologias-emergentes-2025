using Garagem.Api.Controllers;
using Garagem.Application.Commands;
using Garagem.Application.Commands.Modelo;
using Garagem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Garagem.Tests.Api.Controllers;

[TestClass]
public class ModeloControllerTests
{
    private readonly Mock<IModeloService> _service;
    private readonly ModeloController _controller;

    public ModeloControllerTests()
    {
        _service = new Mock<IModeloService>();
        _controller = new ModeloController(_service.Object);
    }

    [TestMethod]
    public void DadoUmCommandoValidoAdicionarDeveRetornarSucesso()
    {
        //Arrange
        var command = new ModeloAdicionarCommand
        {
            Nome = "Nome",
            Marca = "Marca"
        };

        var commandResult = new CommandResult(true,
            It.IsAny<string>(), It.IsAny<object>());

        _service.Setup(x => x.Adicionar(command)).Returns(commandResult);

        //Act
        var result = _controller.Adicionar(command);

        //Assert
        var okResult = (result as OkObjectResult).Value as CommandResult;
        Assert.IsTrue(okResult.Sucesso);
    }

    [TestMethod]
    public void DadoUmCommandoInvalidoAdicionarDeveRetornarErro()
    {
        //Arrange
        var command = new ModeloAdicionarCommand();

        var commandResult = new CommandResult(false,
            It.IsAny<string>(), It.IsAny<object>());

        _service.Setup(x => x.Adicionar(command)).Returns(commandResult);

        //Act
        var result = _controller.Adicionar(command);

        //Assert
        var badResult = (result as BadRequestObjectResult).Value as CommandResult;
        Assert.IsFalse(badResult.Sucesso);
    }

    [TestMethod]
    public void DadoUmCommandoValidoAlterarDeveRetornarSucesso()
    {
        //Arrange
        var commandResult = new CommandResult(true,
            It.IsAny<string>(), It.IsAny<object>());

        _service
            .Setup(x => x.Alterar(It.IsAny<ModeloAlterarCommand>()))
            .Returns(commandResult);

        //Act
        var result = _controller.Alterar(It.IsAny<ModeloAlterarCommand>());

        //Assert
        var okResult = (result as OkObjectResult).Value as CommandResult;
        Assert.IsTrue(okResult.Sucesso);
    }
}
