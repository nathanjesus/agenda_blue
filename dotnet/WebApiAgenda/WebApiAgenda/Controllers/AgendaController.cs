using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Domian;
using WebApiAgenda.Models;
using AutoMapper;

namespace WebApiAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IDomainApplication _domainApplication;
        private readonly IMapper _mapper;

        public AgendaController(IDomainApplication domainApplication, IMapper mapper)
        {
            _domainApplication = domainApplication;
            _mapper = mapper;
        }

        // GET: api/Agenda
        [HttpGet]
        public ActionResult<IEnumerable<AgendaInputView>> GetAgenda()
        {
            var agendas =  _domainApplication.GetAllAgenda();
            if (agendas == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<AgendaInputView>>(agendas.ToList()));
        }

        // GET: api/Agenda/5
        [HttpGet("{id}")]
        public  ActionResult<AgendaInputView> GetAgenda(string id)
        {
            Int32 Id;
            if (Int32.TryParse(id, out Id))
            {
                var agenda =  _domainApplication.GetAgendaFindById(Id);

                if (agenda == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<AgendaInputView>(agenda));

            }
            return BadRequest();                  
        }

        // PUT: api/Agenda/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public  IActionResult PutAgenda(string id, AgendaInputView model)
        {

            var agenda = _mapper.Map<Agenda>(model);
            if (id != model.id)
            {
                return BadRequest();
            }                          

            try
            {
                 _domainApplication.UpdateAgenda(agenda);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! AgendaExists(Convert.ToInt32(id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Agenda
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Agenda> PostAgenda(AgendaInputView model)
        {
            var agenda = _mapper.Map<Agenda>(model);            
            try
            {                
                 _domainApplication.AddAgenda(agenda);
            }
            catch (DbUpdateException)
            {
                if (AgendaExists(agenda.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAgenda", new { id = agenda.Id }, agenda);
        }

        // DELETE: api/Agenda/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAgenda(string id)
        {
            Int32 Id;
            if(Int32.TryParse(id, out Id))
            {
                var agenda =  _domainApplication.GetAgendaFindById(Id);
                if (agenda == null)
                {
                    return NotFound();
                }
                 _domainApplication.DeleteAgenda(Id);

                return Ok();
            }
            return BadRequest();
        }

        private bool AgendaExists(int id)
        {
            return _domainApplication.AgendaExiste(id);
        }
    }
}
