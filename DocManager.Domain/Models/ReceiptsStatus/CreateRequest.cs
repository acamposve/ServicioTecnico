using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServicioTecnico.Domain.Models.ReceiptsStatus
{
    public class CreateRequest
    {
        [Required]
        public string status { get; set; }
    }
}
