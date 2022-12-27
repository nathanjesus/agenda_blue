using System.ComponentModel.DataAnnotations;

namespace WebApiAgenda.Models
{
    public class AgendaInputView
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
    }
}
