using Data.Models;
using Repository;

namespace Domian
{
    public class DomainApplication : IDomainApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        public DomainApplication(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        #region Agenda
        public  IEnumerable<Agenda> GetAllAgenda() =>  _unitOfWork.AgendaRepository.GetAll();
        public  Agenda GetAgendaFindById(int id) =>  _unitOfWork.AgendaRepository.FindBy(a => a.Id == id);
        public  Agenda GetAgendaFindByEmail(string email) =>   _unitOfWork.AgendaRepository.FindBy(a => a.Email == email);
        public  void AddAgenda(Agenda agenda) =>  _unitOfWork.AgendaRepository.Add(agenda);  
         
        public void  DeleteAgenda(int id)
        {
            var agenda = GetAgendaFindById(id);
             _unitOfWork.AgendaRepository.Delete(agenda);
        }
        
        public void  UpdateAgenda(Agenda agenda) =>  _unitOfWork.AgendaRepository.Update(agenda);

        public bool AgendaExiste(int id)
        {
            var agenda =   _unitOfWork.AgendaRepository.FindBy(a => a.Id == id);
            return agenda != null;
        }
     
        #endregion
    }
}
