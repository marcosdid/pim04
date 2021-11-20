using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace pim04.Models
{
    public class Funcionario
    {

        [Key]
        public int ID { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O nome é obrigatorio")]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O email é obrigatorio")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "O campo celular deve ser preenchido com numeros")]
        [Required(ErrorMessage = "O celular é obrigatorio")]
        public string Celular { get; set; }

        [StringLength(maximumLength: 11, MinimumLength = 11,
        ErrorMessage = "O campo {0} deve ter {1} números.")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "O Cpf é obrigatorio")]
        public string Cpf { get; set; }

        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public string DataDeNascimento { get; set; }

        [DataType(DataType.Text)]
        public string Logradouro { get; set; }

        public int? Numero { get; set; }

        [DataType(DataType.Text)]
        public string Complemento { get; set; }

        public int? CEP { get; set; }

        [DataType(DataType.Text)]
        public string UF { get; set; }

        [DataType(DataType.Text)]
        public string Estado { get; set; }

        [DataType(DataType.Text)]
        public string Cidade { get; set; }

        [DataType(DataType.Text)]
        public string Bairro { get; set; }
    }
}
