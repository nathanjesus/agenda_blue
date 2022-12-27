using Data.Models;
using Repository.Concrete;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _entities = null;
        public UnitOfWork() => _entities = new AppDbContext();

        private IAgendaRepository _AgendaRepository = null;

        public IAgendaRepository AgendaRepository
        {
            get
            {
                if(_AgendaRepository == null)
                {
                    _AgendaRepository = new AgendaRepository(_entities);
                }
                return _AgendaRepository;
            }
        }

      
    }
}
