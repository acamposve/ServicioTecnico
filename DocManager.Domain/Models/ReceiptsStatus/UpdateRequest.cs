using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioTecnico.Domain.Models.ReceiptsStatus
{
    public class UpdateRequest
    {
        public int id { get; set; }

        public string status { get; set; }

    }
}
