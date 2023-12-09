using System;
using System.Collections.Generic;

namespace ControlEscolarMVC.Models;

public partial class Profesor
{
    public int IdProfesor { get; set; }

    public string? Usuario { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Genero { get; set; }

    public byte? Estatus { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();
}
