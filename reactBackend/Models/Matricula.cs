﻿using System;
using System.Collections.Generic;

namespace reactBackend.Models;

public partial class Matricula
{
    public int Id { get; set; }

    public int AlumnoId { get; set; }

    public int Asignatura { get; set; }

    public virtual Alumno Alumno { get; set; } = null!;

    public virtual Asignatura AsignaturaNavigation { get; set; } = null!;

    public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();
}
