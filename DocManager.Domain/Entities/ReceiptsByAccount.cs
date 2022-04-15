﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioTecnico.Domain.Entities
{
    public class ReceiptsByAccount
    {
        public int id { get; set; }
        public string status { get; set; }
        public string Referencia { get; set; }
        public DateTime FechaArribo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
    }
}
