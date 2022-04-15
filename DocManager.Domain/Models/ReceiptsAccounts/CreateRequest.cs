using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServicioTecnico.Domain.Models.ReceiptsAccounts
{
    public class CreateRequest
    {

        [Required]
        public int embarqueid { get; set; }

        [Required]
        public int[] userid { get; set; }
    }
}
