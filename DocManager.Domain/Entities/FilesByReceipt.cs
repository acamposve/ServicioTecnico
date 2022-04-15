using System;
using System.Collections.Generic;
using System.Text;

namespace ServicioTecnico.Domain.Entities
{
    public class FilesByReceipt
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public int EmbarqueId { get; set; }
    }
}
