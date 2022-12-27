using AutoMapper;
using Data.Models;
using Domian;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAgenda.Controllers;
using WebApiAgenda.Models;
using WebApiAgenda.Profiles;
using Xunit;

namespace WebApiAgenda.Test.Controllers
{
    public  class ControllersTests
    {
        AgendaController _agendaController;
        Mock<IDomainApplication> _dominio;
        private static IMapper _mapper;

        public ControllersTests()
        {
            _dominio = new Mock<IDomainApplication>();
            if(_mapper== null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AgendaProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            _agendaController = new AgendaController(_dominio.Object, _mapper);
        }

        [Fact]
        public  void GetAgendaAll()
        {
            _dominio.Setup(repo => repo.GetAllAgenda()).Returns( new List<Agenda> {
                new Agenda { Id = 1, Nome = "Nathan de Jesus", Email = "nathan.j.filho@gmail.com", Telefone = "81988870974" },
                new Agenda { Id = 2, Nome = "João Vitor", Email = "zaicon@gmail.com", Telefone = "81982546546" }

                });
            var result = _agendaController.GetAgenda();
            var objResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, objResult.StatusCode);
        }
        [Fact]
        public void GetAgendaAll_Return404()
        {
            _dominio.Setup(repo => repo.GetAllAgenda()).Returns(value:null);
            var result = _agendaController.GetAgenda();
            var objResult = Assert.IsType<NotFoundResult>(result.Result);
            Assert.Equal(404, objResult.StatusCode);
        }
        [Theory]
        [InlineData("1")]
        public void GetAgendaId(string id)
        {
            _dominio.Setup(repo => repo.GetAgendaFindById(Convert.ToInt32(id))).Returns(new Agenda { Id = 1, Nome = "Nathan de Jesus", Email = "nathan.j.filho@gmail.com", Telefone = "81988870974" });
            var result = _agendaController.GetAgenda(id);
            var objResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, objResult.StatusCode);
        }

        [Theory]
        [InlineData("1")]
        public void GetAgendaId_Return404(string id)
        {
            _dominio.Setup(repo => repo.GetAgendaFindById(Convert.ToInt32(id))).Returns(value: null);
            var result = _agendaController.GetAgenda(id);
            var objResult = Assert.IsType<NotFoundResult>(result.Result);
            Assert.Equal(404, objResult.StatusCode);
        }

        [Theory]
        [InlineData("1")]

        public void PutAgenda(string id)
        {
            var agenda = new Agenda { Id = 1, Nome = "Teste caminho Feliz", Email = "nathan.j@gmail.com", Telefone = "81988870974" };
            var agendaView = new AgendaInputView {id = "1", nome = "Teste caminho Feliz", email = "nathan.j@gmail.com", telefone = "81988870974" };
            var agendaMock = new Mock<Agenda>();
            _dominio.Setup(repo => repo.UpdateAgenda(It.IsAny<Agenda>()));

            var result = _agendaController.PutAgenda(id, agendaView);
            var objResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, objResult.StatusCode);
        }

        [Fact]
        public  void PostAgenda()
        {
            var agenda = new Agenda { Nome = "Teste caminho Feliz", Email = "nathan.j@gmail.com", Telefone = "81988870974" };
            var agendaView = new AgendaInputView { nome = "Teste caminho Feliz", email = "nathan.j@gmail.com", telefone = "81988870974" };
            var agendaMock = new Mock<Agenda>();
            _dominio.Setup(repo => repo.AddAgenda(It.IsAny<Agenda>()));

            var result = _agendaController.PostAgenda(agendaView);
            var objResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(201, objResult.StatusCode);         
        }
      
        [Theory]
        [InlineData("1")]
        public void DeleteAganda(string id)
        {
            _dominio.Setup(repo => repo.GetAgendaFindById(Convert.ToInt32(id))).Returns(new Agenda { Id = 1, Nome = "Nathan de Jesus", Email = "nathan.j.filho@gmail.com", Telefone = "81988870974" });
            var result = _agendaController.DeleteAgenda(id);
            var objResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, objResult.StatusCode);
        }
        
    }
}
