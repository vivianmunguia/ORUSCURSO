﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Oruscurso.Logica
{
    public class Lusuarios
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] Icono { get; set; }
        public string Estado { get; set; }
    }
}