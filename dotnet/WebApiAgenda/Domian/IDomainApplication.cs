using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public  interface IDomainApplication
    {
        #region Agenda
        IEnumerable<Agenda> GetAllAgenda();
        Agenda GetAgendaFindById(int id);
        bool AgendaExiste(int id);
        Agenda GetAgendaFindByEmail(string email);
        void AddAgenda(Agenda agenda);
        void UpdateAgenda(Agenda agenda);
        void DeleteAgenda(int id);
        #endregion
    }
}
