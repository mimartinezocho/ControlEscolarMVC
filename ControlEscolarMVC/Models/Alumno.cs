using System;
using System.Collections.Generic;

namespace ControlEscolarMVC.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string? Matricula { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Genero { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public byte? Estatus { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<AlumnoMateria> AlumnoMateria { get; set; } = new List<AlumnoMateria>();
}
