using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace pim04.Models
{
    public class Quarto
    {
        [Key]
        public int ID { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O nome é obrigatorio")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "O preço é obrigatorio")]
        public int Preco { get; set; }

        public Reserva Reserva { get; set; }
    }
}
