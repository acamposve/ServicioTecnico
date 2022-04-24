using System;
using System.ComponentModel.DataAnnotations;

namespace ServicioTecnico.Domain.Entities
{
    public class Vendor
    {
        public Guid VendorId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
    }
}
