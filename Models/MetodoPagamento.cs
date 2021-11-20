using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace pim04.Models
{
    public class MetodoPagamento
    {
        [Key]
        public int ID { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O nome é obrigatorio")]
        public string Nome { get; set; }

        public Reserva Reserva { get; set; }
    }
}
