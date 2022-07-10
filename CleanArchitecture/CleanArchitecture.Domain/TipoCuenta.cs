﻿using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain
{
    public class TipoCuenta : BaseDomainModel
    {
        public int TipoCuentaId { get; set; }
        public string Nombre { get; set; }
    }
}
