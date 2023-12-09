using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ControlEscolarMVC.Models;

public partial class ProgramaEstudio
{
    public int IdProgramaEstudio { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public byte? Estatus { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();
}
