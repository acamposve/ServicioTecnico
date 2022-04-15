using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioTecnico.Domain.Entities
{
    public class Receipt
    {
        public int id { get; set; }

        public string Referencia { get; set; }

        public DateTime FechaArribo { get; set; }

        public string Origen { get; set; }

        public string Destino { get; set; }

        public string status { get; set; }

        public string CantidadContainers { get; set; }

        public string Mercancia { get; set; }

    }
}
