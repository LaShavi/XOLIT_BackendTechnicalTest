//using Moq;
//using Xunit;
//using Microsoft.AspNetCore.Mvc;
//using Api.Controllers;
//using Application.Services;
//using Domain.Entities;
//using System;
//using System.Threading.Tasks;
//using FluentAssertions;

//namespace Tests.Controllers
//{
//    public class ReservaControllerTests
//    {
//        private readonly Mock<ReservaService> _mockReservaService;
//        private readonly ReservaController _controller;

//        // Constructor para inicializar el controlador con el mock
//        public ReservaControllerTests()
//        {
//            // Inicializamos el mock del servicio ReservaService
//            _mockReservaService = new Mock<ReservaService>();
//            _controller = new ReservaController(_mockReservaService.Object);
//        }

//        // Test para GetById: Verificar que se devuelve un OK cuando la reserva existe
//        [Fact]
//        public async Task GetById_ShouldReturnOk_WhenReservaExists()
//        {
//            // Arrange: Configuración de los datos
//            var reservaId = Guid.NewGuid(); // Generamos un GUID único para la reserva
//            var reserva = new Reserva
//            {
//                Id = reservaId,
//                FechaRegistro = DateTime.Now,
//                FechaIniReserva = DateTime.Now.AddHours(1),
//                FechaFinReserva = DateTime.Now.AddHours(2),
//                Estado = 1,
//                ClienteId = Guid.NewGuid(),
//                EspaciosCompartidosId = Guid.NewGuid()
//            };

//            // Configuramos el mock para que devuelva la reserva cuando se llame a GetByIdAsync
//            _mockReservaService.Setup(service => service.GetByIdAsync(reservaId))
//                               .ReturnsAsync(reserva);

//            // Act: Llamada al método GetById del controlador
//            var result = await _controller.GetById(reservaId);

//            // Assert: Verificamos que la respuesta es un OkObjectResult con el código de estado 200
//            var okResult = result.Result as OkObjectResult;
//            okResult.Should().NotBeNull();
//            okResult.StatusCode.Should().Be(200);
//            okResult.Value.Should().Be(reserva);
//        }

//        // Test para GetById: Verificar que se devuelve NotFound cuando la reserva no existe
//        [Fact]
//        public async Task GetById_ShouldReturnNotFound_WhenReservaDoesNotExist()
//        {
//            // Arrange: Generamos un GUID que no existe en la base de datos
//            var reservaId = Guid.NewGuid();

//            // Configuramos el mock para que devuelva null (simulando que no se encuentra la reserva)
//            _mockReservaService.Setup(service => service.GetByIdAsync(reservaId))
//                               .ReturnsAsync((Reserva)null);

//            // Act: Llamada al método GetById del controlador
//            var result = await _controller.GetById(reservaId);

//            // Assert: Verificamos que la respuesta es un NotFoundResult con el código de estado 404
//            var notFoundResult = result.Result as NotFoundResult;
//            notFoundResult.Should().NotBeNull();
//            notFoundResult.StatusCode.Should().Be(404);
//        }
//    }
//}
