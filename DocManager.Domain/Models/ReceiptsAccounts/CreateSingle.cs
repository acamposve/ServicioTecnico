using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServicioTecnico.Domain.Models.ReceiptsAccounts
{
    public class CreateSingle
    {
        [Required]
        public string embarqueid { get; set; }

        [Required]
        public int accountid { get; set; }
    }
}
