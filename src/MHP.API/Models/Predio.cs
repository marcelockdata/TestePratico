using System;
using System.ComponentModel.DataAnnotations;

namespace MHP.API.Models
{
    public class Predio
    {
        [Key]
        public Guid PredioId { get; set; }
        public int Andar { get; set; }
        public string Elevador { get; set; }
        public string Turno { get; set; }

    }
}
