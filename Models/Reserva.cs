using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace pim04.Models
{
    public class Reserva
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Nome do hospede", Order = -9,
        Prompt = "Insira Nome do hospede", Description = "Nome do hospede")]
        public int HospedeId { get; set; }
        public Hospede Hospede { get; set; }

        [Display(Name = "Data de entrada", Order = -9,
        Prompt = "Insira a Data de entrada", Description = "Data de entrada")]
        public DateTime DataEntrada { get; set; }
        [Display(Name = "Data de saida", Order = -9,
        Prompt = "Insira a Data de saida", Description = "Data de saida")]
        public DateTime DataSaida { get; set; }

        [Display(Name = "Quarto", Order = -9,
        Prompt = "Insira o Quarto", Description = "Quarto")]
        public int QuartoId { get; set; }
        public Quarto Quarto { get; set; }

        [Display(Name = "Numero do quarto", Order = -9,
        Prompt = "Numero do quarto", Description = "Numero do quarto")]
        public int NumeroQuarto { get; set; }

        [Display(Name = "Método de pagamento", Order = -9,
        Prompt = "Insira o Método de pagamento", Description = "Método de pagamento")]
        public int? MetodoPagamentoId { get; set; }
        [Display(Name = "Método de pagamento", Order = -9,
        Prompt = "Insira o Método de pagamento", Description = "Método de pagamento")]
        public MetodoPagamento MetodoPagamento { get; set; }

        [Display(Name = "Pagamento", Order = -9,
        Prompt = "Pagamento", Description = "Pagamento")]
        public bool? Paid { get; set; }
    }
}
