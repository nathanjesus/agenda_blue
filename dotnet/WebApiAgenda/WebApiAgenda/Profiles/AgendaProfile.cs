using AutoMapper;
using Data.Models;
using WebApiAgenda.Models;

namespace WebApiAgenda.Profiles
{
    public class AgendaProfile: Profile
    {
        public AgendaProfile()
        {
    
            #region Input
            CreateMap<Agenda,AgendaInputView>()
                .ForMember(avm => avm.id, option => option.MapFrom(a =>a.Id))
                .ForMember(avm => avm.nome, option => option.MapFrom(a =>a.Nome))
                .ForMember(avm => avm.email, option => option.MapFrom(a =>a.Email))
                .ForMember(avm => avm.telefone, option => option.MapFrom(a =>a.Telefone));

            CreateMap<AgendaInputView, Agenda >()
               .ForMember(avm => avm.Id, option => option.MapFrom(a => a.id))
               .ForMember(avm => avm.Nome, option => option.MapFrom(a => a.nome))
               .ForMember(avm => avm.Email, option => option.MapFrom(a => a.email))
               .ForMember(avm => avm.Telefone, option => option.MapFrom(a => a.telefone));
            #endregion

        }
    }
}
