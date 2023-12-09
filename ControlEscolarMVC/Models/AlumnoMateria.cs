using System;
using System.Collections.Generic;

namespace ControlEscolarMVC.Models;

public partial class AlumnoMateria
{
    public int IdAlumnoMateria { get; set; }

    public int? IdMateria { get; set; }

    public int? IdAlumno { get; set; }

    public decimal? Progreso { get; set; }

    public decimal? Calificacion { get; set; }

    public string? Estatus { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Alumno? IdAlumnoNavigation { get; set; }

    public virtual Materia? IdMateriaNavigation { get; set; }
}
