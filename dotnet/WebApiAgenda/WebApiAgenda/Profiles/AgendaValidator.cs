using FluentValidation;
using WebApiAgenda.Models;

namespace WebApiAgenda.Profiles
{
    public class AgendaValidator: AbstractValidator<AgendaInputView>
    {
        public AgendaValidator()
        {
                RuleFor( a => a.nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            RuleFor(a => a.email)
                .NotEmpty()
                .WithMessage("E-mail é obrigatório")
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w)*\.\w([-.]\w+)*$")
                .WithMessage("E-mail inválido");

            RuleFor(a => a.telefone)
               .NotEmpty()
               .WithMessage("Telefone é obrigatório");
        }
    }
}
