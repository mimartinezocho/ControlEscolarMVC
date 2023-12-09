using System;
using System.Collections.Generic;

namespace ControlEscolarMVC.Models;

public partial class Materia
{
    public int IdMateria { get; set; }

    public string? ClaveMateria { get; set; }

    public string? Nombre { get; set; }

    public int? IdProfesor { get; set; }

    public int? IdProgramaEstudio { get; set; }

    public byte? Estatus { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<AlumnoMateria> AlumnoMateria { get; set; } = new List<AlumnoMateria>();

    public virtual Profesor? IdProfesorNavigation { get; set; }

    public virtual ProgramaEstudio? IdProgramaEstudioNavigation { get; set; }
}
