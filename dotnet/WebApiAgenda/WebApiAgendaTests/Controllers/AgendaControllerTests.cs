using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiAgenda.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domian;
using Moq;
using WebApiAgenda.Models;

namespace WebApiAgenda.Controllers.Tests
{
    [TestClass()]
    public class AgendaControllerTests
    {
        private static AgendaController agendaController;
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            agendaController = new AgendaController(new Mock<IDomainApplication>().Object, new Mock<IMapper>().Object);
        }

        [TestMethod()]
        public void GetAgendaTest()
        {
            Assert.IsInstanceOfType(agendaController.GetAgenda(), typeof(List<AgendaViewModel>));
        }
    }
}