using Data.Models;
using Repository.Generic;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class AgendaRepository : GenericRepository<Agenda>, IAgendaRepository
    {
        private readonly AppDbContext _context;
        public AgendaRepository(AppDbContext entities) : base(entities) => _context = entities;
    }
}
