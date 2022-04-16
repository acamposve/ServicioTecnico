using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServicioTecnico.Domain.Models.Customer
{
    public class CreateRequest
    {
        [Key]
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public string Address2 { get; set; }
    }
}
