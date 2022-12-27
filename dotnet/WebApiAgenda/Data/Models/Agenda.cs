using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Agenda
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public string? Telefone { get; set; }
}
