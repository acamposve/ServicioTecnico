using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServicioTecnico.Domain.Models.ReceiptsFiles
{
    public class CreateRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public string Extension { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public int EmbarqueId { get; set; }
        [Required]
        public byte[] imageData { get; set; }
    }
}
